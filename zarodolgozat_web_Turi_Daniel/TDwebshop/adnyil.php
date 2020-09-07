<?php
  session_start();
  include("top.php");
?>
<div class="footer_links">
  <h2>Adatkezelési nyilatkozat</h2>
  A webshopban történő regisztráció során a vásárló által megadott adatok tárolásra kerülnek az adatbázisban. A regisztrált felhasználó adatai mindaddig tárolásra kerülnek, míg a felhasználó nem kéri az adabázisból való törlését, melyet írásban a emailexample@emailexample.hu emailcímre kell elküldenie, pontos felhasználónév megjelöléssel. A TDWebshop a regisztrált felhasználók adatait harmadik fél részére nem adja ki!
</div>
<?php
  echo file_get_contents("html\bottom.html");
?>
