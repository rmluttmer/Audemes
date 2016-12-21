<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changeTextSize.aspx.cs" Inherits="jhesch_formHandlers_changeTextSize" %>

<% 
    if (Session["style"] == null || Session["style"] == "largeText")
    {
        Session["style"] = "smallText";
    }
    else
    {
        Session["style"] = "largeText";
    }
%>