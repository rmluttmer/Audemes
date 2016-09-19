<?php
include 'connect.php'; 

echo '
<!doctype html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<title>Riddle Search</title>
	<meta name="description" content="form for entering new audeme riddle information">
    
	<meta name="author" content="Susan Hirsch" />
    <link href="/games/Riddle/susan.css" rel="stylesheet" type="text/css"> 
    
    </head>
        <body class="riddlebody">
        
           <div id="container">
            
                <form id="riddlesearchcon" action="handler_riddle_search.php" method="post">
                                       
                    <p>Welcome to the Audeme Riddle Game! </p>     
                            <ul style="list-style-type: none;">
                                    <li><b>Select a Grade Level</b></li><br />
                                    <li><input type="radio" name="points" value="all" checked="checked">All</li>
                                    <li><input type="radio" name="points" value="100">First through Fourth grade</li>
                                    <li><input type="radio" name="points" value="200">Fifth through Eighth grade</li>
                                    <li><input type="radio" name="points" value="300">Ninth through Twelfth grade</li>
                            </ul>
                              
                        
                            <ul style="list-style-type: none;">
                                    <li><b>Select a Category</b></li><br />
                                    <li><input type="radio" name="id_category" value="all" checked="checked">All</li>
                                    <li><input type="radio" name="id_category" value="1">Astronomy</li>
                                    <li><input type="radio" name="id_category" value="2">Biology</li>
                                    <li><input type="radio" name="id_category" value="3">Chemistry</li>
                                    <li><input type="radio" name="id_category" value="4">Energy</li>
                                    <li><input type="radio" name="id_category" value="6">General Science</li>
                                    <li><input type="radio" name="id_category" value="5">Geology</li>
                                    <li><input type="radio" name="id_category" value="8">Physics</li>
                                    <li><input type="radio" name="id_category" value="7">Zoology</li>
                            </ul>
                        
                     
                            <ul style="list-style-type: none;">
                                    <li><b>How many players?</b></li><br />
                                    <li><input type="radio" name="players" value="1" checked="checked">Single Player</li>
                                    <li><input type="radio" name="players" value="2">Two Teams</li>
                            </ul>
                           <br />
                        
         
                        <div>
                            <input type="submit" value="Create Game!" style="margin-left: 50px;">
                        </div>
         
                </form>
                
         </div> <!-- end container -->
         
         
        
       </body>
           
    ';


?>