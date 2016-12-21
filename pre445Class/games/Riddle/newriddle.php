<?php

include 'connect.php'; 

echo '
<!doctype html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<title>Riddle Search</title>
	<meta name="description" content="form for searching for a set of riddles">
    
	<meta name="author" content="Susan Hirsch" />
    <link href="/~smhirsch/RiddleGame/susan.css" rel="stylesheet" type="text/css" /> 
    
    </head>
        <body style="background-color:#9881E3;">
        
           <div id="container">
               <div id="title">
                   <div id="titleText">Audemes</div>
               </div>
           <div id="menu">
                <ul>    
                    <li><a href="/~smhirsch/RiddleGame/default.php" class="current">About<br><span></span></a></li>
                    <li><a href="/~smhirsch/RiddleGame/forms/riddle_search.php">Game<br><span></span></a></li>
                    <li><a href="/~smhirsch/RiddleGame/admin_default.php">Admin<br><span></span></a></li>
                </ul>
                
            </div>
		<div id="riddlesearchcon" style="width: 600px">
    
		    <h2 style="margin-top: 10px;">Upload a New Audeme Riddle</h2>
            <form action="handler_newriddle.php" method="post" enctype="multipart/form-data">
                
               <p>Before uploading your files, please be sure they are in <b>mp3</b> format only, and are less than one minute long.  
               </p><br />
                audeme riddle file: <input type="file" name="riddlefile" />  <br />
                spoken answer file: <input type="file" name="answerfile" /> <br />
                
           
            
            
         <h3>Riddle Information</h3>
    	    
                  <p>
    		        title (e.g., geothermal, chemical reaction)   <input size="45" type="text" name="audeme" placeholder="use all lowercase except for proper nouns" /> <br />
                    What level is this riddle? 
                        <ul style="list-style-type: none;">
                                <li><input type="radio" name="points" value="100">First through Fourth grade</li>
                                <li><input type="radio" name="points" value="200">Fifth through Eighth grade</li>
                                <li><input type="radio" name="points" value="300">Ninth through Twelfth grade</li>
                        </ul><br />
                    Into which category should we place this riddle? (You may select more than one if necessary.)<br />
                        <ul style="list-style-type: none;">
                                <li><input type="checkbox" name="id_category" value="1">Astronomy</li>
                                <li><input type="checkbox" name="id_category" value="2">Biology</li>
                                <li><input type="checkbox" name="id_category" value="3">Chemistry</li>
                                <li><input type="checkbox" name="id_category" value="4">Energy</li>
                                <li><input type="checkbox" name="id_category" value="6">General Science</li>
                                <li><input type="checkbox" name="id_category" value="5">Geology</li>
                                <li><input type="checkbox" name="id_category" value="8">Physics</li>
                                <li><input type="checkbox" name="id_category" value="7">Zoology</li>
                         </ul>
                    
            <br />
            <br />
                        <input type="submit" value="Submit">
		        </p>
    
            </form>
  
  
  
    <!-- end .content --></div>
		    
        </div>
     </div>
  
     
     
  </body>';

?>