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
        string audemeID = Request.QueryString["AudemeID"].ToString();
        Response.Write(audemeID);
        short intAudemeID;
        //Get the current User ID
        if (Session["role_id"] != null)
        {
            string strRoleID = Session["role_id"].ToString();
            short roleID;
            if (Int16.TryParse(strRoleID, out roleID))
            {
                roleID = Int16.Parse(strRoleID);

                if (roleID >= 3)
                {
                    if (Int16.TryParse(audemeID, out intAudemeID)){                       
                        dbManager.unlockAudemeByID(audemeID);
                        Response.Redirect("/jhesch/dictionary/locked.aspx?Message=Audeme " + audemeID + " successfully unlocked.  Refresh to see the new list.");                        
                    }
                }
            }
        }        
   %>
</body>
</html>
