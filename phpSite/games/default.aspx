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
        <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	        <% Response.Write(styleManager.initializeTopNav()); %>	
            <div id="content">
            	<div id="content_left">
                    <div class="title">Games</div>
                    
                    <p>Any grids of audemes in the dictionary can be used as a quiz game.  Here are a few:</p>
                    <ul>
                        <li><a href="/games/quizgame.aspx?AudemeGridID=30">Astronomy</a></li>
                        <li><a href="/games/quizgame.aspx?AudemeGridID=31">Biology</a></li>
                        <li><a href="/games/quizgame.aspx?AudemeGridID=28">Earth Science 1</a></li>
                        <li><a href="/games/quizgame.aspx?AudemeGridID=29">Earth Science 2</a></li>
                        <li><a href="/games/quizgame.aspx?AudemeGridID=27">Energy</a></li>
                        <li><a href="/dictionary">Find more in the Dictionary &raquo;</a></li>
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
