<?php
  session_start();
  if (!isset($_SESSION["user"])){
    header("Location: index.php");
  } else{
    include("top.php");
    if (isset($_SESSION["prodId"])){
      $id=$_SESSION["prodId"];
    }
    if (!isset($_SESSION["cartItems"])){
      $_SESSION["cartItems"]=array();
    }
    if(isset($_POST['cartFunction'])&&!empty($_POST['cartFunction'])){
      if ($_POST['cartFunction']=='addItem'){
        $quantity=(int)$_POST["quantity"];
        array_push($_SESSION["cartItems"], array($id, $quantity));
      } else if(($_POST['cartFunction']=='removeItem')){
        unset($_SESSION["cartItems"][$_POST['index']]);
        $_SESSION["cartItems"]=array_values($_SESSION["cartItems"]);
      }
    }
  }
  if (sizeof($_SESSION["cartItems"])>0){
?>
<form method="post" id ="cartForm" class="bg-light" action="cartvalidate.php" onsubmit="return cartFormValidate(this)">
  <div class="table-responsive">
    <table class="table">
      <thead>
        <tr>
          <th>Termék</th>
          <th>Darab</th>
          <th>Ár</th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        <?php
          $totalPrice=0;
          require_once("connect.php");
          for ($i=0; $i<sizeof($_SESSION["cartItems"]); $i++){
            echo '<tr>';
            $query="SELECT id, make, type, category, price FROM products WHERE id='{$_SESSION["cartItems"][$i][0]}';";
            $result=$conn->query($query);
            while ($record=$result->fetch_assoc()){
              $totalPrice+=$record["price"]*$_SESSION["cartItems"][$i][1];
              echo '<td>'.$record["make"]." ".$record["type"]." ".$record["category"].'</td>
                    <td>'.$_SESSION["cartItems"][$i][1].'</td>
                    <td>'.$record["price"]." Ft".'</td>';
            }
            echo '<td><button class="btn btn-danger" onclick="removeCartItem('.$i.')">Törlés</button></td>
                </tr>';
          }
          echo '<tr>
                  <td></td>
                  <td></td>
                  <td>Összesen: '.$totalPrice.' Ft</td>
                  <td></td>
                </tr>';
        ?>
      </tbody>
    </table>
  </div>
  <div class="form-group">
  	<label for="fullnameCart">Név:</label>
  	<input type="text" class="form-control" name="fullnameCart" value="
    <?php
      $name="";
      $query="SELECT full_name FROM users WHERE id='{$_SESSION["user"][0]}'";
      $result=$conn->query($query);
      if (!$result){
        echo "Hiba a lekérdezés során!";
      }
      else{
        while ($record=$result->fetch_assoc()){
          $name=$record["full_name"];
        }
        echo $name;
      }
    ?>
    " readonly>
  </div>
  <div class="form-group">
    <label for="zip">Irányítószám:</label>
    <input type="text" id="zipCart" class="form-control" placeholder="Írja be az irányítószámot!" name="zipCart" onkeyup="zipCartValidate()" required>
  </div>
	<div class="form-group">
    <label for="address">Közterület, házszám:</label>
    <input type="text" id="addressCart" class="form-control" placeholder="Írja be a címet! (Pl.: Arany utca 5.)" name="addressCart" onkeyup="addressCartValidate()" required>
  </div>
  <button type="submit" name="submitCart" class="btn btn-primary">Rendelés leadása</button>
</form>
<?php
} else{
  echo '<h2 class="text-center text-white">A kosár tartalma üres!';
}
echo file_get_contents("html/bottom.html");
?>
