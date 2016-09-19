<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
     <%        
        // Parses QueryString into usable variables
        string audemeID = Request.QueryString["audemeID"];
        string feedback = Request.QueryString["feedback"];

        string textToEmail = "";

        textToEmail += "Feedback has been submitted for audeme with ID " +  audemeID + ":<br />";
        textToEmail += feedback + "<br />";
        textToEmail += "Click here to go to the audeme page:  ";
        textToEmail += "<a href='http://audeme.informatics.iupui.edu/jhesch/audemefactsheet.aspx?AudemeID=" + audemeID + "'>Audeme Fact Sheet</a>";
        
                
        //Call methods that send email and
        emailManager.emailFormInfo(textToEmail);

        
        Response.Redirect("../contact/thankyou.aspx");
   %>
</body>
</html>
