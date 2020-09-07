function formValidate(form){
  if (lastnameValidate()&&firstnameValidate()&&emailValidate()&&pswdValidate()){
    return true;
  }
  else{
    return false;
  }
}

function lastnameValidate(){
	var nev=document.getElementsByName("lastname")[0].value;
	nev=nev.trim();
	if (nev.length>=2 && isNaN(nev[0])){
		document.getElementById("lastname").style.border="3px solid lightgreen";
    return true;
	}
	else{
		document.getElementById("lastname").style.border="3px solid red";
    return false;
	}
}

function firstnameValidate(){
	var nev=document.getElementsByName("firstname")[0].value;
	nev=nev.trim();
	if (nev.length>=2 && isNaN(nev[0])){
		document.getElementById("firstname").style.border="3px solid lightgreen";
    return true;
	}
	else{
		document.getElementById("firstname").style.border="3px solid red";
    return false;
	}
}

function emailValidate(){
	var email=document.getElementsByName("email")[0];
	let minta=/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
	if (email.value.match(minta)){
		document.getElementById("email").style.border="3px solid lightgreen";
    return true;
	}
	else{
		document.getElementById("email").style.border="3px solid red";
    return false;
	}
}

function pswdValidate(){
	let tartalmazSzam=false;
	let tartalmazKisBetut=false;
	let tartalmazNagyBetut=false;
	var jelszo=document.getElementsByName("pswd")[0].value;
	var jelszoUjra=document.getElementsByName("pswd2")[0].value;
	for (let i=0; i<jelszo.length; i++){
		if (!isNaN(jelszo[i])){
			tartalmazSzam=true;
		}
		else{
			if (jelszo[i]==jelszo[i].toLowerCase()){
				tartalmazKisBetut=true;
			}
			if (jelszo[i]==jelszo[i].toUpperCase()){
				tartalmazNagyBetut=true;
			}
		}
	}
	if (jelszo.length>=8 && tartalmazSzam==true && tartalmazKisBetut==true && tartalmazNagyBetut==true){
		document.getElementById("pswd").style.border="3px solid lightgreen";
    //Megerősített jelszó ellenőrzése
    if (jelszoUjra==jelszo){
      document.getElementById("pswd2").style.border="3px solid lightgreen";
      return true;
    }
    else{
      document.getElementById("pswd2").style.border="3px solid red";
      return false;
    }
	}
	else{
		document.getElementById("pswd").style.border="3px solid red";
    document.getElementById("pswd2").style.border="3px solid red";
    return false;
	}
}
