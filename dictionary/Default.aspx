<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="jhesch_dictionary_Default3" %>

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
            	<asp:Panel id="content_left" runat="server">
                    <form id="formCreateAudeme" runat="server">

                        <div class="title">Dictionary</div>       
                        <table style="width: 780px;">
                            <tr>
                                
                                <td style="width: 490px;">
                                    Enter your search term here:<br />
                                    <asp:TextBox Width="350" ID="txtSearchTerm" placeholder="What are you looking for?" runat="server"></asp:TextBox>
                                    <asp:CheckBox ID="chkAudemes" Text="Audemes" Checked="true" Visible='false' runat="server" Tooltip="Audemes are brief audio collages that combine sound effects to form aural symbols that signify various ideas." />
                                    <asp:CheckBox ID="chkSoundEffects" Text="Atomic&nbsp;Sounds" Checked='true' Visible='false' runat="server"  Tooltip="Atomic Sounds are simple sounds that can be combined to create audemes." />
                                    <asp:CheckBox ID="chkGrids" Text="Game&nbsp;Boards&nbsp;and&nbsp;Grids" Visible="false" runat="server" Tooltip="Grids are groups of audemes and atomic sounds organized in thematic groups."  />
                                    <asp:Button Text="Search" id="btnSearch" runat="server" OnClick="btnSearch_Click" />
                                </td>
                                <td style="width: 290px;">
                                    Browse By Subject
                                    <ul>
                                            <li><asp:LinkButton ID="lnkSearch1" Text="Astronomy"  runat="server" OnClick="searchByTopic"></asp:LinkButton></li>
                                            <li><asp:LinkButton ID="lnkSearch2" Text="Biology" runat="server" OnClick="searchByTopic"></asp:LinkButton></li>
                                            <li><asp:LinkButton ID="lnkSearch3" Text="Chemistry" runat="server" OnClick="searchByTopic"></asp:LinkButton></li>
                                            <li><asp:LinkButton ID="lnkSearch5" Text="Geology" runat="server" OnClick="searchByTopic"></asp:LinkButton></li>
                                            <li><asp:LinkButton ID="lnkSearch6" Text="Physics" runat="server" OnClick="searchByTopic"></asp:LinkButton></li>
                                            <li><asp:LinkButton ID="LinkButton2" Text="Zoology" runat="server" OnClick="searchByTopic"></asp:LinkButton></li>
                                    </ul>  
                                </td>
                            </tr>
                        </table>             
                        <br />
                        
                        
                            

                        <asp:Panel ID="pnlResults" runat="server">
                            <asp:Panel ID="pnlResults_Default" runat="server">
                                
                            </asp:Panel>
                            <asp:Panel ID="pnlResults_Audemes" runat="server" Visible="false">
                                 <div class="title">Audemes</div>
                                 <asp:Label ID="lblAudemeCount" runat="server"></asp:Label>
                                 <div id="results_Audemes" runat="server"></div>
                            </asp:Panel>
                            <asp:Panel ID="pnlResults_SoundEffects" runat="server" Visible="false">
                                 <div class="title">Atomic Sounds</div>
                                 <asp:Label ID="lblSoundEffectCount" runat="server"></asp:Label>
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
               
        <!--#Include virtual="~\includes\footer.html"--> 
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Dictionary')").addClass('current'); //Makes the proper top nav item selected
        $("#error").html(getParameterByName("error")); //Fills in any errors
    </script>
    </body>
</html>    
