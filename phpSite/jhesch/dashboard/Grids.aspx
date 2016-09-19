<%@ Page Language="C#" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Data" %>

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
                        pageText += "<div class='title'>My Grids</div>";
                        pageText += @"<ul id='dashboardNav'>
                                            <li><a href='Default.aspx' class='clickable'>Audemes</a></li>
                                            <li><a class='clickable' href='Sessions.aspx'>Sessions</a></li>
                                            <li><a href='/jhesch/contribute/GridCreator.aspx' class='clickable'>Create Grids</a></li>
                                            <li><a href='/jhesch/formHandlers/logout.aspx'>Sign Out</a></li>
                                    </ul>";
                        pageText += "<br />";

                        if (Request.QueryString["Message"] != null & Request.QueryString["Message"] != "")
                        {
                            pageText += "<p class='success'>" + Request.QueryString["Message"] + "</p>";
                        }    
                        
                        //Create the Grid list
                        DataTable dt = new DataTable();
                        dt = dbManager.returnDashboardList_Grids(Int16.Parse(Session["user_id"].ToString()));

                        if (dt.Rows.Count > 0)
                        {
                            pageText += audemeListViewer.viewAsDashboardList_Grids(dt);
                        }
                        else
                        {
                            pageText += "<p>No grids found in your locker.  <br />Find grids in the <a href='/jhesch/dictionary/'>Dictionary</a></p>";
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