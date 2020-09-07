var content=document.getElementsByClassName("content");
function ElectricClick(){
	$(".content").empty();
	$(".content").append('<div class="card-columns"></div>');

	$(".card-columns").append('<div class="card" id="cardEl"></div>');
	$("#cardEl").append('<img class="card-img-top" src="pics/categories/electric.jpg"></img>');
	$("#cardEl").append('<div class="card-body" id="cardbodyEl"><a href="products.php?category=1&page=1" class="stretched-link" name="linkEl"></a></div>');
	$("#cardbodyEl").append('<h4 class="card-title">Elektromos gitárok</h4>');

	$(".card-columns").append('<div class="card" id="cardJ"></div>');
	$("#cardJ").append('<img class="card-img-top" src="pics/categories/jazz.jpg"></img>');
	$("#cardJ").append('<div class="card-body" id="cardbodyJ"><a href="products.php?category=2&page=1" class="stretched-link" name="linkJ"></a></div>');
	$("#cardbodyJ").append('<h4 class="card-title">Jazz gitárok</h4>');

	$(".card-columns").append('<div class="card" id="card7"></div>');
	$("#card7").append('<img class="card-img-top" src="pics/categories/8string.jpg"></img>');
	$("#card7").append('<div class="card-body" id="cardbody7"><a href="products.php?category=3&page=1" class="stretched-link" name="link7"></a></div>');
	$("#cardbody7").append('<h4 class="card-title">7-8-12 húros gitárok</h4>');
}

function BassClick() {
	$(".content").empty();
	$(".content").append('<div class="card-columns"></div>');

	$(".card-columns").append('<div class="card" id="cardEb"></div>');
	$("#cardEb").append('<img class="card-img-top" src="pics/categories/elecbass.jpg"></img>');
	$("#cardEb").append('<div class="card-body" id="cardbodyEb"><a href="products.php?category=4&page=1" class="stretched-link" name="linkEb"></a></div>');
	$("#cardbodyEb").append('<h4 class="card-title">Elektromos basszusgitárok</h4>');

	$(".card-columns").append('<div class="card" id="cardAb"></div>');
	$("#cardAb").append('<img class="card-img-top" src="pics/categories/acbass.jpg"></img>');
	$("#cardAb").append('<div class="card-body" id="cardbodyAb"><a href="products.php?category=5&page=1" class="stretched-link" name="linkAb"></a></div>');
	$("#cardbodyAb").append('<h4 class="card-title">Akusztikus basszusgitárok</h4>');

	$(".card-columns").append('<div class="card" id="card5"></div>');
	$("#card5").append('<img class="card-img-top" src="pics/categories/5stringbass.jpg"></img>');
	$("#card5").append('<div class="card-body" id="cardbody5"><a href="products.php?category=6&page=1" class="stretched-link" name=link5></a></div>');
	$("#cardbody5").append('<h4 class="card-title">4-nél több húros basszusgitárok</h4>');
}

function AcousticClick() {
	$(".content").empty();
	$(".content").append('<div class="card-columns"></div>');

	$(".card-columns").append('<div class="card" id="cardA"></div>');
	$("#cardA").append('<img class="card-img-top" src="pics/categories/acoustic.jpg"></img>');
	$("#cardA").append('<div class="card-body" id="cardbodyA"><a href="products.php?category=7&page=1" class="stretched-link" name="linkA"></a></div>');
	$("#cardbodyA").append('<h4 class="card-title">Akusztikus gitárok</h4>');

	$(".card-columns").append('<div class="card" id="cardC"></div>');
	$("#cardC").append('<img class="card-img-top" src="pics/categories/classical.jpg"></img>');
	$("#cardC").append('<div class="card-body" id="cardbodyC"><a href="products.php?category=10&page=1" class="stretched-link" name="linkC"></a></div>');
	$("#cardbodyC").append('<h4 class="card-title">Klasszikus gitárok</h4>');

	$(".card-columns").append('<div class="card" id="cardEa"></div>');
	$("#cardEa").append('<img class="card-img-top" src="pics/categories/elecac.jpg"></img>');
	$("#cardEa").append('<div class="card-body" id="cardbodyEa"><a href="products.php?category=8&page=1" class="stretched-link" name="linkEa"></a></div>');
	$("#cardbodyEa").append('<h4 class="card-title">Elektro-akusztikus gitárok</h4>');

	$(".card-columns").append('<div class="card" id="cardEc"></div>');
	$("#cardEc").append('<img class="card-img-top" src="pics/categories/elecclass.jpg"></img>');
	$("#cardEc").append('<div class="card-body" id="cardbodyEc"><a href="products.php?category=9&page=1" class="stretched-link" name="linkEc"></a></div>');
	$("#cardbodyEc").append('<h4 class="card-title">Elektro-klasszikus gitárok</h4>');
}

function AmpClick(){
	$(".content").empty();
	$(".content").append('<div class="card-columns"></div>');

	$(".card-columns").append('<div class="card" id="cardCo"></div>');
	$("#cardCo").append('<img class="card-img-top" src="pics/categories/combo2.jpg"></img>');
	$("#cardCo").append('<div class="card-body" id="cardbodyCo"><a href="products.php?category=11&page=1" class="stretched-link" name="linkCo"></a></div>');
	$("#cardbodyCo").append('<h4 class="card-title">Gitárkombók</h4>');

	$(".card-columns").append('<div class="card" id="cardH"></div>');
	$("#cardH").append('<img class="card-img-top" src="pics/categories/amphead.jpg"></img>');
	$("#cardH").append('<div class="card-body" id="cardbodyH"><a href="products.php?category=12&page=1" class="stretched-link" name="linkH"></a></div>');
	$("#cardbodyH").append('<h4 class="card-title">Erősítőfejek</h4>');

	$(".card-columns").append('<div class="card" id="cardCa"></div>');
	$("#cardCa").append('<img class="card-img-top" src="pics/categories/cabinet.jpg"></img>');
	$("#cardCa").append('<div class="card-body" id="cardbodyCa"><a href="products.php?category=13&page=1" class="stretched-link" name="linkCa"></a></div>');
	$("#cardbodyCa").append('<h4 class="card-title">Ládák</h4>');

	$(".card-columns").append('<div class="card" id="cardBc"></div>');
	$("#cardBc").append('<img class="card-img-top" src="pics/categories/basscomb.jpg"></img>');
	$("#cardBc").append('<div class="card-body" id="cardbodyBc"><a href="products.php?category=14&page=1" class="stretched-link" name="linkBc"></a></div>');
	$("#cardbodyBc").append('<h4 class="card-title">Basszuskombók</h4>');

	$(".card-columns").append('<div class="card" id="cardBh"></div>');
	$("#cardBh").append('<img class="card-img-top" src="pics/categories/basshead.jpg"></img>');
	$("#cardBh").append('<div class="card-body" id="cardbodyBh"><a href="products.php?category=15&page=1" class="stretched-link" name="linkBh"></a></div>');
	$("#cardbodyBh").append('<h4 class="card-title">Basszusfejek</h4>');

	$(".card-columns").append('<div class="card" id="cardBca"></div>');
	$("#cardBca").append('<img class="card-img-top" src="pics/categories/cabinet.jpg"></img>');
	$("#cardBca").append('<div class="card-body" id="cardbodyBca"><a href="products.php?category=16&page=1" class="stretched-link" name="linkBca"></a></div>');
	$("#cardbodyBca").append('<h4 class="card-title">Basszusládák</h4>');
}

function EffectClick(){
	$(".content").empty();
	$(".content").append('<div class="card-columns"></div>');

	$(".card-columns").append('<div class="card" id="cardDis"></div>');
	$("#cardDis").append('<img class="card-img-top" src="pics/categories/distortion.jpg"></img>');
	$("#cardDis").append('<div class="card-body" id="cardbodyDis"><a href="products.php?category=17&page=1" class="stretched-link" name="linkDis"></a></div>');
	$("#cardbodyDis").append('<h4 class="card-title">Torzító/overdrive</h4>');

	$(".card-columns").append('<div class="card" id="cardW"></div>');
	$("#cardW").append('<img class="card-img-top" src="pics/categories/wah.jpg"></img>');
	$("#cardW").append('<div class="card-body" id="cardbodyW"><a href="products.php?category=18&page=1" class="stretched-link" name="linkW"></a></div>');
	$("#cardbodyW").append('<h4 class="card-title">Wah pedálok</h4>');

	$(".card-columns").append('<div class="card" id="cardD"></div>');
	$("#cardD").append('<img class="card-img-top" src="pics/categories/delay.jpg"></img>');
	$("#cardD").append('<div class="card-body" id="cardbodyD"><a href="products.php?category=19&page=1" class="stretched-link" name="linkD"></a></div>');
	$("#cardbodyD").append('<h4 class="card-title">Delay/reverb</h4>');

	$(".card-columns").append('<div class="card" id="cardE"></div>');
	$("#cardE").append('<img class="card-img-top" src="pics/categories/eq.jpg"></img>');
	$("#cardE").append('<div class="card-body" id="cardbodyE"><a href="products.php?category=20&page=1" class="stretched-link" name="linkE"></a></div>');
	$("#cardbodyE").append('<h4 class="card-title">Eq pedálok</h4>');

	$(".card-columns").append('<div class="card" id="cardTr"></div>');
	$("#cardTr").append('<img class="card-img-top" src="pics/categories/tremolo.jpg"></img>');
	$("#cardTr").append('<div class="card-body" id="cardbodyTr"><a href="products.php?category=21&page=1" class="stretched-link" name="linkTr"></a></div>');
	$("#cardbodyTr").append('<h4 class="card-title">Tremoló pedálok</h4>');

	$(".card-columns").append('<div class="card" id="cardFl"></div>');
	$("#cardFl").append('<img class="card-img-top" src="pics/categories/flanger.jpg"></img>');
	$("#cardFl").append('<div class="card-body" id="cardbodyFl"><a href="products.php?category=22&page=1" class="stretched-link" name="linkFl"></a></div>');
	$("#cardbodyFl").append('<h4 class="card-title">Phraser/flanger</h4>');

	$(".card-columns").append('<div class="card" id="cardSu"></div>');
	$("#cardSu").append('<img class="card-img-top" src="pics/categories/compressor.jpg"></img>');
	$("#cardSu").append('<div class="card-body" id="cardbodySu"><a href="products.php?category=23&page=1" class="stretched-link" name="linkSu"></a></div>');
	$("#cardbodySu").append('<h4 class="card-title">Compressor/sustainer</h4>');

	$(".card-columns").append('<div class="card" id="cardLo"></div>');
	$("#cardLo").append('<img class="card-img-top" src="pics/categories/looper.jpg"></img>');
	$("#cardLo").append('<div class="card-body" id="cardbodyLo"><a href="products.php?category=24&page=1" class="stretched-link" name="linkLo"></a></div>');
	$("#cardbodyLo").append('<h4 class="card-title">Looper pedálok</h4>');

	$(".card-columns").append('<div class="card" id="cardNo"></div>');
	$("#cardNo").append('<img class="card-img-top" src="pics/categories/noisegate.jpg"></img>');
	$("#cardNo").append('<div class="card-body" id="cardbodyNo"><a href="products.php?category=25&page=1" class="stretched-link" name="linkNo"></a></div>');
	$("#cardbodyNo").append('<h4 class="card-title">Zajzárak</h4>');

	$(".card-columns").append('<div class="card" id="cardPi"></div>');
	$("#cardPi").append('<img class="card-img-top" src="pics/categories/pitch.jpg"></img>');
	$("#cardPi").append('<div class="card-body" id="cardbodyPi"><a href="products.php?category=26&page=1" class="stretched-link" name="linkPi"></a></div>');
	$("#cardbodyPi").append('<h4 class="card-title">Pitch shifterek</h4>');

	$(".card-columns").append('<div class="card" id="cardV"></div>');
	$("#cardV").append('<img class="card-img-top" src="pics/categories/volume.jpg"></img>');
	$("#cardV").append('<div class="card-body" id="cardbodyV"><a href="products.php?category=27&page=1" class="stretched-link" name="linkV"></a></div>');
	$("#cardbodyV").append('<h4 class="card-title">Hangerő pedálok</h4>');
}

function AccesClick() {
	$(".content").empty();
	$(".content").append('<div class="card-columns"></div>');

	$(".card-columns").append('<div class="card" id="cardCas"></div>');
	$("#cardCas").append('<img class="card-img-top" src="pics/categories/case.jpg"></img>');
	$("#cardCas").append('<div class="card-body" id="cardbodyCas"><a href="products.php?category=28&page=1" class="stretched-link" name="linkCas"></a></div>');
	$("#cardbodyCas").append('<h4 class="card-title">Tokok</h4>');

	$(".card-columns").append('<div class="card" id="cardSt"></div>');
	$("#cardSt").append('<img class="card-img-top" src="pics/categories/strap.jpg"></img>');
	$("#cardSt").append('<div class="card-body" id="cardbodySt"><a href="products.php?category=29&page=1" class="stretched-link" name="linkSt"></a></div>');
	$("#cardbodySt").append('<h4 class="card-title">Hevederek</h4>');

	$(".card-columns").append('<div class="card" id="cardCab"></div>');
	$("#cardCab").append('<img class="card-img-top" src="pics/categories/cable.jpg"></img>');
	$("#cardCab").append('<div class="card-body" id="cardbodyCab"><a href="products.php?category=30&page=1" class="stretched-link" name="linkCab"></a></div>');
	$("#cardbodyCab").append('<h4 class="card-title">Kábelek</h4>');

	$(".card-columns").append('<div class="card" id="cardTu"></div>');
	$("#cardTu").append('<img class="card-img-top" src="pics/categories/tuner.jpg"></img>');
	$("#cardTu").append('<div class="card-body" id="cardbodyTu"><a href="products.php?category=31&page=1" class="stretched-link" name="linkTu"></a></div>');
	$("#cardbodyTu").append('<h4 class="card-title">Hangológépek</h4>');

	$(".card-columns").append('<div class="card" id="cardPic"></div>');
	$("#cardPic").append('<img class="card-img-top" src="pics/categories/pick.jpg"></img>');
	$("#cardPic").append('<div class="card-body" id="cardbodyPic"><a href="products.php?category=32&page=1" class="stretched-link" name="linkPic"></a></div>');
	$("#cardbodyPic").append('<h4 class="card-title">Pengetők</h4>');

	$(".card-columns").append('<div class="card" id="cardSta"></div>');
	$("#cardSta").append('<img class="card-img-top" src="pics/categories/stand.jpg"></img>');
	$("#cardSta").append('<div class="card-body" id="cardbodySta"><a href="products.php?category=33&page=1" class="stretched-link" name="linkSta"></a></div>');
	$("#cardbodySta").append('<h4 class="card-title">Állványok</h4>');
}

function PartClick() {
	$(".content").empty();
	$(".content").append('<div class="card-columns"></div>');

	$(".card-columns").append('<div class="card" id="cardPu"></div>');
	$("#cardPu").append('<img class="card-img-top" src="pics/categories/pickup.jpg"></img>');
	$("#cardPu").append('<div class="card-body" id="cardbodyPu"><a href="products.php?category=34&page=1" class="stretched-link" name="linkPu"></a></div>');
	$("#cardbodyPu").append('<h4 class="card-title">Hangszedők</h4>');

	$(".card-columns").append('<div class="card" id="cardE"></div>');
	$("#cardE").append('<img class="card-img-top" src="pics/categories/electronics.jpg"></img>');
	$("#cardE").append('<div class="card-body" id="cardbodyE"><a href="products.php?category=35&page=1" class="stretched-link" name="linkE"></a></div>');
	$("#cardbodyE").append('<h4 class="card-title">Elektronikák</h4>');

	$(".card-columns").append('<div class="card" id="cardBr"></div>');
	$("#cardBr").append('<img class="card-img-top" src="pics/categories/bridge.jpg"></img>');
	$("#cardBr").append('<div class="card-body" id="cardbodyBr"><a href="products.php?category=36&page=1" class="stretched-link" name="linkBr"></a></div>');
	$("#cardbodyBr").append('<h4 class="card-title">Húrlábak/hidak</h4>');

	$(".card-columns").append('<div class="card" id="cardK"></div>');
	$("#cardK").append('<img class="card-img-top" src="pics/categories/key2.jpg"></img>');
	$("#cardK").append('<div class="card-body" id="cardbodyK"><a href="products.php?category=37&page=1" class="stretched-link" name="linkK"></a></div>');
	$("#cardbodyK").append('<h4 class="card-title">Hangolókulcsok</h4>');

	$(".card-columns").append('<div class="card" id="cardNu"></div>');
	$("#cardNu").append('<img class="card-img-top" src="pics/categories/nut.jpg"></img>');
	$("#cardNu").append('<div class="card-body" id="cardbodyNu"><a href="products.php?category=38&page=1" class="stretched-link" name="linkNu"></a></div>');
	$("#cardbodyNu").append('<h4 class="card-title">Nyergek</h4>');
}

function RegClick(){
	$(".content").empty();

	$(".content").empty();
	$(".content").append('<form id="form" class="bg-light" method="post" action="regvalidate.php" onsubmit="return formValidate(this)"></form>');

	$("#form").append('<div class="form-group" id="lastnamediv"></div>');
	$("#lastnamediv").append('<label for="lastname">Vezetéknév:</label>');
	$("#lastnamediv").append('<input type="text" class="form-control" id="lastname" placeholder="Írja be a vezetéknevét!" name="lastname" onkeyup="lastnameValidate()" required>');

	$("#form").append('<div class="form-group" id="firstnamediv"></div>');
	$("#firstnamediv").append('<label for="firstname">Keresztnév:</label>');
	$("#firstnamediv").append('<input type="text" class="form-control" id="firstname" placeholder="Írja be a keresztnevét!" name="firstname" onkeyup="firstnameValidate()" required>');

	$("#form").append('<div class="form-group" id="emaildiv"></div>');
	$("#emaildiv").append('<label for="email">E-mail cím:</label>');
	$("#emaildiv").append('<input type="text" class="form-control" id="email" placeholder="Írja be e-mail címét!" name="email" onkeyup="emailValidate()" required>');

	$("#form").append('<div class="form-group" id="pswddiv"></div>');
	$("#pswddiv").append('<label for="pswd">Jelszó (legalább 8 karakter, tartalmazzon kis és nagybetűt, valamint számot):</label>');
	$("#pswddiv").append('<input type="password" class="form-control" id="pswd" placeholder="Írja be a jelszót!" name="pswd" onkeyup="pswdValidate()" required>');
	$("#form").append('<div class="form-group" id="pswddiv2"></div>');
	$("#pswddiv2").append('<label for="pswd2">Jelszó megerősítése:</label>');
	$("#pswddiv2").append('<input type="password" class="form-control" id="pswd2" placeholder="Írja be újra a jelszót!" name="pswd2" onkeyup="pswdValidate()" required>');

	$("#form").append('<div class="form-group form-check" id="checkdiv"></div>');
	$("#checkdiv").append('<label class="form-check-label" id="checkboxlabel"></label>');
	$("#checkboxlabel").append('<input class="form-check-input" type="checkbox" id="privacy" name="privacy" required>Az <a href="adnyil.php">adatkezelési nyilatkozatot</a> elolvastam, az abban foglaltakkal egyetértek.');

	$("#form").append('<button type="submit" name="submit" class="btn btn-primary">Küldés</button>');
}
