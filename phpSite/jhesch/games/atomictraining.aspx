<%@ Page Language="C#" AutoEventWireup="true" %>

<html>
    <head>
        <!--#Include virtual="~\jhesch\includes\header.html"--> 
        <script type="text/javascript" src="/jhesch/js/atomicTraining.js"></script>
        <title>Atomic Sound Training</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>
    <body>
        <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	        
            <div id="content">
            	<div id="content_left">
                    <%
                        //Get the AudemeGrid ID from the URL
                        Int16 AudemeGridID = 0;
                        bool isNum = false;
                        if (Request.QueryString["AudemeGridID"] != null && Request.QueryString["AudemeGridID"] != "")
                        {
                            isNum = Int16.TryParse(Request.QueryString["AudemeGridID"].ToString(), out AudemeGridID);
                        }
                        
                        //If an invalid AudemeGridID or no AudemeGridID is provided, report an error.  Otherwise, proceed normally.
                        if (!isNum)
                        {
                            Response.Redirect("/jhesch/games/atomictraining.aspx?AudemeGridID=2");
                            Response.Write("<h1>Error.  Invalid AudemeGridID:  " + AudemeGridID + "</h1><br />");
                            Response.Write("Please select a different game on the <a href='/jhesch/games'>Game Selection Page</a><br />");
                            Response.Write("If you feel that this is an error, please contact us via the <a href='/jhesch/contact/'>Contact Form</a>");
                        }
                        else
                        {
                                //If an AudemeGrid is successfully created, retrieve it.
                                AudemeGrid myAudemeGrid = dbManager.returnAudemeGrid(AudemeGridID);

                                //Starts writing the game play area
                                string outputTable = "";
                                Response.Write("<section class='gameArea'>");
                                Response.Write("<h1 class='gameTitle'>Atomic Sound Training</h1>");
                                outputTable += "<table id=\"rssTraining\" class=\"rssTraining\">";
                               
                                outputTable += "\n<tr>";

                                //Loop through the columns in the grid
                                for (int i = 0; i < myAudemeGrid.getnumColumns(); i++)
                                {
                                    outputTable += "<td>\n<table>";

                                    AudemeGridColumn myColumn = myAudemeGrid.getColumn(i);

                                    //Loop through the cells in the current column
                                    for (int j = 0; j < myColumn.getCells().Count; j++)
                                    {
                                        outputTable += "<tr>\n<td onclick=\"trainingPlay('";
                                        outputTable += myColumn.getCell(j).getFileName() + "', '";
                                        outputTable += myColumn.getCell(j).getTags();
                                        outputTable += "');\"></td>";
                                        outputTable += "</tr></td>";
                                    }

                                    outputTable += "</table>\n</td>";
                                }

                                outputTable += "\n</tr>";
                            
                                outputTable += "\n</table>";
                                Response.Write(outputTable);
                                Response.Write("<p class='rssDescription'><span style='color: #000000;'>MEANING:  </span><span id='description'>(Nothing Selected)</span></p>");
                                Response.Write("</secton>");
                            }
                        
                        %>
                </div> <!-- end of content_left -->        
    	        <div id="bottom_bg"></div>
            </div> <!-- end of content -->
               
            <!--#Include virtual="~\jhesch\includes\footer.html"--> 
        </div> <!-- end of container -->
        
        <script type="text/javascript">
            $("a:contains('Games')").addClass('current'); //Makes the proper top nav item selected
        </script>
    </body>
</html>