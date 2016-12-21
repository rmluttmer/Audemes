<?php
include 'connect.php';
require 'PasswordHash.php';
$hasher = new PasswordHash(8, false);

    
    
echo '<body>
    <form action="handler_new_account.php" method="post">
    
    
        <p>
    		username   <input type="text" name="user_name" placeholder="first name" /> <br />
        <p>
    		password   <input type="text" name="password" placeholder="password" /> <br /> 
                        <input type="submit">       
    
    </form>';




mysqli_close($link);
?>


   
    
    
    
