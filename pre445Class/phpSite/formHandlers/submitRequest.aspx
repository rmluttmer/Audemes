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
        string fName = Request.QueryString["fName"];
        string lName = Request.QueryString["lName"];
        string email = Request.QueryString["email"];
        string request = Request.QueryString["request"];

        string textToEmail;

        textToEmail = fName + " " + lName + " has submitted an audeme request form. <br /><br />Contact Information:<br />";
        textToEmail += "Name: " + fName + " " + lName + "<br />";
        textToEmail += "Email Address: " + email + "<br />";
	textToEmail += "Request:<br />" + request;
                
        //Call methods that send email and
        emailManager.emailFormInfo(textToEmail);

        
        Response.Redirect("../contact/thankyou.aspx");
   %>
</body>
</html>
