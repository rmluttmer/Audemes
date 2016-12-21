<?php
include 'connect.php';

echo "<!doctype html>
                <html lang=\"en\">
                <head>
	                <meta charset=\"utf-8\">
	                <title> Audeme Riddle Challenge</title>
	                <meta name=\"description\" content=\"audeme riddle game's dynamically populated set based on a user search \">
    
	                <meta name=\"author\" content=\"Susan Hirsch\" />
                    <link href=\"/games/Riddle/susan.css\" rel=\"stylesheet\" type=\"text/css\"> 
                    <script src=\"/js/jquery-1.10.2.min.js\"></script>
           
                    <script>
                        function changeVisibleDiv(divID, direction)
                        {
                           var myDivID = parseInt(divID);
                            var visibleID;
                            
                            if (direction == 'up')
                            {
                            visibleID = myDivID +1;
                            }
                            if (direction == 'down')
                            {
                            visibleID = myDivID -1;
                            }
                         visibleID = '#' + visibleID;
                         divID = '#' + divID;
                         
                         $(visibleID).removeClass('invisible');
                         $(divID).addClass('invisible');
                        }
                    </script>
    
                </head>
                    
                
                <body class=\"riddlebody\">
                        <h2 style=\"margin-left:15px;\">Your set has been created. Good luck!</h2> 
                        <p style=\"margin:15px;\">Back to <a href=\"http://audemes.org/games/Riddle/forms/riddle_search.php\"> Game Setup</a> ";
                        
#region "begin (if) statement for cookie to track team points"                        
if ($_POST['players'])
        {
           if ($_POST['players'] == '2')
           {                       
                       
                if (!isset($_COOKIE['pointsgained1'])) {

                setcookie('pointsgained1', 0, time() + 3600 * 24 * 365);
                //echo "cookie was set with : ".intval($_COOKIE['points'])." points<br/>";
                $points1 = 0;
                } else {

                //echo "cookies! :{$_COOKIE['points']}<br/>";
                $points1 = $_COOKIE['pointsgained1'];//set point=cookie value which will be used if it's incorrect
                }



    
                if (isset($_POST['correct']) && strcmp($_POST['correct'], '1') == 0) 
                    {   //if correct, add the cookie value+points just gained since the cookie will not be reloaded
                $points1 = $points1 + $_POST['pointsgained1'];

                setcookie('pointsgained1', NULL);
                setcookie('pointsgained1', $_COOKIE['pointsgained1'], time() - 3600);

                setcookie('pointsgained1', $points1, time()+ 8*3600);


                }
    
                    //point total div and reset points button
                if (isset($_POST['resetcookie1']))
                    {
                        setcookie('pointsgained1', NULL);
                setcookie('pointsgained1', $_COOKIE['pointsgained1'], time() - 3600);
                        $points1 = 0;	
                    setcookie('pointsgained1', 0, time()+(60*60*24*90));
                //resets cookie with "0"
                    }
                    
                    
         //two teams, team 2's points cookie   ----------------------------------------------        
                    
                    
                    if (!isset($_COOKIE['pointsgained2'])) {

                setcookie('pointsgained2', 0, time() + 3600 * 24 * 365);
                //echo "cookie was set with : ".intval($_COOKIE['points'])." points<br/>";
                $points2 = 0;
                } else {

                //echo "cookies! :{$_COOKIE['points']}<br/>";
                $points2 = $_COOKIE['pointsgained2'];//set point=cookie value which will be used if it's incorrect
                }


    
                if (isset($_POST['correct']) && strcmp($_POST['correct'], '2') == 0) 
                    {   //if correct, add the cookie value+points just gained since the cookie will not be reloaded
                $points2 = $points2 + $_POST['pointsgained2'];

                setcookie('pointsgained2', NULL);
                setcookie('pointsgained2', $_COOKIE['pointsgained2'], time() - 3600);

                setcookie('pointsgained2', $points2, time()+ 8*3600);


                }
    
                    //point total div and reset points button
                if (isset($_POST['resetcookie2']))
                    {
                        setcookie('pointsgained2', NULL);
                setcookie('pointsgained2', $_COOKIE['pointsgained2'], time() - 3600);
                        $points2 = 0;	
                    setcookie('pointsgained2', 0, time()+(60*60*24*90));
                //resets cookie2 with "0"
                    }


            

            }
#endregion
#region "begin (else) for cookie to track one user's points"            
else
    {



        #region "cookie to track one user's points"
        if (!isset($_COOKIE['pointsgained'])) {

        setcookie('pointsgained', 0, time() + 3600 * 24 * 365);
        //echo "cookie was set with : ".intval($_COOKIE['points'])." points<br/>";
        $points = 0;
        } else {

        //echo "cookies! :{$_COOKIE['points']}<br/>";
        $points = $_COOKIE['pointsgained'];//set point=cookie value which will be used if it's incorrect
        }



    
        if (isset($_POST['correct']) && strcmp($_POST['correct'], '1') == 0) 
            {   //if correct, add the cookie value+points just gained since the cookie will not be reloaded
        $points = $points + $_POST['pointsgained'];

        setcookie('pointsgained', NULL);
        setcookie('pointsgained', $_COOKIE['pointsgained'], time() - 3600);

        setcookie('pointsgained', $points, time()+ 8*3600);


        }
    
            //point total div and reset points button
        if (isset($_POST['resetcookie']))
            {
                setcookie('pointsgained', NULL);
        setcookie('pointsgained', $_COOKIE['pointsgained'], time() - 3600);
                $points = 0;	
            setcookie('pointsgained', 0, time()+(60*60*24*90));
        //resets cookie with "0"
            }
    
    
#endregion


    }
}
#endregion                      
  
//main riddle search logic
#region "search filter"
    $query = 'SELECT * FROM riddles JOIN cat_rid_rel on riddles.id_riddle = cat_rid_rel.id_riddle JOIN category 
on cat_rid_rel.id_category = category.id_category';
    $filterCount = 0;


        if ($_POST['points'])
        {
            if ($_POST['points'] != 'all')
            {
                if ($filterCount == 0) 
                {
           
                    $query.=" WHERE ";
                }
                else 
                {
                    $query.=" AND ";
                }
                $query.='points=' . $_POST['points'];
                $filterCount += 1;
        }
    }
    
        if ($_POST['id_category'])
        {
           if ($_POST['id_category'] != 'all')
           {
                if ($filterCount == 0) 
                {
            
                    $query.=" WHERE ";
                }
                else 
                {
                    $query.=" AND ";
                }
                $query.="cat_rid_rel.id_category LIKE '" . $_POST['id_category']."'";
                $filterCount += 1;
            }
        }
        //$query.=" ORDER BY RAND() LIMIT 25;";
    #endregion
    
#region "pointboard"   
    if ($_POST['players'])
        {
           if ($_POST['players'] == '2')
           {
                
                    echo "<div id=\"pointboard2\"><br /><b>&nbsp;&nbsp; Team One: ".$points1." </b><br /> 
                            <form method=\"post\" action=\"handler_riddle_search.php\">
                            <input type=\"hidden\" value=\"{$_POST['id_category']}\" name=\"id_category\" />
                            <input type=\"hidden\" value=\"{$_POST['points']}\" name=\"points\" />
                            <input type=\"hidden\" value=\"{$points1}\" name=\"points1\" />
                            <input type=\"hidden\" value=\"{$_POST['players']}\" name=\"players\" />
                            <input type=\"hidden\" value=\"Y\" name=\"resetcookie1\" />
                            <input id=\"resetbtn1\" type=\"submit\" value=\"RESET POINTS\">
                            </form>
            
                            <br /><b>&nbsp;&nbsp; Team Two: ".$points2." </b><br /> 
                            <form method=\"post\" action=\"handler_riddle_search.php\">
                            <input type=\"hidden\" value=\"{$_POST['id_category']}\" name=\"id_category\" />
                            <input type=\"hidden\" value=\"{$_POST['points']}\" name=\"points\" />
                            <input type=\"hidden\" value=\"{$points2}\" name=\"points2\" />
                            <input type=\"hidden\" value=\"{$_POST['players']}\" name=\"players\" />
                            <input type=\"hidden\" value=\"Y\" name=\"resetcookie2\" />
                            <input id=\"resetbtn2\" type=\"submit\" value=\"RESET POINTS\">
                            </form>
                            </div>";
            }
                
            else 
            {
                    echo "<div id=\"pointboard\"><br /><b>&nbsp;&nbsp; Your Points: ".$points." </b><br /> 
                            <form method=\"post\" action=\"handler_riddle_search.php\">
                            <input type=\"hidden\" value=\"{$_POST['id_category']}\" name=\"id_category\" />
                            <input type=\"hidden\" value=\"{$_POST['points']}\" name=\"points\" />
                            <input type=\"hidden\" value=\"{$_POST['players']}\" name=\"players\" />
                            <input type=\"hidden\" value=\"Y\" name=\"resetcookie\" />
                            <input id=\"resetbtn\" type=\"submit\" value=\"RESET POINTS\">
                            </form></div>";
             }
                
         }
    
    #endregion 
    
    
           
//filter to display selected category and level once on top
#region "selection information"
        if ($_POST['id_category'])
        {
           if ($_POST['id_category'] != 'all')
           {
                $results = mysqli_query($link, $query);
                $row = mysqli_fetch_array($results, MYSQLI_ASSOC); 
                    echo "<div class=\"container\">
                        <h3 id=\"resultinfo\">{$row['category_name']} Riddles ";
            }
           
            else 
            {
                echo "<div class=\"container\">
                        <h3 id=\"resultinfo\">All Categories ";
             }
                
         }
       
        
        
        if ($_POST['points'])
        {
           if ($_POST['points'] != 'all')
           {
                $results = mysqli_query($link, $query);
                $row = mysqli_fetch_array($results, MYSQLI_ASSOC); 
                    echo "for {$row['points']}</h3>";
            }
                
            else 
            {
                echo ", All Levels</h3>";
             }
                
         }
        
  #endregion      
        
        
//show riddles, results of search
#region "show results for 2 player or teams style"

if ($_POST['players'])
        {
           if ($_POST['players'] == '2')
           {
                
                    
                if ($results = mysqli_query($link, $query)) 
                {
                    $numbering = 0;
                    $numRows = mysqli_num_rows($results);
                    while ($row = mysqli_fetch_array($results, MYSQLI_ASSOC)) 
                    {
        
                    //print_r($query);
        
                        $numbering += 1;
                        echo "<body>

                            <div class=\"box\">

                                <div style=\"margin: 20px; line-height: 20px;\">"; 
                                    
                                            if ( isset($_GET["Index"]) )
                                            {
                                                if ( ( $numbering - 1 ) == $_GET["Index"])
                                                {
                                                    echo "<div id=\"".$numbering."\">";
                                                }
                                                else
                                                 {
                                                    echo "<div class=\"invisible\" id=\"".$numbering."\">";
                                                }
                                            }
                                            else
                                            {
                                                if ($numbering == 1)
                                                {
                                                    echo "<div id=\"".$numbering."\">";
                                                }
                                                else
                                                {
                                                    echo "<div class=\"invisible\" id=\"".$numbering."\">";
                                                }
                                            }                
            
                                   
                                               echo "<h3 style=\"padding: 15px; font-size: 20px; color: #FFFFFF;\">" . $numbering . ". {$row['category_name']} Riddle ({$row['points']}):</h3>
    
                                                <audio id=\"riddle_challenge\" controls=\"controls\" preload=\"none\">
                                                    <source src=\"../mp3s/{$row['riddle']}\">Your browser does not support the audio element.
                                                </audio><br />
                                        
                                                <h3 style=\"padding: 15px; font-size: 20px; color: #FFFFFF;\">Answer:</h3>
                                                <audio id=\"riddle_answer\" controls=\"controls\" preload=\"none\">
                                                    <source src=\"../mp3s/{$row['answer']}\">Your browser does not support the audio element.
                                                </audio><br /><br />
                                        
                                                <p style=\"color: #FFFFFF;\">Which team got it right? <br /> 
                                                    <form method='post' action=\"handler_riddle_search.php?Index=$numbering\">
                                                        <p style=\"color: #FFFFFF;\">
                                                            <input style=\"color: #FFFFFF;\" type=\"radio\" name=\"correct\" value=\"1\" />Team 1
                                                            <input style=\"color: #FFFFFF;\" type=\"radio\" name=\"correct\" value=\"2\" />Team 2
                                                            <!--<input style=\"color: #FFFFFF;\" type=\"radio\" name=\"correct\" value=\"0\" />Neither-->
                                                            <input type=\"hidden\" value=\"{$row['id_riddle']}\" name=\"id_riddle\" />
                                                            <input type=\"hidden\" value=\"{$row['points']}\" name=\"pointsgained\" />
                                                            <input type=\"hidden\" value=\"{$row['points']}\" name=\"pointsgained1\" />
                                                            <input type=\"hidden\" value=\"{$row['points']}\" name=\"pointsgained2\" />
                                                            <input type=\"hidden\" value=\"{$_POST['id_category']}\" name=\"id_category\" />
                                                            <input type=\"hidden\" value=\"{$_POST['points']}\" name=\"points\" />
                                                            <input type=\"hidden\" value=\"{$points1}\" name=\"points1\" />
                                                            <input type=\"hidden\" value=\"{$points2}\" name=\"points2\" />
                                                            <input type=\"hidden\" value=\"{$_POST['players']}\" name=\"players\" />
                                                            <input type=\"submit\" value=\"Submit\">
                                                        </p>
                                                    </form>
                                               </p>";
                                     if ( $numbering != 1 )
                                               {
                                                    echo "<button onclick=\"changeVisibleDiv('$numbering','down')\">Previous</button>";
                                               }
                                               
                                               if ( $numbering != $numRows )
                                               {
                                                    echo "<button onclick=\"changeVisibleDiv('$numbering','up')\">Skip</button>";
                                               }                                    
                                    echo "</div>
                             
                                </div>
                            </div>
                     
                         </div>";
                                    
                    }
                }
                
           }
     
#endregion   
    
#region "show results for single player style" 
   else
    {
        
        if ($results = mysqli_query($link, $query)) 
                {
                    $numbering = 0;
                    $numRows = mysqli_num_rows($results);
                    while ($row = mysqli_fetch_array($results, MYSQLI_ASSOC)) 
                    {
        
                    //print_r($query);
        
                        $numbering += 1;
                        echo "<body>

                            <div class=\"box\">

                                <div style=\"margin: 20px; line-height: 20px;\">"; 
                                            if ( isset($_GET["Index"]) )
                                            {
                                                if ( ( $numbering - 1 ) == $_GET["Index"])
                                                {
                                                    echo "<div id=\"".$numbering."\">";
                                                }
                                                else
                                                 {
                                                    echo "<div class=\"invisible\" id=\"".$numbering."\">";
                                                }
                                            }
                                            else
                                            {
                                                if ($numbering == 1)
                                                {
                                                    echo "<div id=\"".$numbering."\">";
                                                }
                                                else
                                                {
                                                    echo "<div class=\"invisible\" id=\"".$numbering."\">";
                                                }
                                            }
                                
                                            
                                                                    
            
                                   
                                               echo "<h3 style=\"padding: 15px; font-size: 20px; color: #FFFFFF;\">" . $numbering . ". {$row['category_name']} Riddle ({$row['points']}):</h3>
    
                                                <audio id=\"riddle_challenge\" controls=\"controls\" preload=\"none\">
                                                    <source src=\"../mp3s/{$row['riddle']}\">Your browser does not support the audio element.
                                                </audio><br />
                                        
                                                <h3 style=\"padding: 15px; font-size: 20px; color: #FFFFFF;\">Answer:</h3>
                                                <audio id=\"riddle_answer\" controls=\"controls\" preload=\"none\">
                                                    <source src=\"../mp3s/{$row['answer']}\">Your browser does not support the audio element.
                                                </audio><br /><br />
                                        
                                                <p style=\"color: #FFFFFF;\">Did you get it? <br /> 
                                                    <form method='post' action=\"handler_riddle_search.php?Index=$numbering\">
                                                        <p style=\"color: #FFFFFF;\">
                                                            <input style=\"color: #FFFFFF;\" type=\"radio\" name=\"correct\" value=\"1\" />YES
                                                            <input style=\"color: #FFFFFF;\" type=\"radio\" name=\"correct\" value=\"0\" />NO
                                                        <input type=\"hidden\" value=\"{$row['id_riddle']}\" name=\"id_riddle\" />
                                                        <input type=\"hidden\" value=\"{$row['points']}\" name=\"pointsgained\" />
                                                        <input type=\"hidden\" value=\"{$_POST['id_category']}\" name=\"id_category\" />
                                                        <input type=\"hidden\" value=\"{$_POST['points']}\" name=\"points\" />
                                                        <input type=\"hidden\" value=\"{$_POST['players']}\" name=\"players\" />
                                                        <input type=\"submit\" value=\"Submit\">
                                                        </p>
                                                    </form>
                                               </p>";
                                     
                                               if ( $numbering != 1 )
                                               {
                                                    echo "<button onclick=\"changeVisibleDiv('$numbering','down')\">Previous</button>";
                                               }
                                               
                                               if ( $numbering != $numRows )
                                               {
                                                    echo "<button onclick=\"changeVisibleDiv('$numbering','up')\">Next</button>";
                                               }
                                                echo "
                                    </div>
                             
                                </div>
                            </div>
                     
                         </div>";
                                    
                    }
                }
           }
        }
      
      
      #endregion
      


mysqli_close($link);  


?>