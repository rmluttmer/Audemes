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
        string audemeGrid_id = Request.QueryString["audemeGrid_id"];

        
        if (!dbManager.isAudemeGridInDashboard(user_id, audemeGrid_id))
        {
            //If audeme is not in the user's dashboard, add it
            dbManager.addToDashboard_Grid(user_id, audemeGrid_id);
        }             
   %>
</body>
</html>
