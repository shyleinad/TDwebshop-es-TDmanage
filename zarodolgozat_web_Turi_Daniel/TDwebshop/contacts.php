<?php
  include("top.php");
?>
<div class="footer_links">
  <h2>Elérhetőségek</h2>
  <h3>Cím:</h3>
  1234 Szeged,<br>
  Valami utca 1
  <h3>Telefonszám:</h3>
  06 12 345 6789
  <h3>E-mail cím:</h3>
  peldamail@peldamail.hu
</div>
<?php
  echo file_get_contents("html\bottom.html");
?>
