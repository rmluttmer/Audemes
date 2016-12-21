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
        string user_id;
        string sequence = Request.Form["sequenceSoundIDs"];
        string name = Request.Form["name"];
        string description = Request.Form["description"];
        string subject = Request.Form["subject"];

        //If not logged in, save to the guest account
        if (Session["user_id"] == null)
        {
            user_id = "7";
        }
        else
        {
            user_id = Session["user_id"].ToString();    
        }
        
        //Get the ids in a list out of the string that came in
        string[] sound_ids = Regex.Split(sequence, @"\D+");

        int sequence_id = dbManager.createSequence(user_id, name, description, subject);

        //Cycle through the list of sound ids that came in and add them to the sequence
        int counter = 0;
        foreach (string sound_id in sound_ids)
        {
            if (!string.IsNullOrEmpty(sound_id))
            {
                counter++;
                dbManager.addSoundToSequence(sequence_id, sound_id, counter);                
            }
        }

        dbManager.addToDashboard(user_id, sequence_id.ToString());
        
        //Redirect the user to their previous page
        if (Session["PreviousPage"] != null )
        {
            string successURL = Session["PreviousPage"].ToString() + "&Message=Your audeme has been successfully created and stored in your locker.";
            Response.Redirect(successURL, false);
        }
        
    %>
</body>
</html>

