<%@ Page Language="C#" %>
<%@ Import Namespace="System.Collections.Generic" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"--> 
        <title>Dictionary</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
        <div id="container"> 
	        <% Response.Write(styleManager.initializeTopNav()); %> 	
            <div id="content">
            	<div id="content_left">
                    <div class="title">Locked Audemes</div>
                    <form id="search" action="#">
                        <input type="text" name="searchTerm" placeholder="What are you looking for?" size="100" id="searchTermBox" />
                        <input type="submit" value="Search" />
                    </form>

                    

                    <%        
                        
                        string strMessage = "";
                        
                        //Set this page as the "Previous Page" so that the user can be redirected here when they save an audeme or log in
                        Session["PreviousPage"] = Request.Url.ToString();

                        //Get the current User ID
                        if (Session["role_id"] != null)
                        {
                            string strRoleID = Session["role_id"].ToString();
                            short roleID;
                            if (Int16.TryParse(strRoleID, out roleID))
                            {
                                roleID = Int16.Parse(strRoleID);

                                if (roleID >= 3)
                                {
                                    //Searches the database
                                    List<Audeme> audemeList = dbManager.returnSearchResults_Locked();

                                    Response.Write(audemeListViewer.viewAsSearchList(audemeList));
                                }
                                else
                                {
                                    strMessage += "Access Denied.  This page is for system administrators only.";
                                }
                            }
                            else
                            {
                                strMessage += "Invalid role id.  ";
                            }
                        }
                        else
                        {
                            strMessage += "<a href='/login.aspx'>Please log in</a>.  ";
                        }

                        if (Request.QueryString["Message"] != null)
                        {
                            strMessage += Request.QueryString["Message"].ToString();
                        }
                        lblMessage.Text = strMessage;                       
                        
                   %>

                   <asp:Label ID="lblMessage" runat="server"></asp:Label>

                </div> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\includes\footer.html"--> 
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Dictionary')").addClass('current'); //Makes the proper top nav item selected
        
        var searchValue = getParameterByName("searchTerm");
        $("#searchTermBox").attr("value", searchValue);

        function unlock(audemeID) {
            $.get("/formHandlers/unlockAudeme.aspx", { AudemeID: audemeID });
            var id = "#unlock" + audemeID;
            $(id).text("(Unlocked)");
            $(id).unbind('click');
            $(id).toggleClass("clickable");            
        }
    </script>
    </body>
</html>    
