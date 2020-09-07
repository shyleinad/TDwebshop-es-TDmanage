<?php
  session_start();
  unset($_SESSION["cartItems"]);
  unset($_SESSION["user"]);
  session_destroy();
  header("Location: index.php");
?>
