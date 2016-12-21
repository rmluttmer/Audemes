<%@ Page Language="C#" AutoEventWireup="true" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"--> 
        <script type="text/javascript" src="/js/atomicTraining.js"></script>
        <title>Audeme Blocks</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
        <script type="text/javascript" src="/js/browserWarning.js"></script>
    </head>
    <body>
        <div id="container">  
	        <% Response.Write(styleManager.initializeTopNav()); %> 	
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
                Response.Write("<h1>Error.  Invalid AudemeGridID:  " + AudemeGridID + "</h1><br />");
                Response.Write("Please select a different game on the <a href='/games'>Game Selection Page</a><br />");
                Response.Write("If you feel that this is an error, please contact us via the <a href='/contact/'>Contact Form</a>");
            }
            else
            {
                //If an AudemeGrid is successfully created, retrieve it.
                AudemeGrid myAudemeGrid = dbManager.returnAudemeGrid(AudemeGridID);
                    
                //Write the Audeme Table
                string outputTable = "";
                outputTable += "<table id='audemeBlocks'>";
                outputTable += "\n<tr>";
                
                //Loop through the columns in the grid
                for (int i = 0; i < myAudemeGrid.getnumColumns(); i++)
                {
                    outputTable += "<td>\n<table>";

                    AudemeGridColumn myColumn = myAudemeGrid.getColumn(i);

                    outputTable += "<tr><th>" + myColumn.getName() + "</th></tr>";
                    
                    //Loop through the cells in the current column
                    for ( int j = 0; j < myColumn.getCells().Count; j++)
                    {
                        outputTable += "<tr>\n<td onclick=\"trainingPlay('";
                        outputTable += myColumn.getCell(j).getFileName() + "', '";
                        outputTable += myColumn.getCell(j).getTags();
                        outputTable += "');\">" + myColumn.getCell(j).getName() + "</td>";
                        outputTable += "</tr></td>";
                    }
                    
                    outputTable += "</table>\n</td>";
                }
                
                outputTable += "\n</tr>";
                outputTable += "\n</table>";
                
                Response.Write(outputTable);
            }
        %>

        
                </div> <!-- end of content_left -->        
    	        <div id="bottom_bg"></div>
            </div> <!-- end of content -->
               
            <!--#Include virtual="~\includes\footer.html"--> 
        </div> <!-- end of container -->
        
        <script type="text/javascript">
            $("a:contains('Games')").addClass('current'); //Makes the proper top nav item selected
        </script>
    </body>
</html>

