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
         string password2 = Request.QueryString["password2"];
         string fName = Request.QueryString["fName"];
         string lName = Request.QueryString["lName"];
         string email = Request.QueryString["email"];
         string phone = Request.QueryString["phone"];
         string school = Request.QueryString["school"];
         string styleSheet = Request.QueryString["styleSheet"];
         
         string error = "";

         if (username.Length < 6 || username.Length > 16)
         {
             error += "Username must be between 6 and 16 characters.  ";
         }
         
         if (password.Length < 6 || password.Length > 16)
         {
             error += "Password must be between 6 and 16 characters.  ";
         }

         if (!password.Equals(password2, StringComparison.Ordinal))
         {
             error += "Passwords do not match.  ";
         }

         //If there are no other errors, verify that the username does not exist in the database already
         if (error == "")
         {
             if (dbManager.usernameExists(username))
             {
                 //If the username already exists, return an error
                 error += "Username already in use.  ";
             }             
         }
         
         //Create the account
         if ( error == "" )
         {
             dbManager.createAccount(username, password, fName, lName, email, phone, school, styleSheet);

             //Redirect the user to their previous page
             if (Session["PreviousPage"] != null)
             {
                 Response.Redirect(Session["PreviousPage"].ToString(), false);
             }
             else
             {
                 Response.Redirect("/jhesch/dashboard");
             }
         }
         else
         {
             Response.Redirect("/jhesch/createAccount.aspx?error=" + error);
         }
   %>
</body>
</html>
