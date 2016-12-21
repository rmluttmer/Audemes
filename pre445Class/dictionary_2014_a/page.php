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

$sqlaudeme='(SELECT audeme.audeme_id, filename, title, description, audeme.category_id FROM audeme, category WHERE audeme.category_id = category.category_id AND title LIKE "'.$search_string.'%" AND audeme.category_id LIKE "'. $category. '" AND difficulty LIKE "'. $difficulty. '" AND atomic LIKE "'. $atomic. '")'
. 'UNION'. '(SELECT audeme.audeme_id, filename, title, description, audeme.category_id FROM audeme, tagmap WHERE audeme.audeme_id=tagmap.audeme_id AND tag LIKE "'. $search_string. '%" AND audeme.category_id LIKE "'. $category. '" AND difficulty LIKE "'. $difficulty. '" AND atomic LIKE "'. $atomic. '")';


$audeme = mysqli_query($link,$sqlaudeme);
$rows = mysqli_num_rows($audeme);
$pages = ceil($rows/$item_per_page);   
$pagination = '';

if($pages > 1)
{
    $pagination .= '<ul class="paginate">';
    for($i = 1; $i<$pages+1; $i++)
    {
        $pagination .= '<li><a href="#" class="paginate_click" id="'.$i.'-page">'.$i.'</a></li>';
    }
    $pagination .= '</ul>';
}

 echo $pagination;

mysqli_close($link);
?>


   
    
    
    
