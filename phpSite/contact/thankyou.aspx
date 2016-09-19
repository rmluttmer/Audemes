<%@ Page Language="C#" Title="Thank you!" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"--> 
        <title>Thank You!</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>
    <body>
        <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	        <% Response.Write(styleManager.initializeTopNav()); %> 

	        <div id="content">
            	<div id="content_left">
                    <div class="title">Form Submitted!</div>
                    <p>Thank you for contacting us!  We will be in touch.</p>
                </div> <!-- end of content_left -->        
    	        <div id="bottom_bg"></div>
            </div> <!-- end of content -->
               
            <!--#Include virtual="~\includes\footer.html"--> 
        </div> <!-- end of container -->
        
        <script type="text/javascript">
            $("a:contains('Contact')").addClass('current'); //Makes the proper top nav item selected
        </script>
    </body>
</html>

