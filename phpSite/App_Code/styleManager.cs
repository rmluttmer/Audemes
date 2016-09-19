using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
///     Handles swapping between styles (e.g., Large Text, Small Text)
/// </summary>
public static class styleManager
{
    public static string initializeStyles()
    {
        if (HttpContext.Current.Session["styleSheet"] != null)
        {
            if (HttpContext.Current.Session["styleSheet"].ToString() == "smallText")
            {
                return "";
            }
            else
            {
                return "<link href='/css/largetext.css' rel='stylesheet' type='text/css' />";
            }
        }
        return "";
    }

    public static string initializeTopNav()
    {
        string strTopNav = "";

        strTopNav += "<div id='title'>";
        strTopNav += "<div id='titleText'>Audemes</div>";
        strTopNav += "</div> <!-- end of title -->";
        strTopNav += "<div id='menu'>";
        strTopNav += "<ul>";
        
        if ( HttpContext.Current.Session["user_id"] == null )
        {
            strTopNav += "<li><a href='/Default.aspx'>Home<br /><span>what is new</span></a></li>";
            strTopNav += "<li><a href='/dictionary'>Dictionary<br /><span>our library</span></a></li>";
            strTopNav += "<li><a href='/games/default.aspx'>Games<br /><span>have fun</span></a></li>";
            strTopNav += "<li><a href='/contribute/default.aspx'>Create<br /><span>make your own</span></a></li>";
            strTopNav += "<li><a href='/createAccount.aspx'>New Account<br /><span>join us</span></a></li> ";
            strTopNav += "<li><a href='/login.aspx'>Log In<br /><span>welcome back</a></li>  ";
        } 
        else
        {
            User curUser = dbManager.returnUserInfo(HttpContext.Current.Session["user_id"].ToString());

            if (curUser.getRoleID() >= 4)
            {
                strTopNav += "<li><a href='/admin/'>Admin Home</a></li>";
            }
            else
            {
                strTopNav += "<li><a href='/Default.aspx'>Home<br /><span>what is new</span></a></li>";
            }

            strTopNav += "<li><a href='/dictionary'>Dictionary<br /><span>our library</span></a></li>";
            strTopNav += "<li><a href='/games/default.aspx'>Games<br /><span>have fun</span></a></li>";
            strTopNav += "<li><a href='/contribute/default.aspx'>Create<br /><span>make your own</span></a></li>";
            strTopNav += "<li><a href='/dashboard'>My Account<br /><span>settings and content</span></a></li> ";
            strTopNav += "<li><a href='/formHandlers/logout.aspx'>Log Out<br /><span>come back</span></a></li>  ";
        }

        strTopNav += "</ul>";
        strTopNav += "</div> <!-- end of menu -->";
        
        return strTopNav;
    }
}