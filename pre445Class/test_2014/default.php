<?php
 
include "../../includes/connect.php";

$sql="SELECT * FROM audeme";
$result = mysqli_query($link,$sql);


echo "<br><br>Audeme list<br><br>";
echo "<table border='1'>
<tr>
<th>audeme_id</th>
<th>filename</th>
<th>title</th>
<th>category_id</th>
<th>description</th>
<th>hint</th>
<th>difficulty</th>
<th>atomic</th>
</tr>";

while($row = mysqli_fetch_array($result)) {
  echo "<tr>";
  echo "<td>" . $row['audeme_id'] . "</td>";
  echo "<td>" . $row['filename'] . "</td>";
  echo "<td>" . $row['title'] . "</td>";
  echo "<td>" . $row['category_id'] . "</td>";
  echo "<td>" . $row['description'] . "</td>";
  echo "<td>" . $row['hint'] . "</td>";
  echo "<td>" . $row['difficulty'] . "</td>";
  echo "<td>" . $row['atomic'] . "</td>";
  echo "</tr>";
}
echo "</table>";

echo "<br><br>All tags for 'airplane'<br><br>";
$sql="SELECT tag FROM tagmap WHERE audeme_id='12'";
$result = mysqli_query($link,$sql);
while($row = mysqli_fetch_array($result)) {
	echo " ".$row['tag']." ";
}

mysqli_close($link);
?>


   
    
    
    
