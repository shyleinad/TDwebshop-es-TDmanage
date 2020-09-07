<?php
  session_start();
  include("top.php");
  include("paginate_functions.php");
?>
<?php
  require_once("connect.php");
  $query="";
  $limit=25;
  $totalPages=0;
  if (isset($_GET['page'])){
    $offset=($_GET['page']-1)*$limit;
  } else{
    $offset=0;
  }
  $rows=0;

  if (isset($_GET['category'])){
    $cat=$_GET['category'];
    $query="SELECT p.id AS product_id, p.make, p.type, p.color, p.category, p.price, p.details, p.image, p.lefthanded, p.active, c.id, c.category_name
    FROM products AS p, categories AS c
    WHERE c.category_name=p.category AND c.id='{$cat}' AND active=1 ";
    $resultRows=$conn->query($query);
    $rows=mysqli_num_rows($resultRows);
  }
  if ((isset($_POST['price'])&&!empty($_POST['price']))&&(!isset($_POST['lefthanded'])||empty($_POST['lefthanded']))){ //Ha csak árra szűrünk
    $cat=$_GET['category'];
    $price=$_POST['price'];
    $query="SELECT p.id AS product_id, p.make, p.type, p.color, p.category, p.price, p.details, p.image, p.lefthanded, p.active, c.id, c.category_name
    FROM products AS p, categories AS c
    WHERE c.category_name=p.category AND c.id='{$cat}' AND price<='{$price}' AND active=1 ";
    $resultRows=$conn->query($query);
    $rows=mysqli_num_rows($resultRows);
  }
  else if ((!isset($_POST['price'])||empty($_POST['price']))&&(isset($_POST['lefthanded'])&&!empty($_POST['lefthanded']))){ //Ha csak balkézre
    $cat=$_GET['category'];
    $lh=$_POST['lefthanded'];
    if ($lh==="true"){
      $query="SELECT p.id AS product_id, p.make, p.type, p.color, p.category, p.price, p.details, p.image, p.lefthanded, p.active, c.id, c.category_name
      FROM products AS p, categories AS c
      WHERE c.category_name=p.category AND c.id='{$cat}' AND lefthanded=1 AND active=1 ";
      $resultRows=$conn->query($query);
      $rows=mysqli_num_rows($resultRows);
    }
    else{
      $query="SELECT p.id AS product_id, p.make, p.type, p.color, p.category, p.price, p.details, p.image, p.lefthanded, p.active, c.id, c.category_name
      FROM products AS p, categories AS c
      WHERE c.category_name=p.category AND c.id='{$cat}' AND lefthanded=0 AND active=1 ";
      $resultRows=$conn->query($query);
      $rows=mysqli_num_rows($resultRows);
    }
  }
  else if ((isset($_POST['price'])&&!empty($_POST['price']))&&(isset($_POST['lefthanded'])&&!empty($_POST['lefthanded']))){ //Ha mindkettőre
    $cat=$_GET['category'];
    $price=$_POST['price'];
    $lh=$_POST['lefthanded'];
    if ($lh==="true"){
      $query="SELECT p.id AS product_id, p.make, p.type, p.color, p.category, p.price, p.details, p.image, p.lefthanded, p.active, c.id, c.category_name
      FROM products AS p, categories AS c
      WHERE c.category_name=p.category AND c.id='{$cat}' AND lefthanded=1 AND price<='{$price}' AND active=1 ";
      $resultRows=$conn->query($query);
      $rows=mysqli_num_rows($resultRows);
    }
    else{
      $query="SELECT p.id AS product_id, p.make, p.type, p.color, p.category, p.price, p.details, p.image, p.lefthanded, p.active, c.id, c.category_name
      FROM products AS p, categories AS c
      WHERE c.category_name=p.category AND c.id='{$cat}' AND lefthanded=0 AND price<='{$price}' AND active=1 ";
      $resultRows=$conn->query($query);
      $rows=mysqli_num_rows($resultRows);
    }
  }
  $query.=" LIMIT {$limit} OFFSET {$offset}";
  //Ha rákattintunk valamelyik termékre:
  if (isset($_GET['id'])&&!empty($_GET['id'])){
    $prodid=$_GET['id'];
    $query="SELECT * FROM products WHERE id='{$prodid}';";
    $result=$conn->query($query);
    $products='';
    if (!$result){
      //Lekérdezés hiba
      echo "Hiba a lekérdezés végrehajtásakor!";
    } else{
      //Ha sikeres a lekérdezés
      while ($record=$result->fetch_assoc()){
        //var_dump($record['id']);
        if (isset($_SESSION["user"])){
          $_SESSION["prodId"]=(int)$record['id'];
          $products='<div class="card clicked_prod">'
                        .'<img class="card-image-top clicked_prod_img" src="pics/products/'.$record['image'].'">'
                        .'<div class="card-body">'
                            .'<h4 class="card-title">'.$record['make']." ".$record['type'].'</h4>'
                            .'<p class="card-text">'.$record['price'].' Ft <br>'.$record['color']
                            .'<br><p class="card-text">'.$record['details']
                            .'<div>'
                            .' Darab: <input type="number" id="quantity" name="quantity" value="1" min="1" max="10">'
                            .'</div>'
                            .'<input type="submit" class="btn btn-primary" onclick="addCartItem()" value="Kosárba">'
                        .'</div>'
                      .'</div>';
        } else{
          $products='<div class="card clicked_prod">'
                        .'<img class="card-image-top clicked_prod_img" src="pics/products/'.$record['image'].'">'
                        .'<div class="card-body">'
                            .'<h4 class="card-title">'.$record['make']." ".$record['type'].'</h4>'
                            .'<p class="card-text">'.$record['price'].' Ft <br>Szín: '.$record['color']
                            .'<br><p class="card-text">'.$record['details']
                            .'<p>A kosárba rakáshoz és a rendeléshez be kell jelentkeznie!'
                        .'</div>'
                      .'</div>';
        }
      }
      echo $products;
    }
  }
  //Ha nincs rákattintva egyik termékre sem
  else {
?>
<script>
  $(".content").append('<form method="post" class="bg-light" id="filterform"></form>');

  $("#filterform").append('<div class="form-group" id="pricediv"></div>');
	$("#pricediv").append('<label for="price">Ár:</label>');
	$("#pricediv").append('<input type="text" class="form-control" id="price" placeholder="Adja meg a maximális árat!" name="price">');
</script>
<?php
if (isset($_GET['category'])){
  $categ=(int)$_GET['category'];
  if ($categ<=10){
    echo '<script>
            $("#filterform").append(\'<div class="form-group form-check-inline" id="radiodiv"></div>\');
            $("#radiodiv").append(\'<label class="form-check-label" id="radiolabel"></label>\');
    	      $("#radiolabel").append(\'<input class="form-check-input" type="radio" id="lefthandedN" name="lefthanded" value="false">Jobbkezes\');
            $("#filterform").append(\'<div class="form-group form-check-inline" id="checkdiv2"></div>\');
            $("#checkdiv2").append(\'<label class="form-check-label" id="radiolabel2"></label>\');
            $("#radiolabel2").append(\'<input class="form-check-input" type="radio" id="lefthandedY" name="lefthanded" value="true">Balkezes\');
            $("#filterform").append(\'<button type="submit" class="btn btn-primary">Szűrés</button>\');
        </script>';
  } else{
    echo '<script>
            $("#filterform").append(\'<button type="submit" class="btn btn-primary">Szűrés</button>\');
          </script>';
  }
}
?>
<?php
    if ($_GET['page']<=$_SESSION['totalPages']&&$_GET['page']>=1){
      $result=$conn->query($query);
      $products='';
      if (!$result){
        //Lekérdezés hiba
        echo "Hiba a lekérdezés végrehajtásakor!";
      } else{
        //Ha sikeres a lekérdezés
        $products.='<div class="card-columns">';
        while ($record=$result->fetch_assoc()){
          //var_dump($record['id']);
            $products.='<div class="card">'
                          .'<img class="card-image-top" src="pics/products/'.$record['image'].'">'
                          .'<div class="card-body">'
                              .'<h4 class="card-title">'.$record['make']." ".$record['type'].'</h4>'
                              .'<p class="card-text">'.$record['price'].' Ft <br>Szín: '.$record['color'];
                              if ($record['id']<11){
                                if ($record['lefthanded']==="1"){
                                  $products.='<p class="card-text">Balkezes';
                                }
                                else{
                                  $products.='<p class="card-text">Jobbkezes';
                                }
                              }
                              $products.='<p><a href="?id='.$record['product_id'].'" class="btn btn-primary">Részletek</a>'
                          .'</div>'
                        .'</div>';
        }
        $products.='</div>';
        echo $products;
        $conn->close();
      }
    }
    else if ($_GET['page']>$_SESSION['totalPages']||$_GET['page']<1){
      header("Location: products.php?category=".$_GET['category']."&page="."1");
    }
  }
  if (!isset($_GET['id'])){
?>
  <div class="container" id="pageNavigation">
    <ul class="pagination justify-content-center">
      <!--<li class="page-item"><a class="page-link"><<</a></li>
      <li class="page-item"><a class="page-link"><</a></li>-->
      <?php
        $totalPages=ceil($rows/$limit);
        $_SESSION['totalPages']=$totalPages;
        echo '<li class="page-item"><a class="page-link" href="products.php?category='.$_GET['category'].'&page='.firstPage().'"><<</a></li>';
        echo '<li class="page-item"><a class="page-link" href="products.php?category='.$_GET['category'].'&page='.prevPage().'"><</a></li>';
        for ($i=1; $i<=$totalPages; $i++){
          echo '<li class="page-item"><a class="page-link" href="products.php?category='.$_GET['category'].'&page='.$i.'">'.$i.'</a></li>';
        }
        echo '<li class="page-item"><a class="page-link" href="products.php?category='.$_GET['category'].'&page='.nextPage().'">></a></li>';
        echo '<li class="page-item"><a class="page-link" href="products.php?category='.$_GET['category'].'&page='.lastPage().'">>></a></li>';
      ?>
      <!--<li class="page-item"><a class="page-link">></a></li>
      <li class="page-item"><a class="page-link">>></a></li>-->
    </ul>
  </div>
<?php
  }
  echo file_get_contents("html\bottom.html");
?>
