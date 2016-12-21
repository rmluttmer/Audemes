<%@ Page Language="C#" %>

<html>
    <head>
        <!--#Include virtual="~\jhesch\includes\header.html"-->
        <title>Create</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
        <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	        <% Response.Write(styleManager.initializeTopNav()); %>	
            <div id="content">
            	<div id="content_left">
                    <div class="title">Grid Created</div>
                    <p>The audeme grid has been created. If you were logged in, it can be found in your locker.  Otherwise, you may find it at this link:  </p>

                    <p><a href="gridCreator2.aspx">Create Another Grid</a></p>

                    <p><a href="/jhesch/dashboard">Your Locker</a></p>
                    
                               
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
