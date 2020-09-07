function cartFormValidate(){
	if (zipCartValidate()&&addressCartValidate()){
		return true;
	}
	else{
		return false;
	}
}

function zipCartValidate(){
	var iranyitoSzam=document.getElementsByName("zipCart")[0];
	if (iranyitoSzam.value>=1000 && iranyitoSzam.value<=9999){
		document.getElementById("zipCart").style.borderColor="lightgreen";
    return true;
	}
	else{
		document.getElementById("zipCart").style.borderColor="red";
    return false;
	}
}

function addressCartValidate(){
  var addr=document.getElementsByName("addressCart")[0];
  var regex=/^\s*\S+(?:\s+\S+){2}/;
  if (addr.value.match(regex)){
    document.getElementById("addressCart").style.borderColor="lightgreen";
    return true;
  }
  else{
    document.getElementById("addressCart").style.borderColor="red";
    return false;
  }
}
