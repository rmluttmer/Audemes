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
        string user_id = Session["user_id"].ToString();
        string name = Request.QueryString["sessionName"].ToString();

        dbManager.createSession(user_id, name);

    ///Redirect the user to their previous page
     if (Session["PreviousPage"] != null )
    {
        string successURL = Session["PreviousPage"].ToString() + "?Message=Session%20Created%20Successfully";
        Response.Redirect(successURL, false);
    }
        
    %>
</body>
</html>

