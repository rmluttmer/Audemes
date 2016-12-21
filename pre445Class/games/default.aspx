<%@ Page Language="C#" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"-->
        <title>Games</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
        <div id="container">  
	        <% Response.Write(styleManager.initializeTopNav()); %>	
            <div id="content">
            	<div id="content_left">
                    <div class="title" style="font-weight:bold;"><!--  title text here?  --> </div>

          <ul style="list-style: none;">
                <li><a href="/games/Riddle/forms/riddle_search.php"><b>NEW! Riddle Game </b></a></li><br />
                <li><a href="/games/classroom.aspx">Classroom Ideas</a></li>
          </ul>
                    <br />
                    <p style="font-weight:bold";>Quiz Games:</p>
                    <ul>
                        <li><a href="/games/quizgame.aspx?AudemeGridID=30">Astronomy</a></li>
                        <li><a href="/games/quizgame.aspx?AudemeGridID=31">Biology</a></li>
                        <li><a href="/games/quizgame.aspx?AudemeGridID=28">Earth Science 1</a></li>
                        <li><a href="/games/quizgame.aspx?AudemeGridID=29">Earth Science 2</a></li>
                        <li><a href="/games/quizgame.aspx?AudemeGridID=27">Energy</a></li>
                        <!-- <li><a href="/dictionary">Find more in the Dictionary &raquo;</a></li> -->
                    </ul>
                              
                </div> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\includes\footer.html"-->
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Games')").addClass('current'); //Makes the proper top nav item selected
    </script>
    </body>
</html>    
