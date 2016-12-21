<?php

$host = 'localhost';
$username = 'riddlesuser';
$password = 'immun unmoors squints gray pitt';
$db = 'riddles_db';
$port = '';
//set up the link
$link = mysqli_connect($host, $username, $password, $db);

if(!$link) {
   die('Could not connect to database');
//} else {
    echo "connected successfully :D";
}

//REMOVE ABOVE IF USING AS AN INCLUDES FILE IN PROJECT, FROM IF(!$link)...
//mysqli_close($link);  
//ADD THIS AT THE END OF CODE ON EACH PAGE.


?>