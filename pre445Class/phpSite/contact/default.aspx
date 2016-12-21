<%@ Page Language="C#" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"--> 
        <title>Contact Us</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
        <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	        <% Response.Write(styleManager.initializeTopNav()); %> 	
            <div id="content">
            	<div id="content_left">
                    <div class="title">Contact Us</div>
                    <p>
                        Have an idea for a new audeme?  Have feedback about anything on the site?  Just want to chat?  
                        Fill out the form below!
                    </p>
                    <form class="form" name="form_request" id="form_request" action="../formHandlers/submitRequest.aspx">
                        
                        <label for="fName" class="text">First Name</label>
                        <input id="Text5"  name="fName" type="text" /><br />
                
                        <label for="lName" class="text" >Last Name</label>
                        <input id="Text6" name="lName" type="text" /><br />
                
                        <label for="email" class="text">Email</label>
                        <input id="email1" name="email" type="email" /><br />
        		        <br />
		                <label for="request">Request:</label><br />
		                <textarea id="request" rows="10" cols="30" name="request" ></textarea><br /><br />
        	
	                    <input type="submit" id="Submit1" value="Submit" />
	                    
                    </form>         
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
