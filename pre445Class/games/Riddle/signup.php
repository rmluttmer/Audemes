
<?php
include 'connect.php';
require 'PasswordHash.php';
$hasher = new PasswordHash(8, false);

    
    
echo "

<html>
    <head>
        <title>My HTML Form</title>
    </head>
    
    <body>
    
        <form action='handler_new_account.php' method='post'>
        <table>
            
            <tr>
                <td>Please enter a username</td>
                <td><input type='text' name ='user_name' size='50' ></td>  <!-- the value was added so the user won't have to re-type it after they've entered it once-->
            </tr>
            
            <tr>
                <td>Please enter password</td>
                <td><input type='password' name ='password' size='50'></td>
            </tr>
            
            <tr>
                <td></td>
                <td><input type='submit' value ='Submit'></td>
            </tr>
            
       </table>
       </form>
       
    </body>
   
</html>";




mysqli_close($link);
?>
