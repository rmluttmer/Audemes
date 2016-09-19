<?php
include 'connect.php';
require 'PasswordHash.php';
include 'password_handler.php';


echo '<body>
    <form action="form_handler.php" method="post">
    
    
    <p>
    		username   <input type="text" name="user_name" placeholder="first name" /> <br />
     <p>
    		password   <input type="password" name="password" placeholder="password" /> <br /> 
     <input type="submit">       
    
    </form>';





mysqli_close($link);
?>


   
    
    
    
