<%@ Page Language="C#" AutoEventWireup="true" CodeFile="oldRiddles.aspx.cs" Inherits="games_Riddles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!--#Include virtual="~\includes\header.html"--> 
    <script type="text/javascript" src="/js/playListPlayer.js"></script>
    <title>Riddles</title>
    <% Response.Write(styleManager.initializeStyles());  %>
    <script type="text/javascript" src="/js/browserWarning.js"></script>
    <link href="/css/Riddles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="frmRiddles" runat="server">
        <div id="container">  
	        <%  Response.Write(styleManager.initializeTopNav()); %>
            <div id="content">
            	<div id="content_left">
                    <asp:Panel ID="pnlCategories" runat="server" CssClass="Categories">
                        <h2>Categories</h2>
                        <asp:LinkButton ID="LinkButton5" runat="server" OnClick='onCategoryClicked'>All</asp:LinkButton><br />
                    </asp:Panel>

                    <asp:Panel ID="pnlRiddles" runat="server" CssClass="Riddles">
                        <asp:Panel ID="pnlEasy" runat="server">
                        </asp:Panel>
                        <asp:Panel ID="pnlMedium" runat="server">
                        </asp:Panel>
                        <asp:Panel ID="pnlHard" runat="server">
                        </asp:Panel>
                    </asp:Panel>

                </div> <!-- End of Content_Left -->
                <div id="bottom_bg"></div>
            </div> <!-- end of content -->
            <!--#Include virtual="~\includes\footer.html"--> 
        </div> <!-- end of container -->
    </form>
</body>
</html>
