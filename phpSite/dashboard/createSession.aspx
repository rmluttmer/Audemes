<%@ Page Language="C#" %>
<%@Import Namespace="System.Collections.Generic" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"--> 
        <title>Dashboard</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
        <script type="text/javascript" src="/js/browserWarning.js"></script>
    </head>    
    <body>
        <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	        <% Response.Write(styleManager.initializeTopNav()); %> 	
            <div id="content">
            	<div id="content_left">

                <% 
                    string pageText = "";
                    
                    if (Session["user_id"] != null && Session["user_id"] != "")
                    {
                        //Set this page as the "Previous Page" so that the user can be redirected here when they save an audeme or log in
                        Session["PreviousPage"] = Request.Url.ToString();
                        
                        pageText += "<div class='title'>Create a Set</div>";

                        if(Request.QueryString["message"] != "" && Request.QueryString != null)
                        {
                            pageText += "<p class='success'>" + Request.QueryString["message"] + "</p>";   
                        }
                        
                        pageText += "<p>Use the form to create new sets.  To return to your set list, click the link below:<br />";
                        pageText += "<a href='Sessions.aspx'>Return to Set List</a></p><br />";
                        
                        pageText += @"  <form id='createSession' action='/formHandlers/createSession.aspx'>
                                            <input type='text' placeholder='Enter a Set Name' name='sessionName' required/>
                                            <br />
                                            <input type='submit' value='Save'>
                                        </form>";
                            
                        
                        Response.Write(pageText);

                        //Set this page as the "Previous Page" so that the user can be redirected here when they save an audeme or log in
                        string curURL = Request.Url.ToString();
                        int paramStart = curURL.IndexOf("?");
                        if (paramStart == -1)
                        {
                            Session["PreviousPage"] = Request.Url.ToString();
                        }
                        else
                        {
                            Session["PreviousPage"] = curURL.Substring(0, curURL.IndexOf("?"));
                        }
                        
                        
                    }
                    else
                    {
                        //Set this page as the "Previous Page" so that the user can be redirected here when they save an audeme or log in
                        Session["PreviousPage"] = Request.Url.ToString();
                        Response.Redirect("/login.aspx");                       
                    }
                %>        
                    
                            
                </div> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\includes\footer.html"--> 
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Dashboard')").addClass('current'); //Makes the proper top nav item selected
    </script>
    </body>
</html>    