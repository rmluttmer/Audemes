<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sequenceCreator-new.aspx.cs" Inherits="jhesch_contribute_sequenceCreator_new" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Create a Grid</title>
    <!--#Include virtual="~\includes\header.html"--> 
    <script type="text/javascript" src="/js/atomicTraining.js"></script>
    <script type="text/javascript" src="/js/jquery-ui-1.9.0.custom.min.js"></script>
    <%
        Response.Write(styleManager.initializeStyles());  
    %>
</head>
<body id="Body1" runat="server">
    <form id="frmCreateGrid" runat="server">
    <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	    <% Response.Write(styleManager.initializeTopNav()); %> 	
        <div id="content">
            <div id="content_left">

                <div class="title">Create a Grid</div>       
                    <br />
                    <p><b>Instructions</b>:  click the name of the audeme to add it to your sequence.  Sequences can contain up to five audemes. When you want to save the sequence, fill out the form at the bottom of the page and click "create."</p>
                    
                    <asp:GridView ID="grdAudemes" runat="server" AutoGenerateColumns="false" OnRowCommand="grdAudemes_OnRowCommand"
                     AllowPaging="true" PageSize="10" OnPageIndexChanging="grdAudemes_PageIndexChanging" >
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblAdd" runat="server" Text='<%# Eval("Name") %>'></asp:Label>&nbsp;-&nbsp;<asp:LinkButton ID="lnkAdd" Text='Add' CommandName="AddToSequence" CommandArgument='<%# Eval("ID") %>' runat="server"  ></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Set">
                                <ItemTemplate>
                                    <asp:Label ID="lblAudemes" Text='<%# Eval("Set") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                         </Columns>
                    </asp:GridView>
                    
                    <asp:Table ID="tblMySequence" runat="server" CssClass="audemeBlocks">
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
                    <asp:Label ID="Label1" runat="server">Name:  </asp:Label><asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <p>Description: </p> <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                    <p>Subject Area:  </p>  <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblError" runat="server" CssClass="error"></asp:Label><br />
                    <asp:Button  ID="btnSave" runat="server" Text="Save" OnClick="saveGrid" />
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="redirectToLogin" />        
                </div>
            <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\includes\footer.html"-->
    </div>
    
    </form>    
</body>
</html>
