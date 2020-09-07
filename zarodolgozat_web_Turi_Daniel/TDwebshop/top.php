<!DOCTYPE html>
<html lang="hu">
	<head>
		<meta charset="UTF-8">
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<script src="js/jquery-3.4.1.min.js"></script>
		<script src="js/bootstrap.min.js"></script>
		<script src="js/menu.js"></script>
		<script src="js/cart.js"></script>
		<script src="js/regvalidate.js"></script>
		<script src="js/cartValidate.js"></script>
		<link rel="stylesheet" href="css/bootstrap.min.css">
		<link rel="stylesheet" href="css/style.css">
		<title>TD Webshop</title>
	</head>
	<body>
		<div class="page-header text-center">
			<a href="index.php"><img src="pics/banner5.jpg"></img></a>
		</div>

		<nav class="navbar navbar-expand-sm bg-dark justify-content-center">
			<ul class="nav nav-pills">
				<li class="nav-item"><a class="nav-link" href="#" onclick="ElectricClick()">Elektromos gitárok</a></li>
				<li class="nav-item"><a class="nav-link" href="#" onclick="BassClick()">Basszus gitárok</a></li>
				<li class="nav-item"><a class="nav-link" href="#" onclick="AcousticClick()">Akusztikus gitárok</a></li>
				<li class="nav-item"><a class="nav-link" href="#" onclick="AmpClick()">Erősítők</a></li>
				<li class="nav-item"><a class="nav-link" href="#" onclick="EffectClick()">Effek pedálok</a></li>
				<li class="nav-item"><a class="nav-link" href="#" onclick="AccesClick()">Kiegészítők</a></li>
				<li class="nav-item"><a class="nav-link" href="#" onclick="PartClick()">Alkatrészek</a></li>
				<?php
					if (!isset($_SESSION["user"])){
						echo 	'<li class="nav-item"><a class="nav-link" href="login.php">Bejelentkezés</a></li>
									<li class="nav-item"><a class="nav-link" href="#" onclick="RegClick()">Regisztráció</a></li>';
					}
					if (isset($_SESSION["user"])){
						echo '<li class="nav-item"><a class="nav-link" href="cart.php">Kosár</a></li>';
						echo '<li class="nav-item"><a class="nav-link" href="logout.php">Kilépés</a></li>';
					}
				?>
			</ul>
		</nav>

		<div class="content">
