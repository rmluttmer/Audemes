<%@ Page Language="C#" %>
<%@Import Namespace="System.Collections.Generic" %>

<html>
    <head>
        <!--#Include virtual="~\jhesch\includes\header.html"--> 
        <title>Dashboard</title>
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
                    string pageText = "";
                    
                    if (Session["user_id"] != null && Session["user_id"] != "")
                    {
                        pageText += "<div class='title'>My Sessions</div>";
                        pageText += @"<ul id='dashboardNav'>
                                            <li><a href='Default.aspx' class='clickable'>Audemes</a></li>
                                            <li><a class='clickable' href='createSession.aspx'>Create Session</a></li>
                                            <li><a href='Grids.aspx' class='clickable'>Grids</a></li>
                                            <li><a href='/jhesch/formHandlers/logout.aspx'>Sign Out</a></li>
                                    </ul>";
                        pageText += "<br />";

                        if (Request.QueryString["Message"] != null & Request.QueryString["Message"] != "")
                        {
                            pageText += "<p class='success'>" + Request.QueryString["Message"] + "</p>";
                        }    
                        
                        //Create the session list
                        User myUser = new User();
                        List<audemeSession> mySessionList = new List<audemeSession>();
                        mySessionList = myUser.getAudemeSessionList(Convert.ToInt16(Session["user_id"]));
                        
                        if (mySessionList.Count > 0)
                        {
                            mySessionList.ForEach(delegate(audemeSession myAudemeSession)
                            {
                                pageText += "<p class='sessionName'>" + myAudemeSession.audemeSessionName + " (<a class='clickable' href='/jhesch/formHandlers/deleteSession.aspx?sessionID=" + myAudemeSession.audemeSessionID + "'>delete</a>)</p>";
                                pageText += audemeListViewer.viewAsDashboardList(myAudemeSession.audemesList, (Int16)enumListType.SessionList, (Int16)myAudemeSession.audemeSessionID);
                            });
                        }
                        else
                        {
                            pageText += "<br />No sessions found.  Click the \"Create Session\" link (above) to create a new session.";
                        }
                        
                        
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
                        Response.Redirect("/jhesch/login.aspx");                       
                    }
                %>        
                    
                            
                </div> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\jhesch\includes\footer.html"--> 
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Dashboard')").addClass('current'); //Makes the proper top nav item selected
    </script>
    </body>
</html>    