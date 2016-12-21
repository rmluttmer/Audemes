<%@ Import Namespace="System.Text.RegularExpressions"%>

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
        string list_order = Request.Form["orderedList"];

        //Get the ids in a list out of the string that came in
        string[] audeme_ids = Regex.Split(list_order, @"\D+");
                
        int counter = 0;
                
        //Cycle through the list of audeme ids that came in
        foreach (string audeme_id in audeme_ids)
        {            
            if (!string.IsNullOrEmpty(audeme_id))
            {
                counter++;
                dbManager.reorderAudeme(user_id, audeme_id, counter);
            }
        }
    %>
</body>
</html>
