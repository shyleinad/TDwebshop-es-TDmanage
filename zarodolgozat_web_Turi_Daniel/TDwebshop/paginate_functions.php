<?php
  function nextPage(){
    if ($_GET['page']!=$_SESSION['totalPages']){
      return $_GET['page']+1;
    } else{
      return $_GET['page'];
    }
  }
  function prevPage(){
    if ($_GET['page']>1){
      return $_GET['page']-1;
    }
    return $_GET['page'];
  }
  function firstPage(){
    return 1;
  }
  function lastPage(){
    return $_SESSION['totalPages'];
  }
?>
