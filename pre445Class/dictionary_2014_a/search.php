<?php
 
include "../../includes/credential.php";

$link = mysqli_connect($host,$username,$password,$target);
if (!$link){ 
        echo ('Unable to connect to the database');
    }
if($_POST['by_category']==0){	
$search_string = preg_replace("/[^A-Za-z0-9]/", " ", $_POST['query']);
$search_string = mysqli_real_escape_string($link, $search_string);}
else $search_string = '%';
$category = $_POST['category']==0? '%': $_POST['category'];
$difficulty = $_POST['difficulty']==0? '%': $_POST['difficulty'];
$atomic = $_POST['atomic']==0?'%':$_POST['atomic'];
$page_number = filter_var($_POST["page"], FILTER_SANITIZE_NUMBER_INT, FILTER_FLAG_STRIP_HIGH);
if(!is_numeric($page_number)){die('Invalid page number!');}
$page_number -= 1;

$item_per_page=10;

$sqlaudeme='(SELECT audeme.audeme_id, filename, title, description, audeme.category_id, name FROM audeme, category WHERE audeme.category_id = category.category_id AND title LIKE "'.$search_string.'%" AND audeme.category_id LIKE "'. $category. '" AND difficulty LIKE "'. $difficulty. '" AND atomic LIKE "'. $atomic. '")'
. 'UNION'. '(SELECT audeme.audeme_id, filename, title, description, audeme.category_id, name FROM audeme, tagmap, category WHERE audeme.audeme_id=tagmap.audeme_id AND tag LIKE "'. $search_string. '%" AND audeme.category_id LIKE "'. $category. '" AND difficulty LIKE "'. $difficulty. '" AND atomic LIKE "'. $atomic. '")';


$audeme = mysqli_query($link,$sqlaudeme);

$position = ($page_number * $item_per_page);
$sqlaudeme.='LIMIT '.$position.', '.$item_per_page;
$results = mysqli_query($link,$sqlaudeme);

while($render = mysqli_fetch_array($results)) {
  echo "<div class='resultpanel border'>";
 //echo "<h4>" . $audemes['filename'] . "</td>";
  echo "<h4>" . $render['title'] . "</h4>";
  
  echo "<audio controls>";
  //echo "<source src='../AudemeOGGs/". $audemes['filename'] .".ogg' type='audio/ogg'>";
  echo "<source src='../AudemeMP3s/". $render['filename'] .".mp3' type='audio/mpeg'>";
  echo "</audio>";
  echo "<p><strong>Description: </strong>".$render['description'] . "</p>";
  echo "<p><strong>Category: </strong>". $render['name']."</p>";
  echo "<strong style='float:left;'>Tags: </strong>";

  echo "<ul>";
	$sql='SELECT tag FROM tagmap WHERE audeme_id='.$render['audeme_id'];
	$tag = mysqli_query($link,$sql);
	while($tags =  mysqli_fetch_array($tag)){
		  echo "<li class='tag'><a class='tag_click'>".$tags['tag']."</a></li>";

	}
  
  echo "</ul>";
  echo "<div class='clear'></div>";
  

  echo "</div>";
}

/*
*/

mysqli_close($link);
?>


   
    
    
    
