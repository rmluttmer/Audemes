<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newHome.aspx.cs" Inherits="jhesch_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <!--#Include virtual="~\includes\header.html"-->
    <title>Audemes</title>
    <% 
        Response.Write(styleManager.initializeStyles());  
    %>
    <link href="/css/Riddles.css" rel="stylesheet" type="text/css" />
</head>
    <body>
        <div id="container"> 
            <% Response.Write(styleManager.initializeTopNav()); %> 
            
            
            <div id="content">
            	
                <div id="content_left">
                
        	        <div class="title">Listen with your what?</div>
                    
                    <table style="width: 75%; height: 50px; color: #FFFFFF">
                        <tr>
                            <td style="background-color: #550000;">Games</td>
                            <td style="background-color: #005500;">About</td>
                            <td style="background-color: #000055;">Create</td>
                        </tr>
                    </table>
                    
                    <asp:Panel ID="pnlRiddle" runat="server" riddleID="4" CssClass="Riddles">
                    </asp:Panel>

                </div> <!-- end of content left -->
                
                <div id="bottom_bg"></div>
            </div> <!-- end of content -->
            
            <!--#Include virtual="~\includes\footer.html"--> 
        </div> <!-- end of container -->
        
        <script type="text/javascript">
            $("a:contains('Home')").addClass('current'); //Makes the proper top nav item selected
        </script>
    </body>
</html>