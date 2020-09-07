function addCartItem(){
  var quantity=document.getElementById("quantity").value;
  $.ajax({
    url:'cart.php',
    data:{cartFunction: 'addItem', quantity: quantity},
    type:'post',
    success: function(output){
      console.log(output);
    }
  });
}
function removeCartItem(i){
  $.ajax({
    url:'cart.php',
    data:{cartFunction: 'removeItem', index: i},
    type:'post',
    success: function(){
      location.reload();
    }
  });
}
