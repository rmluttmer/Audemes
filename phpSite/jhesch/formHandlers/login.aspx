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
        string username = Request.QueryString["username"];
        string password = Request.QueryString["password"];

        //Send the user to the correct next page based on whether login was successful and whether "Previous Page" is specified
        if (dbManager.login(username, password))
        {            
            if (Session["PreviousPage"] != null)        
            {
                Response.Redirect(Session["PreviousPage"].ToString());
            }
            else
            {
                Response.Redirect("/jhesch/dashboard/Default.aspx");
            }
        }
        else 
        {
            Response.Redirect("/jhesch/login.aspx/?error=Username and password do not match.");
        }
        
   %>
</body>
</html>
