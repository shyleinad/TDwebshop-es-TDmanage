<?php
  session_start();
  if (isset($_SESSION["user"])){
    header ("Location: index.php");
  }
  $lnameCorr=false;
  $fnameCorr=false;
  $emailCorr=false;
  $pswdCorr=false;

  $lname=$_POST['lastname']; $fname=$_POST['firstname']; $email=$_POST['email']; $pswd=$_POST['pswd']; $pswd2=$_POST['pswd2'];
  if (isset($_POST['submit'])){
    //Vezetéknév vizsgálata:
    if (isset($lname)&&!empty($lname)){
      if (strlen($lname)>=2 && !is_numeric($lname)){
        $lnameCorr=true;
    	}
    	else{
        //Ha vezetéknév nem jó:
    	}
    }

    //Keresztnév vizsgálata:
    if (isset($fname)&&!empty($fname)){
      if (strlen($fname)>=2 && !is_numeric($fname)){
        $fnameCorr=true;
    	}
    	else{
        //Ha keresztnév nem jó:
    	}
    }

    //Email vizsgálata:
    if (isset($email)&&!empty($email)){
      if (preg_match("/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/",$email)){
        $emailCorr=true;
      }
      else{
        //Ha az email nem jó:
      }
    }

    //Jelszó vizsgálata:
    if (isset($pswd)&&!empty($pswd)&&isset($pswd2)&&!empty($pswd2)){
      $contNum=false; $contLow=false; $contUpp=false;
      for ($i=0; $i<strlen($pswd); $i++){
        if (is_numeric($pswd[$i])){
          $contNum=true;
        }
        else{
          if ($pswd[$i]==strtolower($pswd[$i])){
            $contLow=true;
          }
          if ($pswd[$i]==strtoupper($pswd[$i])){
            $contUpp=true;
          }
        }
      }
      if (strlen($pswd)>=8 && $contNum && $contLow && $contUpp){
        //Ha minden jó a jelszóban:
        //Megerősített jelszó ellenőrzése:
        if ($pswd2==$pswd){
          //Ha a 2 jelszó megegyezik:
          $pswdCorr=true;
        }
        else{
          //Ha a 2 jelszó nem egyezik meg:
        }
      }
      else{
        //Ha nem jó minden a jelszóban:
      }
    }

    //Egész form vizsgálata:
    if ($emailCorr&&$fnameCorr&&$lnameCorr&&$pswdCorr){
      //Ha jó a form:
      require_once("connect.php");
      $query="SELECT * FROM users WHERE email='{$email}';";
      $hashedPswd=hash('sha256', $pswd);
      $res1=$conn->query($query);
      if ($res1){
        if ($res1->num_rows==0){ //létezik-e már az adott felhasználó:
          $fullname=$lname." ".$fname;
          $insert="INSERT INTO users (full_name, email, password) VALUES ('{$fullname}', '{$email}', '{$hashedPswd}');";
          $res2=$conn->query($insert);
          if ($res2){
            $rec=$res1->fetch_assoc();
            header ("Location: index.php");
          }
          else{
            echo "Hiba az adatbázisba való beszúrás közben!";
          }
        }
        else {
          echo "Az adott email cím már regisztrálva van!";
        }
      }
    }
    else{
      //Ha nem jó a form:
      echo "A regisztráció sikertelen nem megfelelő adatok miatt!";
    }
  }
  else{
    header ("Location: index.php");
  }
?>
