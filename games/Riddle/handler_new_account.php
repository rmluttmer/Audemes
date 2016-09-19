<?php
include 'connect.php';
require 'PasswordHash.php';
$password = $_POST["password"];
$user_name = $_POST["user_name"];
$hasher = new PasswordHash(8, false);
$hash = $hasher->HashPassword($password);
$errors = array();

if (strlen($password) > 72) 
       { 
            die('Password must be 72 characters or less'); 
            
       }

if (strlen($hash) >= 20) 
{

    $query =  "INSERT INTO users (user_name, hash) VALUES ('" . $user_name . "','" . $hash . "');";

echo $query;
mysqli_query($link, $query);
}

else
{
    //something went wrong
    echo "error: please create a new username and password.";  
}


echo $hash;

mysqli_close($link);
?>