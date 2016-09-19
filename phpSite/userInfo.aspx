<%@ Page Language="C#" %>
<<%@ Import Namespace="System.Collections.Generic" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"--> 
        <title>User Information</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
        <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	        <% Response.Write(styleManager.initializeTopNav()); %> 	
            <div id="content">
            	<div id="content_left">

                <%
                    //Get the AudemeID from the URL
                    Int16 userID = 0;
                    bool isNum = false;
                    if (Request.QueryString["userID"] != null && Request.QueryString["userID"] != "")
                    {
                        isNum = Int16.TryParse(Request.QueryString["userID"].ToString(), out userID);
                    }

                    //If an invalid UserID or no UserID is provided, report an error.  Otherwise, proceed normally.
                    if (!isNum)
                    {
                        Response.Write("<h1>Error.  Invalid UserID:  " + userID + "</h1><br />");
                        Response.Write("If you feel that this is an error, please contact us via the <a href='/contact/'>Contact Form</a>");
                    }
                    else
                    {
                        string pageText = "";

                        pageText = userViewer.viewUserInfoPage(userID);
                        
                        Response.Write(pageText);                      
                    }                 
                %>
                    
                            
                </div> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\includes\footer.html"--> 
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Dictionary')").addClass('current'); //Makes the proper top nav item selected
    </script>
    </body>
</html>    