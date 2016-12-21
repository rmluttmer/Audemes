<%@ Page Language="C#" %>

<html>
    <head>
        <!--#Include virtual="~\jhesch\includes\header.html"-->
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
                    
                    <h2>Biology Grids</h2>
                    <p><a href="/jhesch/contribute/sequenceCreator.aspx?AudemeGridID=6">Biology Blocks I</a></p>
                    <p><a href="/jhesch/contribute/sequenceCreator.aspx?AudemeGridID=7">Biology Blocks II</a></p>

                    <h2>Placeholder Grids</h2>
                    <p><a href="atomictraining.aspx?AudemeGridID=1">Audeme Grid (no labels)</a></p><br />
                    <p><a href="audemeBlocks.aspx?AudemeGridID=2">Audeme Blocks</a></p><br />
                    <p><a href="quizgame.aspx?AudemeGridID=5">Audeme Quiz Game</a></p><br />
                              
                </div> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\jhesch\includes\footer.html"-->
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Games')").addClass('current'); //Makes the proper top nav item selected
    </script>
    </body>
</html>    
