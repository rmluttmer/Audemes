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
         string error = "";
         
         string tags = Request.Form["tags"];
         string fileName = Request.Form["mp3"];
         string name = Request.Form["name"];
         string description = Request.Form["description"];
         short userID = 0;
         string strUserID;
         
         //Get the current User ID
         if (Session["user_id"] != null)
         {
             strUserID = Session["user_id"].ToString();
             if (Int16.TryParse(strUserID, out userID))
             {
                 userID = Int16.Parse(strUserID);
             }
             else
             {
                 error += "Invalid user id.  ";
             }
         }
         else
         {
             error += "Please log in.";
         }

         DateTime dateTime = DateTime.Now;
         string soundComposition = Request.Form["soundComposition"];
        
         ///Create the audeme if there are no errors
         if ( error == "" )
         {
             int audemeID = dbManager.createAudeme(tags, fileName, name, description, userID, dateTime, soundComposition);
             dbManager.addToDashboard(userID.ToString(), audemeID.ToString());
             
             Response.Redirect("/jhesch/createAudeme.aspx?error=Audeme '" + name + "' created successfully.");
             
         }
         else
         {
             Response.Redirect("/jhesch/createAudeme.aspx?error=" + error);
         }
   %>
</body>
</html>
