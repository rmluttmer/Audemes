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
        string audeme_id = Request.QueryString["audeme_id"];

        dbManager.removeFromDashboard(user_id, audeme_id);
   %>
</body>
</html>
