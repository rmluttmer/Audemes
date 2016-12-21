<html>
 <head>
  <title>PHP Test</title>
 </head>
 <body>
 <?php echo '<p>Hello World</p>'; ?>
<?php
// Create connection

$password=file_get_contents("../riddlesuser_passwd.txt");
$con=mysqli_connect("localhost","riddlesuser",$password,"riddles_db");

// Check connection
if (mysqli_connect_errno($con))
  {
  echo "Failed to connect to MySQL: " . mysqli_connect_error();
  }
else
  { echo "Success!";
  }
?> 
 </body>
</html>