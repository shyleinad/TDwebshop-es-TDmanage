<?php
  $conn=new mysqli("localhost", "visitor_and_regged_user", "SAWAtFv3fiju1n5t", "td_webshop", "3306");
  if ($conn->connect_error){
    die("Nem sikerült csatlakozni az adatbázishoz!\n".$conn->connect_error);
  }
  if (!$conn->set_charset("utf8")){
  echo "Karakterkódolási hiba!";
  }
?>
