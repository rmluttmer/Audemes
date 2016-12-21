<%@ Page Language="C#" %>

<html>
    <head>
        <!--#Include virtual="~\jhesch\includes\header.html"--> 
        <title>Create Account</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
        <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	        <% Response.Write(styleManager.initializeTopNav()); %> 	
            <div id="content">
            	<div id="content_left">

                <div class="title">Create an Account</div>
                    <form class="form" name="form_createAccount" id="form_createAccount" action="/jhesch/formHandlers/createAccount.aspx">
                        
                        <label for="username" class="text">Username*<br />(6-16 characters)</label>
                        <input id="username"  name="username" type="text" autofocus="true" required="required" maxlength="16" placeholder="Letters &amp; Numbers Only" /><br />

                        <label for="password" class="text">Password*<br />(6-16 characters)</label>
                        <input id="password"  name="password" type="password" required="required" maxlength="16" placeholder="Letters &amp; Numbers Only" /><br />

                        <label for="password2" class="text">Password*<br />(re-enter)</label>
                        <input id="password2"  name="password2" type="password" required="required" maxlength="16" placeholder="Letters &amp; Numbers Only" /><br />
                            
                        <label for="fName" class="text">First Name*</label>
                        <input id="fName"  name="fName" type="text" required="required" /><br />
                        
                        <label for="lName" class="text" >Last Name*</label>
                        <input id="lName" name="lName" type="text" required="required" /><br />
                
                        <label for="email" class="text">Email*</label>
                        <input id="email" name="email" type="email" required="required" /><br />

                        <label for="phone" class="text">Phone</label>
                        <input id="phone"  name="phone" type="tel" /><br />

                        <label for="school" class="text">School</label>
                        <input id="school"  name="school" type="text" /><br /><br />

                        <label for="styleSheet" class="text">Text Size</label>
                        <input name="styleSheet" type="radio" value="smallText"/><span style="font-size: 11px;">Small (11px)</span>
                        <input name="styleSheet" type="radio" value="largeText"/>Large (24px)

        	            
                        <p id="error"> </p>
                            
                        <input type="submit" id="Submit" value="Create Account" /><br /><br />

                        <label>* required field</label>
                          
	                </form>         
                    
                            
                </div> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\jhesch\includes\footer.html"--> 
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Dictionary')").addClass('current'); //Makes the proper top nav item selected
        $("#error").html(getParameterByName("error")); //Fills in any errors
    </script>
    </body>
</html>    