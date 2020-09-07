<?php
  session_start();
  if (isset($_SESSION["user"])){
    header("Location: index.php");     //Ha be van jelentkezve valaki:
  }
  else{
    require_once("connect.php");
    if (isset($_SESSION['error'])){
      unset($_SESSION["error"]);
    }
    if (isset($_POST["email"])){
      $email=$_POST["email"];
      $pswd=$_POST["pswd"];
      $hashedPswd=hash('sha256', $pswd);
      $query="SELECT * FROM users WHERE email = '{$email}' AND password='{$hashedPswd}';";
      $res=$conn->query($query);
      if ($res&&$res->num_rows==1){
        $rec=$res->fetch_assoc();
        $_SESSION["user"]=array($rec["id"], $rec["email"]);
        if (isset($_SESSION["error"])){
          unset($_SESSION["error"]);
        }
        header ("Location: index.php");
      } else {
        $_SESSION["error"] = "A felhasználónév vagy jelszó nem megfelelő!";
      }
    }
    include ("top.php");
?>
    <form id="formlogin" class="bg-light" action="#" method="post">
      <?php
        if (isset($_SESSION['error'])){
          echo '<h4 class="text-danger">'.$_SESSION['error'].'</h4>';
        }
      ?>
    	<div class="form-group" id="emaildiv">
    	 <label for="lastname">E-mail cím:</label>
    	  <input type="text" class="form-control" id="email" placeholder="Adja meg az e-mail címét!" name="email" required>
      </div>

    	<div class="form-group" id="pswddiv">
    	 <label for="pswd">Jelszó:</label>
    	  <input type="password" class="form-control" id="pswd" placeholder="Adja meg jelszavát!" name="pswd" required>
      </div>

    	<button type="submit" name="submit" class="btn btn-primary">Belépés</button>
    </form>
<?php
    echo file_get_contents("html\bottom.html");
  }
  /*else if (isset($_SESSION["user"])){
    header("Location: index.php");
  }*/
?>
