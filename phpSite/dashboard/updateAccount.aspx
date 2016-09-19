<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateAccount.aspx.cs" Inherits="jhesch_UpdateAccount" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"--> 
        <title>Update Account</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
        <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	        <% Response.Write(styleManager.initializeTopNav()); %> 	
            <div id="content">
            	<asp:Panel id="content_left" runat="server">

                    <div class="title">Update Account Details</div>                    
                
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>

                    <form runat="server">
                        
                        <table>
                            <colgroup>
                                <col style="width: 650px" />
                                <col style="width: 650px" />
                            </colgroup>
                            <tr>
                                <td>Password (6-16 characters)</td>
                                <td>
                                    <asp:TextBox ID="password" MaxLength="16" placeholder="Letters &amp; Numbers Only" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Password (re-enter)
                                </td>
                                <td>
                                    <asp:TextBox ID="password2" MaxLength="16" placeholder="Letters &amp; Numbers Only" runat="server"></asp:TextBox><br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    First Name*
                                </td>
                                <td>
                                    <asp:TextBox ID="fName" required="required" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Last Name*
                                </td>
                                <td>
                                    <asp:TextBox ID="lName" required="required" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Email*
                                </td>
                                <td>
                                    <asp:TextBox ID="email" required="required" type="email" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Phone*
                                </td>
                                <td>
                                    <asp:TextBox ID="phone" type="tel" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    School
                                </td>
                                <td>
                                    <asp:TextBox ID="school" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Text Size
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="styleSheet" runat="server">
                                        <asp:ListItem Value="smallText"><span style="font-size: 11px;">Small (11px)</span></asp:ListItem>
                                        <asp:ListItem Value="largeText"><span style="font-size: 24px;">Large (24px)</span></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                        
                        <asp:button OnClick="Submit_Click" Text="Update" runat="server"/>
                        
                        <br /><br />

                        <label style="width: 500px;">* required field</label>
                    </form>            
                </asp:Panel> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\includes\footer.html"--> 
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Account')").addClass('current'); //Makes the proper top nav item selected
        $("#error").html(getParameterByName("error")); //Fills in any errors
    </script>
    </body>
</html>    
