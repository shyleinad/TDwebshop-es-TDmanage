<?php
	session_start();
	include("top.php");
?>
<div id="slideshow" class="carousel slide" data-ride="carousel">
	<ul class="carousel-indicators">
		<?php
			require_once("connect.php");
			$query="SELECT * FROM news ORDER BY date DESC LIMIT 6;";
			$result=$conn->query($query);
			$indicator='';
			if (!$result){
				//Lekérdezés hiba
				echo "Hiba a lekérdezés végrehajtásakor!";
			} else{
				//Ha sikeres a lekérdezés
				$i=0;
				while ($record=$result->fetch_assoc()){
					if ($i==0){
						$indicator.= '<li data-target="#slideshow" data-slide-to="0" class="active"></li>';
					}
					else {
						$indicator.= '<li data-target="#slideshow" data-slide-to="'.$i.'"></li>';
					}
					$i++;
				}
			}
			echo $indicator;
		?>
  </ul>
	<div class="carousel-inner">
	<?php
		require_once("connect.php");
		$query="SELECT * FROM news ORDER BY date DESC LIMIT 6;";
		$result=$conn->query($query);
		$items='';
		if (!$result){
			//Lekérdezés hiba
			echo "Hiba a lekérdezés végrehajtásakor!";
		} else{
			//Ha sikeres a lekérdezés
			$i=0;
			while ($record=$result->fetch_assoc()){
				if ($i==0){
					$items.= '<div class="carousel-item active">
								     <img class="slideshowimg" src="pics/news/'.$record['image'].'">
										 <div class="carousel-caption">
    						 				<h3 class="bg-dark">'.$record['title'].'</h3>
    										<p class="bg-dark">'.$record['text'].'</p>
  									</div>
								   </div>';
				}
				else {
					$items.= '<div class="carousel-item">
									    <img class="slideshowimg" src="pics/news/'.$record['image'].'">
											<div class="carousel-caption">
     						 				<h3 class="bg-dark">'.$record['title'].'</h3>
     										<p class="bg-dark">'.$record['text'].'</p>
   										</div>
									  </div>';
				}
				$i++;
			}
		}
		echo $items;
	?>
	</div>
	<!-- Left and right controls -->
	<a class="carousel-control-prev" href="#slideshow" data-slide="prev">
		<span class="carousel-control-prev-icon"></span>
	</a>
	<a class="carousel-control-next" href="#slideshow" data-slide="next">
		<span class="carousel-control-next-icon"></span>
	</a>
</div>
<?php
 	echo file_get_contents("html/bottom.html");
?>
