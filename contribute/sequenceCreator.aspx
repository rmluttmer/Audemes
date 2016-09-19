<%@ Page Language="C#" AutoEventWireup="true" %>
<%@Import Namespace="System.Collections.Generic" %>
<%@Import Namespace="System.Collections.Specialized" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"--> 
        <script type="text/javascript" src="/js/atomicTraining.js"></script>
        <script type="text/javascript" src="/js/jquery-ui-1.9.0.custom.min.js"></script>
        <title>Atomic Sound Training</title>
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
                        //dbManager.login("audeme", "audeme");
                        
                        /*========================
                         * Contents:
                         *  I.  URL Validation
                         *  1.  Main Audeme Creator
                         *  2.  Sequence Creation Interface
                         *      2a.  Dashboard Interface
                         *      2b.  Sequence Creation Form
                         *      2c. Play Button Code
                         *  II. Error Handling - AudemeGrid Generation
                         * =========================*/

                        /*============================================
                        * I.  URL Validation
                        * ============================================*/
                        
                        //Set this page as the "Previous Page" so that the user can be redirected here when they save an audeme or log in
                        Session["PreviousPage"] = Request.Url.ToString();
                        
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
                                                        
/*============================================
* 1.  Main Audeme Creator Area
* ============================================*/
                            Response.Write("<section id='selectionArea'>");
                            
                                //If an AudemeGrid is successfully created, retrieve it.
                                AudemeGrid myAudemeGrid = dbManager.returnAudemeGrid(AudemeGridID);

                                //Create a dictionary to hold all of the unique audemes
                                OrderedDictionary myAudemeDictionary = new OrderedDictionary();
                                
                                //Write the Audeme Table
                                string outputTable = "";
                                outputTable += "<table id='audemeBlocks'>";
                                outputTable += "\n<tr>";

                                //Get number of columns in the grid
                                int curCell = 0;
                                int intGridCols = myAudemeGrid.getnumColumns();
                                int intTotalCols;
                            
                                //Get list of user's sessions
                                User myUser = new User();
                                List<audemeSession> mySessionList = new List<audemeSession>();
                            
                                if (Session["user_id"] != null && Session["user_id"] != "")
                                {
                                    myUser.setUserID(Int16.Parse(Session["user_id"].ToString()));
                                    //mySessionList = myUser.getAudemeSessionList(myUser.getUserID());
                                }

                                intTotalCols = intGridCols + mySessionList.Count;
                            
                                //Loop through the columns in the grid
                                for (int i = 0; i < intTotalCols; i++)
                                {
                                    outputTable += "<td>\n";

                                    if (i < myAudemeGrid.getnumColumns())
                                    {
                                        //Add the default columns 
                                        
                                        AudemeGridColumn myColumn = myAudemeGrid.getColumn(i);

                                        outputTable += "<table>\n<tr><th>" + myColumn.getName() + "</th></tr>\n";

                                        //Loop through the cells in the current column
                                        for (int j = 0; j < myColumn.getCells().Count; j++)
                                        {
                                            AudemeGridCell myAudeme = myColumn.getCell(j);
                                            
                                            //Write the HTML for the table
                                            outputTable += "<tr><td class='draggable audeme' audemeID='" + myAudeme.getID() + "' id='audeme" + myAudeme.getID() + "' onclick=\"trainingPlay('";
                                            outputTable += myAudeme.getFileName() + "', '";
                                            outputTable += myAudeme.getTags();
                                            outputTable += "', event);\">" + myAudeme.getName() + "</td>";
                                            outputTable += "</tr>\n";
                                            
                                            //Add the Audeme to myAudemeDictionary if it isn't there already
                                            if (!myAudemeDictionary.Contains(myAudeme.getID()))
                                            {
                                                myAudemeDictionary.Add(myAudeme.getID(), myAudeme.getFileName());
                                            }
                                                                                       
                                            curCell++;
                                        }
                                        
                                        outputTable += "</table>\n";
                                    }
                                    else
                                    {
                                        //Add the user's sessions
                                        int sessionIndex = i - myAudemeGrid.getnumColumns();

                                        List<Audeme> myAudemeList = dbManager.returnAudemesInSession(mySessionList[sessionIndex].audemeSessionID);

                                        
                                        myAudemeList.ForEach(delegate(Audeme a)
                                        {
                                            //Add the Audeme to myAudemeDictionary if it isn't there already
                                            if (!myAudemeDictionary.Contains(a.getID()))
                                            {
                                                myAudemeDictionary.Add(a.getID(), a.getFileName());
                                            }
                                        });

                                        outputTable += audemeListViewer.viewAsSequenceList(myAudemeList, mySessionList[sessionIndex].audemeSessionName);
                                    }

                                    outputTable += "</td>";
                                }

                                outputTable += "\n</tr>";
                                outputTable += "\n</table>";

                                Response.Write(outputTable);
                                
                                Response.Write("</section>");
                                Response.Write("</section>");

                                
/*============================================
* 2.  Sequence Creation Interface
* ============================================*/
                        string sequenceCreationHTML = "";

                        /*============================================
                        * 2b. Sequence Creation Form
                        * ============================================*/

                            
                                //Write the Sequence Creation form

                                sequenceCreationHTML += "<section id='sequenceCreation'>";

                                sequenceCreationHTML += "<form id='createSequenceForm' action='/formHandlers/createSequence.aspx' method='post'>";

                                sequenceCreationHTML += "<ul id='droppableList' style='height: 62px;'>";
                                sequenceCreationHTML += "<li id='drop0' class='droppable'>1</li>";
                                sequenceCreationHTML += "<li id='drop1' class='droppable'>2</li>";
                                sequenceCreationHTML += "<li id='drop2' class='droppable'>3</li>";
                                sequenceCreationHTML += "<li id='drop3' class='droppable'>4</li>";
                                sequenceCreationHTML += "<li id='drop4' class='droppable'>5</li>";
                                sequenceCreationHTML += "</ul>";

                                //sequenceCreationHTML += "<button type='button' id='playButton'>Play</button>";
                                sequenceCreationHTML += "<button type='button' id='resetButton'>Reset</button>";
                            
                                sequenceCreationHTML += "<h3 style='display: block; width: 900px;'>Instructions:<br />Drag audemes into the slots above.  If you want to save the sequence to your locker, fill out the form below and click Save.</h3>";

                                sequenceCreationHTML += "<div style='display: block; margin-top: 25px;'>";
                                sequenceCreationHTML += "<input type='text' name='sequenceSoundIDs' id='sequenceSoundIDs' maxlength='50' required='required'/>";
                                sequenceCreationHTML += "<label for='name'>Name: </label>";
                                sequenceCreationHTML += "<input type='text' name='name' maxlength='50' required='required' placeholder='50 Characters Max.'/>";
                                sequenceCreationHTML += "<label for='description'>Description: </label>";
                                sequenceCreationHTML += "<input type='text' name='description' maxlength='250' placeholder='250 Characters Max.'/>";
                                sequenceCreationHTML += "<label for='subject'>Subject Area: </label>";
                                sequenceCreationHTML += "<input type='text' name='subject' maxlength='50' placeholder='50 Characters Max.'/>";

                                //Display any messages regarding form submission (e.g., Success!  Failure!)
                                sequenceCreationHTML += "<p id='message' style='color: #EE9116'>" + Request.QueryString["message"] + "</p>";   
                                
                                if (Session["user_id"] == null)
                                {
                                    sequenceCreationHTML += "<button type='button' class='promptAuthentication'>Login</button>";
                                    sequenceCreationHTML += "<button type='button' class='saveSequence' onclick='document.forms.createSequenceForm.submit()'>Save</button>";
                                }
                                else
                                {
                                    sequenceCreationHTML += "<button type='button' class='saveSequence' onclick='document.forms.createSequenceForm.submit()'>Save</button>";
                                }

                                sequenceCreationHTML += "</div>";
                                sequenceCreationHTML += "</form>";
                                                            
                                sequenceCreationHTML += "</section>";
 
                                Response.Write(sequenceCreationHTML);


                            /*============================================
                        * 2c. Play button code
                        * ============================================*/

                                
                            
/*============================================
* II. Error Handling - AudemeGrid Generation
* ============================================*/
                            }
                        
                        %>
                    </div> <!-- end of content_left -->        
    	        <div id="bottom_bg"></div>
            </div> <!-- end of content -->
               
            <!--#Include virtual="~\includes\footer.html"--> 
        </div> <!-- end of container -->
        
        <script type="text/javascript">
            var arrayDroppedAudemes = $.makeArray(["", "", "", "", ""]);

            //Makes audemes draggable
            $(".draggable").draggable({
                revert: "false",
                start: function (event, ui) {
                    //If the audeme was currently in a drop area, allow the drop area to accept a new audeme
                    var currentDropArea = ui.helper.data('droppedOn');

                    if (currentDropArea) {
                        currentDropArea.droppable("enable");
                    }

                    //Remove this audeme from the array of used audemes
                    for (i = 0; i < arrayDroppedAudemes.length; i++) {
                        if (arrayDroppedAudemes[i] == $(this).attr('id')) {
                            arrayDroppedAudemes[i] = "";
                        }
                    }

                    //Update the current sequence in the SequenceSoundIDs input
                    $('#sequenceSoundIDs').attr('value', (arrayDroppedAudemes.toString()));

                    //Notes that the draggable has not been dropped on a droppable
                    ui.helper.data('dropped', false);
                    ui.helper.data('droppedOn', '');
                },
                stop: function (event, ui) {
                    //If the draggable item isn't dropped on a droppable item
                    if (!ui.helper.data('dropped')) {
                        //Move the draggable item back to where it started
                        ui.helper.animate({
                            top: '0px',
                            left: '0px'
                        });
                    }
                }
            });

            //Sets the droppable animations
            $(".droppable").droppable({
                drop: function (event, ui) {
                    //Animate the audeme so it moves into proper position within the drop area
                    var drop_p = $(this).offset();
                    var drag_p = ui.draggable.offset();
                    var left_end = drop_p.left - drag_p.left + 1;
                    var top_end = drop_p.top - drag_p.top + 1;
                    ui.draggable.animate({
                        top: '+=' + top_end,
                        left: '+=' + left_end
                    });

                    //Prevent the drop area from accepting another audeme
                    $(this).droppable("option", "disabled", true);

                    //Store the audeme ID in the array
                    var arrayIndex = $(this).attr('id').replace("drop", "");
                    arrayDroppedAudemes[arrayIndex] = ui.draggable.attr('id');

                    //Ensures that the draggable remains draggable
                    ui.draggable.removeClass('ui-draggable-dragging');

                    //Store the current sequence in the SequenceSoundIDs input
                    $('#sequenceSoundIDs').attr('value', (arrayDroppedAudemes.toString()));

                    //Tells the Draggable item that it has landed on a droppable item
                    ui.draggable.data('dropped', true);
                    ui.draggable.data('droppedOn', $(this));
                    
                }
                /* over: function () {
                    //Resize the drop zone to fit the audeme
                    $(this).animate({
                        height: $(event.target).outerHeight()
                    }, 500);
                }*/
            });

            $('#playButton').click(function () {

            });

            $('#resetButton').click(function () {
                location.reload();
            });

            $("a:contains('Games')").addClass('current'); //Makes the proper top nav item selected
        </script>
    </body>
</html>