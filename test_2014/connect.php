<?php
    
$host = 'localhost';
$username = 'audemedbuser';
$password = 'pirates jasmin apexes nievelt bismite1!';
$target = 'audeme_db_2014';
$port = '';
//set up the link
$link = mysqli_connect($host,$username,$password,$target);
if (!$link){ 
        echo ('Unable to connect to the database');
    }



//REMOVE ABOVE IF USING AS AN INCLUDES FILE IN PROJECT, FROM IF(!$link)...
//mysqli_close($link);  
//ADD THIS AT THE END OF CODE ON EACH PAGE.


?>