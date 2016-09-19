<%@ Page Language="C#" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"-->
        <title>Classroom Games</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
        <div id="container">  
	        <% Response.Write(styleManager.initializeTopNav()); %>	
            <div id="content">
            	<div id="content_left">
                    <div class="title">Classroom Games</div>
<p>On this page you can find audeme games to play in the classroom.  To find relevant audemes for games in your classroom, please use <a href="http://audemes.org/dictionary/">our dictionary.</a> You can pre-build a set in your locker to help things go smoothly during class time.</a></p>
<br/>
<h3>Classroom Jeopardy</h3>
          <p style="margin-left:55px;">This game is best played using multiple educational audemes, ideally 3 to 5 sets containing 5 audemes each, in a classroom setting with a teacher officiating. Teachers may keep score themselves or designate a score keeper.<br /><br />

          To prepare for this game, determine what categories you would like to use and how many audemes you want for each category. I will be referring to the sorted audemes that are ready for play as audeme questions. Traditionally each category will have audemes that range in difficulty, with the more difficult audemes being worth more points. The easiest audeme question should be worth 100 points while the more difficult audeme questions will increase their point value in increments of 100. For example, if you are playing with five audemes the most difficult audeme question would be worth 500 points. The categories, point values, and scoreboard may want to be written somewhere that players can see, such as a chalkboard or projector screen.<br /><br />

         Once you have your audemes prepared for the game, divide your class into teams. The amount of teams and players within each team is up to you! You can play with as few as two teams that each contain one person. The maximum amount of teams and players is at your discretion.<br /><br />

          To play this game, teams will take turns selecting a category and point value. The team selecting is given the first chance to say the correct answer. If they are incorrect, the other team(s) are given the chance to answer. If you are playing with more than two teams and the first team answers incorrectly, the remaining teams will “buzz in” (ex: raise hand, press a buzzer button, etc.) to determine who gets to try and answer next. When a team answers correctly, they are awarded the points for the audeme. Each audeme question is only available once per game. For example, if players selected Astronomy for 500 point, it cannot be selected again later in the game.<br /><br />

          The game ends once all of the audeme questions have been used. The team with the highest score wins!</p>

          <h3>Next Game</h3>

          <p>  </p>
          <p>  </p>
          <p>  </p>
          <p>  </p>
          <p>  </p>
          <p>  </p>
          <p>  </p>
          <p>  </p>
          <p>  </p>
          <p>  </p><br />
          <p><a href="/games/Riddle/default.php">Riddles Main Page</a></p>
          <p><a href="/games/default.aspx">Go to Multi-Player Games</a></p>
          <p><a href="/games/default.aspx">Go Back to the Games Main Page</a><br/></p>
                    
                    
                              
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
