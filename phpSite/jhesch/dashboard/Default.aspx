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
                    
                    if (Session["user_id"] != null && Session["user_id"] != "")
                    {
                        pageText += "<div class='title'>My Audemes Locker</div>";
                        pageText += @"<ul id='dashboardNav'>
                                            <li><a id='organizeAudemes' class='clickable'>Organize Audemes</a></li>
                                            <li><a id='sessions' class='clickable' href='/jhesch/dashboard/Sessions.aspx'/>Sessions</a></li>
                                            <li><a href='Grids.aspx' class='clickable'>Grids</a></li>
                                            <li><a href='/jhesch/dashboard/updateAccount.aspx'>Update Account</a></li>
                                    </ul>";

                        pageText += "<br /><p class='Message' style='color: green; font-weight: bold;'>" + Request.QueryString["Message"] + "</p>";
                        
                        List<Audeme> myDashboard = new List<Audeme>();
                        myDashboard = dbManager.returnDashboardList(Convert.ToInt32(Session["user_id"]));
                        pageText += audemeListViewer.viewAsDashboardList(myDashboard, (Int16)enumListType.DashboardList, 0);

                        Response.Write(pageText);

                    }
                    else
                    {
                        //Set this page as the "Previous Page" so that the user can be redirected here when they save an audeme or log in
                        Response.Redirect("/jhesch/login.aspx");                       
                    }
                %>        
                    
                            
                </div> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\jhesch\includes\footer.html"--> 
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Account')").addClass('current'); //Makes the proper top nav item selected
    </script>
    </body>
</html>    