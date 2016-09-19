<%@ Page Language="C#" AutoEventWireup="true" CodeFile="audemeCorrect.aspx.cs" Inherits="jhesch_formHandlers_audemeCorrect" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
         <title>Receive Correct Info</title>
</head>
<body>
    <%
        // Parses QueryString into usable variables
        string audemeID = Page.Request.QueryString["audemeID"];
        string correct = Page.Request.QueryString["correct"];
        dbManager.audemeCorrect(audemeID, correct);
        
    %>
</body>
</html>
