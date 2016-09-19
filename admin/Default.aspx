<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="jhesch_admin_Default" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"--> 
        <title>Admin - Home</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
    <form runat="server">
        <div id="container">  
	        <% Response.Write(styleManager.initializeTopNav()); %> 	
            <div id="content">
            	<asp:Panel id="content_left" runat="server">

                    <div class="title">Administrator Home Page</div>                    
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    
                    <asp:HyperLink NavigateUrl="/default.aspx" Text="Audeme Home Page" ID="HyperLink1" runat="server"></asp:HyperLink>
                    <br /><br />
                    <asp:HyperLink NavigateUrl="/admin/locked.aspx" Text="View Locked Audemes" ID="lnkViewLocked" runat="server"></asp:HyperLink>
                    <br /><br />
                    <asp:HyperLink NavigateUrl="/admin/lockedSets.aspx" Text="View Locked Sets" ID="lnkViewLockedSets" runat="server"></asp:HyperLink>
                    <br /><br />

                    <h1>Reports</h1>

                    <asp:LinkButton ID="lnkReport_AudemeActivity" Text="Audeme Activity" OnClick="Report_AudemeActivity" runat="server"></asp:LinkButton>
                    -
                    <asp:LinkButton ID="lnkExport_AudemeActivity" Text="Download" OnClick="Export_AudemeActivity" runat="server"></asp:LinkButton> - This report shows how many times particular audemes have been played / rated as well as the average ratings.
                    <br />
                    <asp:LinkButton ID="lnkReport_AudemesInGrids" Text="Audemes In Grids" OnClick="Report_AudemesInGrids" runat="server"></asp:LinkButton>
                    -
                    <asp:LinkButton ID="lnkExport_AudemesInGrids" Text="Download" OnClick="Export_AudemesInGrids" runat="server"></asp:LinkButton> - This report shows in which columns and grids each audeme is being used.
                    <br /><br /><asp:GridView ID="grdReports" runat="server"></asp:GridView>
                </asp:Panel> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\includes\footer.html"--> 
    </div> <!-- end of container -->
    </form>    
    <script type="text/javascript">
        $("a:contains('Dictionary')").addClass('current'); //Makes the proper top nav item selected
        $("#error").html(getParameterByName("error")); //Fills in any errors
    </script>
    </body>
</html>    
