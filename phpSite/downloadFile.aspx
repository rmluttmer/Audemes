<%@ Page Language="C#" %>

<%
    //Get the fileName from the URL
    String fileName = "";
    if (Request.QueryString["fileName"] != null && Request.QueryString["fileName"] != "")
    {
        fileName = Request.QueryString["fileName"] + ".mp3";
        String fileNameAndPath = "/MP3s/audemes/" + fileName;
        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        HttpContext.Current.Response.ContentType = "application/octet-stream";
        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.mp3", fileName));
        HttpContext.Current.Response.WriteFile(fileNameAndPath);
    }

                    
%>   