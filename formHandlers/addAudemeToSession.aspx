<%@ Page Language="C#" %>
<%@ Import Namespace="System.Data" %>
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
        string session_id = Request.QueryString["session_id"].ToString();
        string audeme_id = Request.QueryString["audeme_id"].ToString();

        string strResponse = "";

        if (dbManager.checkSession_ForUserSessionMatch(session_id, user_id))
        {
            DataTable agc = dbManager.returnAudemeCol_ByID(Int16.Parse(session_id));
            int position = agc.Rows.Count + 1;

            dbManager.addAudemeToSession(session_id, audeme_id, user_id, position);
            strResponse = "Audeme%20" + audeme_id + "%20added%20to%20set%20" + session_id + ".";
        }
        else
        {
            strResponse = "Set%20does%20not%20belong%20to%20current%20user";
        }
        //Redirect the user to their previous page
        if (Session["PreviousPage"] != null)
        {
            string successURL = Session["PreviousPage"].ToString() + "?Message=" + strResponse;
            Response.Redirect(successURL, false);
        }

    %>
</body>
</html>

