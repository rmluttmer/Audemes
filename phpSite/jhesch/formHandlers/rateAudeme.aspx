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
        
        string audeme_id = Request.QueryString["audeme_id"];
        string concept_rating = Request.QueryString["concept"];
        string component_rating = Request.QueryString["components"];

        dbManager.rateAudeme(audeme_id, concept_rating, component_rating);

        string strURL = Session["PreviousPage"].ToString() + "?Message=Rating recorded.  Thank you for your feedback!";

        Response.Redirect(strURL);
   %>
</body>
</html>
