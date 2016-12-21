<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="jhesch_dictionary_Default3" %>

<html>
    <head>
        <!--#Include virtual="~\jhesch\includes\header.html"--> 
        <title>Create an Audeme</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
        <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	        <% Response.Write(styleManager.initializeTopNav()); %> 	
            <div id="content">
            	<asp:Panel id="content_left" runat="server">
                    <form id="formCreateAudeme" runat="server">

                        <div class="title">Dictionary</div>       
                        <table style="width: 780px;">
                            <tr>
                                <td style="width: 150px;">Search For:  </td>
                                <td>
                                    <asp:CheckBox style="width: 150px;" ID="chkAudemes" Text="Audemes" Checked="true" runat="server" Tooltip="Audemes are brief audio collages that combine sound effects to form aural symbols that signify various ideas." />
                                </td>
                                <td>
                                    <asp:CheckBox style="width: 150px;" ID="chkSoundEffects" Text="Atomic&nbsp;Sounds" runat="server"  Tooltip="Atomic Sounds are simple sounds that can be combined to create audemes." />
                                </td>
                                <td>
                                    <asp:CheckBox style="width: 330px;" ID="chkGrids" Text="Game&nbsp;Boards&nbsp;and&nbsp;Grids" runat="server" Tooltip="Grids are groups of audemes and atomic sounds organized in thematic groups."  />
                                </td>
                            </tr>
                        </table>             
                        <br />
                        <asp:TextBox ID="txtSearchTerm" Width="800" placeholder="What are you looking for?" runat="server"></asp:TextBox><br />
                        <asp:Button Text="Search" id="btnSearch" runat="server" OnClick="btnSearch_Click" />
                            

                        <asp:Panel ID="pnlResults" runat="server">
                            <asp:Panel ID="pnlResults_Default" runat="server">
                                <div class="title">Browse By Subject</div>
                                <ul>
                                        <li><asp:LinkButton ID="lnkSearch1" Text="Astronomy"  runat="server" OnClick="searchByTopic"></asp:LinkButton></li>
                                        <li><asp:LinkButton ID="lnkSearch2" Text="Biology" runat="server" OnClick="searchByTopic"></asp:LinkButton></li>
                                        <li><asp:LinkButton ID="lnkSearch3" Text="Chemistry" runat="server" OnClick="searchByTopic"></asp:LinkButton></li>
                                        <li><asp:LinkButton ID="lnkSearch5" Text="Geology" runat="server" OnClick="searchByTopic"></asp:LinkButton></li>
                                        <li><asp:LinkButton ID="lnkSearch6" Text="Physics" runat="server" OnClick="searchByTopic"></asp:LinkButton></li>
                                        <li><asp:LinkButton ID="LinkButton2" Text="Zoology" runat="server" OnClick="searchByTopic"></asp:LinkButton></li>
                                </ul>  
                            </asp:Panel>
                            <asp:Panel ID="pnlResults_Audemes" runat="server" Visible="false">
                                 <div class="title">Audemes</div>
                                 <div id="results_Audemes" runat="server"></div>
                            </asp:Panel>
                            <asp:Panel ID="pnlResults_SoundEffects" runat="server" Visible="false">
                                 <div class="title">Sound Effects</div>
                                 <div id="results_SoundEffects" runat="server"></div>
                            </asp:Panel>
                            <asp:Panel ID="pnlResults_Grids" runat="server" Visible="false">
                                 <div class="title">Grids and Game Boards</div>
                                 <div id="results_Grids" runat="server"></div>
                                 <asp:DataGrid ID="grdGrids" runat="server"></asp:DataGrid>
                            </asp:Panel>
                        </asp:Panel>
                    </form>    
                </asp:Panel> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\jhesch\includes\footer.html"--> 
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Dictionary')").addClass('current'); //Makes the proper top nav item selected
        $("#error").html(getParameterByName("error")); //Fills in any errors
    </script>
    </body>
</html>    
