<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lockedSets.aspx.cs" Inherits="jhesch_admin_lockedSets" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Locked Sets</title>
    <!--#Include virtual="~\includes\header.html"--> 
    <script type="text/javascript" src="/js/atomicTraining.js"></script>
    <script type="text/javascript" src="/js/jquery-ui-1.9.0.custom.min.js"></script>
    <%
        Response.Write(styleManager.initializeStyles());  
    %>
</head>
<body>
    <form id="form1" runat="server">
    <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	    <% Response.Write(styleManager.initializeTopNav()); %> 	
        <div id="content">
            <div id="content_left">
                <div class="title">Locked Sets</div>
                    
                <asp:GridView ID="grdColumns" runat="server" AutoGenerateColumns="false" OnRowCommand="grdColumns_OnRowCommand" >
                    <Columns>
                        <asp:TemplateField HeaderText="Set Name">
                            <ItemTemplate>
                                <asp:Label ID="lblAdd" runat="server" Text='<%# Eval("Name") %>'></asp:Label>&nbsp;-&nbsp;<asp:LinkButton ID="lnkUnlock" Text='Unlock' CommandName="Unlock" CommandArgument='<%# Eval("ID") %>' runat="server"  ></asp:LinkButton>
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
                    
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\includes\footer.html"-->
    </div>
    </form>
</body>
</html>
