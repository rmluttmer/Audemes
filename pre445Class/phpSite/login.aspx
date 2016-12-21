<%@ Page Language="C#" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"--> 
        <title>Login</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
        <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	        <% Response.Write(styleManager.initializeTopNav()); %> 	
            <div id="content">
            	<div id="content_left">

                <div class="title">Log In</div>
                    <form class="form" name="form_login" id="form_login" action="/formHandlers/login.aspx">
                        
                        <label for="username" class="text">Username</label>
                        <input id="username"  name="username" type="text" autofocus="autofocus" required="required" maxlength="16" /><br />

                        <label for="password" class="text">Password</label>
                        <input id="password"  name="password" type="password" required="required" maxlength="16" /><br />

                        <input type="submit" id="Submit" value="Login" /><br /><br />

                        <p><a href="createAccount.aspx">Create an Account</a></p>  

                    </form>       
                    
                    <p id="error"></p>  
                          
                </div> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\includes\footer.html"--> 
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("#error").text(getParameterByName("error"));
    </script>
    </body>
</html>    