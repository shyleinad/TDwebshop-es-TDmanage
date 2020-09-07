<?php
  session_start();

  $zipCorr=false;
  $addCorr=false;

  $addressCart=$_POST['addressCart']; $zipCart=$_POST['zipCart'];
  if (isset($_POST["submitCart"])){
    //Irányítószám vizsgálata:
    if (isset($zipCart)&&!empty($zipCart)){
      if ($zipCart>=1000 && $zipCart<=9999){
        $zipCorr=true;
      }
      else{
        //Ha irányítószám nem jó:
      }
    }
    //Cím vizsgálata:
    if (isset($addressCart)&&!empty($addressCart)){
      if (preg_match("/^\s*\S+(?:\s+\S+){2}/", $addressCart)){
        $addCorr=true;
      }
      else{
        //Ha nem jó a cím:
      }
    }
    //Ha jó a form
    if ($zipCorr&&$addCorr){
      $usrId=$_SESSION["user"][0];
      $address=$zipCart." ".$addressCart;
      $orderDetails='';
      $totalPrice=0;
      require_once("connect.php");
      for ($i=0; $i < sizeof($_SESSION["cartItems"]); $i++) {
        $cartId=strval($_SESSION["cartItems"][$i][0]);
        $quantityPrice=$_SESSION["cartItems"][$i][1];
        $query="SELECT id, make, type, color, category, lefthanded, price FROM products WHERE id='{$cartId}';";
        $result=$conn->query($query);
        while ($record=$result->fetch_assoc()){
          $quantityPrice=$_SESSION["cartItems"][$i][1]*$record["price"];
          $totalPrice+=$quantityPrice;
          $orderDetails.='(Termék id: '.$record["id"].') '.$record["make"].' '.$record["type"].' '.$record["color"].' - '.$record["category"].'\n\tBalkezes: '.$record["lefthanded"].'\n\tDarabszám: '.$_SESSION["cartItems"][$i][1].'\n\tÁr: '.$quantityPrice.' Ft\n\n';
        }
      }
      $orderDetails.='Ár összesen: '.$totalPrice.' Ft';
      $query="INSERT INTO orders (user_id, address, details, total_price) VALUES ('{$usrId}', '{$address}', '{$orderDetails}', '{$totalPrice}');";
      $res=$conn->query($query);
      $_SESSION["cartItems"]=array();
      header("Location: cart.php");
    }
  } else{
    header ("Location: index.php");
  }
?>
