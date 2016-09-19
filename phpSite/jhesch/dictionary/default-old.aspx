<%@ Page Language="C#" %>
<%@ Import Namespace="System.Collections.Generic" %>

<html>
    <head>
        <!--#Include virtual="~\jhesch\includes\header.html"--> 
        <title>Dictionary</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
        <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	        <% Response.Write(styleManager.initializeTopNav()); %> 	
            <div id="content">
            	<div id="content_left">
                    <div class="title">Dictionary</div>
                    <form id="search" action="#">
                        <input type="text" name="searchTerm" placeholder="What are you looking for?" size="100" id="searchTermBox" />
                        <input type="submit" value="Search" />
                    </form>



                    <%        
                        //Set this page as the "Previous Page" so that the user can be redirected here when they save an audeme or log in
                        Session["PreviousPage"] = Request.Url.ToString();
                        
                        string searchTerm = Request.QueryString["searchTerm"];

                        if (!String.IsNullOrEmpty(searchTerm))
                        {
                            //Searches the database
                            List<Audeme> audemeList = dbManager.returnSearchResults(searchTerm);

                            Response.Write(audemeListViewer.viewAsSearchList(audemeList));
                        }
                        else
                        {
                            string browseText = "";

                            browseText += "<h1>Browse By Subject</h1>";

                            browseText += "<ul>";
                            browseText += "<li><a href='?searchTerm=astronomy'>Astronomy</a></li>";
                            browseText += "<li><a href='?searchTerm=biology'>Biology</a></li>";
                            browseText += "<li><a href='?searchTerm=energy'>Energy</a></li>";
                            browseText += "<li><a href='?searchTerm=rock'>Geology</a></li>";
                            browseText += "<li><a href='?searchTerm=volcano'>Volcano</a></li>";
                            browseText += "</ul>";                            
                            
                            Response.Write(browseText);
                        }
                   %>

                </div> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\jhesch\includes\footer.html"--> 
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Dictionary')").addClass('current'); //Makes the proper top nav item selected
        
        var searchValue = getParameterByName("searchTerm");
        $("#searchTermBox").attr("value", searchValue);
    </script>
    </body>
</html>    
