<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gridCreator.aspx.cs" Inherits="jhesch_contribute_gridCreator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Create a Grid</title>
    <!--#Include virtual="~\includes\header.html"--> 
    <script type="text/javascript" src="/js/atomicTraining.js"></script>
    <script type="text/javascript" src="/js/jquery-ui-1.9.0.custom.min.js"></script>
    <%
        Response.Write(styleManager.initializeStyles());  
    %>
</head>
<body runat="server">
    <form id="frmCreateGrid" runat="server">
    <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	    <% Response.Write(styleManager.initializeTopNav()); %> 	
        <div id="content">
            <div id="content_left">

                <div class="title">Create a Grid</div>       
                    <br />
                    <p><b>Instructions</b>:  click the name of the audeme set to add it to your grid.  Grids can contain up to five columns. When you want to save the grid, fill out the form at the bottom of the page and click "create."</p>
                    
                    <p>
                        <b>Filters:</b>  
                        <asp:CheckBox ID="chkYourLocker" runat="server" Checked="true" Text="Your Sets" AutoPostBack="true"/>
                        <asp:CheckBox ID="chkGames" runat="server" Checked="true" Text="Game&nbsp;Sets" AutoPostBack="true"/>
                        <asp:CheckBox ID="chkToolbox" runat="server" Checked="true" Text="Toolbox&nbsp;Sets" AutoPostBack="true"/>
                    </p>
                    <asp:GridView ID="grdColumns" runat="server" AutoGenerateColumns="false" OnRowCommand="grdColumns_OnRowCommand"
                     AllowPaging="true" PageSize="10" OnPageIndexChanging="grdColumns_PageIndexChanging" >
                        <Columns>
                            <asp:TemplateField HeaderText="Set Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdd" runat="server" Text='<%# Eval("Name") %>'></asp:Label>&nbsp;-&nbsp;<asp:LinkButton ID="lnkAdd" Text='Add' CommandName="AddToGrid" CommandArgument='<%# Eval("ID") %>' runat="server"  ></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Audemes">
                                <ItemTemplate>
                                    <asp:Label ID="lblAudemes" Text='<%# Eval("Audemes") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblSource" Text='<%# Eval("Type") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                         </Columns>
                    </asp:GridView>
                    
                    <asp:Table ID="tblMyGrid" runat="server" CssClass="audemeBlocks">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:GridView ID="grdCol0" runat="server"></asp:GridView>
                                <asp:LinkButton ID="lnkRemove0" runat="server" Text="Remove Column" Visible="false"  OnCommand="removeColumn" CommandArgument="0"></asp:LinkButton>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:GridView ID="grdCol1" runat="server"></asp:GridView>
                                <asp:LinkButton ID="lnkRemove1" runat="server" Text="Remove Column" Visible="false" OnCommand="removeColumn" CommandArgument="1"></asp:LinkButton>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:GridView ID="grdCol2" runat="server"></asp:GridView>
                                <asp:LinkButton ID="lnkRemove2" runat="server" Text="Remove Column" Visible="false" OnCommand="removeColumn" CommandArgument="2"></asp:LinkButton>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:GridView ID="grdCol3" runat="server"></asp:GridView>
                                <asp:LinkButton ID="lnkRemove3" runat="server" Text="Remove Column" Visible="false" OnCommand="removeColumn" CommandArgument="3"></asp:LinkButton>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:GridView ID="grdCol4" runat="server"></asp:GridView>
                                <asp:LinkButton ID="lnkRemove4" runat="server" Text="Remove Column" Visible="false" OnCommand="removeColumn" CommandArgument="4"></asp:LinkButton>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <asp:Label runat="server">Grid Name:  </asp:Label><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label><br />
                    <asp:Button  ID="btnSave" runat="server" Text="Save" OnClick="saveGrid" />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="redirectToLogin" />        
                </div>
            <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\includes\footer.html"-->
    </div>
    <script type="text/javascript">
        var arrayDroppedAudemes = [];

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

                //Store the dropped audeme's id on the droppable object
                $(this).attr('droppedAudemeID', ui.draggable.attr('audemeid'));

                //Ensures that the draggable remains draggable
                ui.draggable.removeClass('ui-draggable-dragging');

                //Store the current sequence in the SequenceSoundIDs input
                $('#sequenceSoundIDs').attr('value', (arrayDroppedAudemes.toString()));

                //Tells the Draggable item that it has landed on a droppable item
                ui.draggable.data('dropped', true);
                ui.draggable.data('droppedOn', $(this));

            },
            over: function () {
                //Resize the drop zone to fit the audeme
                $(this).animate({
                    height: $(event.target).outerHeight()
                }, 500);
            }
        });

        $('#playButton').click(function () {

        });

        $('#resetButton').click(function () {
            for (i = 0; i < arrayDroppedAudemes.length; i++) {
                var audemeBlock = document.getElementById(arrayDroppedAudemes[i]);
                $(audemeBlock).animate({
                    //Move the draggable item back to where it started
                    top: '0px',
                    left: '0px'
                });
            }

            //Reset the array of dropped audemes
            arrayDroppedAudemes = $.makeArray(["", "", "", "", ""]);

            //Store the current sequence in the SequenceSoundIDs input
            $('#sequenceSoundIDs').attr('value', (arrayDroppedAudemes.toString()));

            //Allow the drop area to accept another audeme
            $('#droppableList li').droppable("option", "disabled", false);
        });

        $("a:contains('Create')").addClass('current'); //Makes the proper top nav item selected
    </script>
    </form>    
</body>
</html>
