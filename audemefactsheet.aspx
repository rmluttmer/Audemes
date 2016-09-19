<%@ Page Language="C#" %>
<<%@ Import Namespace="System.Collections.Generic" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"--> 
        <title>Audeme Fact Sheet</title>
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
                    //Get the AudemeID from the URL
                    Int16 AudemeID = 0;
                    bool isNum = false;
                    if (Request.QueryString["AudemeID"] != null && Request.QueryString["AudemeID"] != "")
                    {
                        isNum = Int16.TryParse(Request.QueryString["AudemeID"].ToString(), out AudemeID);
                    }

                    //If an invalid AudemeID or no AudemeID is provided, report an error.  Otherwise, proceed normally.
                    if (!isNum)
                    {
                        Response.Write("<h1>Error.  Invalid AudemeID:  " + AudemeID + "</h1><br />");
                        Response.Write("Please select a different audeme on the <a href='/dictionary'>Dictionary</a><br />");
                        Response.Write("If you feel that this is an error, please contact us via the <a href='/contact/'>Contact Form</a>");
                    }
                    else
                    {
                        //Retrieve Audeme information and build the fact sheet page
                        Audeme myAudeme = new Audeme(AudemeID);
                        string pageText = "";
                        string playHTML = "";
                        string moreAudemesHTML = "";
                        string generalInfo = "";
                        string addToDashboardHTML = "";
                                                
                        //Handle the audeme general info area
                        generalInfo += "<div id='factSheetGeneralInfo'>";
                        
                        generalInfo += "<p><i>Audeme name: </i> " + myAudeme.getName() + "</p>";

                        generalInfo += "<p><i>Concept: </i> " + myAudeme.getDescription() + "</p>";

                        if (myAudeme.getSoundType() < 3)
                        {
                            generalInfo += "<p><i>Sound sequence: </i> " + myAudeme.getSoundComposition() + "</p>";
                        }
                        else
                        {
                            generalInfo += "<p><i>Sound sequence: </i> " + audemeViewer.viewSequenceOfSounds(myAudeme) + "</p>";
                        }
                        
                        //Related audemes    
                        if (myAudeme.getRelatedAudemes() != "" && myAudeme.getRelatedAudemes() != null)
                        {
                            generalInfo += "<p><i>Related Audemes: </i> ";
                            
                            string relatedString = myAudeme.getRelatedAudemes();
                            string[] relatedArray = relatedString.Split(',');
                            List<string> relatedList = new List<string>(relatedArray.Length);
                            relatedList.AddRange(relatedArray);

                            relatedList.ForEach(delegate(string related)
                            {
                                int relatedID = Convert.ToInt16(related);
                                Audeme relatedAudeme = new Audeme(relatedID);
                                generalInfo += "<a href='/audemeFactSheet.aspx?AudemeID=" + relatedAudeme.getID() + "'>" + relatedAudeme.getName() + "</a>, ";
                            });

                            generalInfo = generalInfo.Remove(generalInfo.Length - 2);
                            
                            generalInfo += "</p>";
                        }          
                        else
                        {
                            generalInfo += "<p><i>Related Audemes: </i> None</p>";                                  
                        }
                        
                        generalInfo += "<p><i>Related tags and terms: </i>" + audemeViewer.viewTagsList(myAudeme.getTags()) + "</p>";

                        generalInfo += "<h2>Creation Information</h2>";
                        
                        //Handle the creator info
                        if (myAudeme.getCreator() != "")
                        {
                            User myUser = dbManager.returnUserInfo(myAudeme.getCreator());
                            generalInfo += "<p><i>Creator: </i> <a href='/userInfo.aspx?UserID=" + myUser.getUserID() + "'>" + myUser.getUserName() + "</a></p>";
                        }   
                            
                        //Handle the creation date
                        if (myAudeme.getCreationDate() != "")
                        {
                            generalInfo += "<p><i>Creation Date: </i> " + myAudeme.getCreationDate() + "</p>";
                        }
                        else
                        {
                            generalInfo += "<p><i>Creation Date: </i>Not specified.</p>";
                        }

                        generalInfo += "<br />";
                        
                        //Feedback form stuff
                        generalInfo += "<form class='form' name='form_request' id='form_request' action='/formHandlers/audemeFactSheetForm.aspx'>";
                        generalInfo += "<label for='feedback' style='width: 450px'><i>Any feedback you want to share on this audeme? Post your comment here:</i></label><br />";
                        generalInfo += "<textarea id='feedback' name='feedback' rows='10' cols='50' name='request' ></textarea><br /><br />";
                        generalInfo += "<input value='" + myAudeme.getID() + "' readonly='readonly' name='audemeID' style='display: none;'>";
                        generalInfo += "<input type='submit' id='Submit' value='Submit' />";
                        generalInfo += "</form>";
                        generalInfo += "</div>";

                        //Play                        
                        playHTML += "<li>" + audemeViewer.viewPlayLink(myAudeme) + "</li>";
                        
                        //Download
                        playHTML += "<li>" + "<a href='downloadFile.aspx?FileName=" + myAudeme.getFileName() + "' target='_blank' id='downloadLink'>Download</a>" + "</li>";
                        
                        //Add to Locker stuff
                        addToDashboardHTML += "<li>" + audemeViewer.viewAddToDashboardLink(myAudeme.getID()) + "</li>";                 
                        
                        //Combine the page text before writing it
                        pageText += "<div class='title'>Audeme Fact Sheet: <b>" + myAudeme.getName() + "</b></div>";
                        pageText += "<div class='topSubNav'><ul>";
                        pageText += playHTML;
                        pageText += addToDashboardHTML;
                        pageText += moreAudemesHTML + "</ul></div>";
                        pageText += generalInfo;
                        
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