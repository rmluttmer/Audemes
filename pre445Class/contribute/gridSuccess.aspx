<%@ Page Language="C#" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"-->
        <title>Create</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
        <div id="container">  
	        <% Response.Write(styleManager.initializeTopNav()); %>	
            <div id="content">
            	<div id="content_left">
                    <div class="title">Grid Created</div>

                    <p>The audeme grid has been created. If you were logged in, the grid will be in your locker.  Additionally, you may find it using the link(s) below:  </p>

                    <%
                        int GridID = 0;
                        if (Request.QueryString["GridID"] != null && Request.QueryString["GridID"] != "")
                        {
                            GridID = Int16.Parse(Request.QueryString["GridID"].ToString());

                            Response.Write("<p><a href='/games/audemeBlocks.aspx?AudemeGridID=" + GridID + "'>View the Grid</a></p>");
                            Response.Write("<p><a href='/games/quizgame.aspx?AudemeGridID=" + GridID + "'>Play Game using this grid</a></p>");
                            Response.Write("<p><a href='/contribute/sequenceCreator.aspx?AudemeGridID=" + GridID + "'>Create a Sequence from this grid</a> (only if you are logged in)</p>");
                        }    
                    %>                    
                    
                    <p><a href="gridCreator.aspx">Create Another Grid</a></p>
                               
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
