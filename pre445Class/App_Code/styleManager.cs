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

    public static string initializeTopNav(bool blnDisplayPageTitle)
    {
        string strTopNav = "";

        if (blnDisplayPageTitle)
        {
            strTopNav += "<div id='title'>";
            strTopNav += "<div id='titleText'><img src='../images/audeme_word_logo.png' alt='audemes'></div>";
            strTopNav += "</div> <!-- end of title -->";
            
        }

        strTopNav += "<div id='menu'>";
        strTopNav += "<ul>";

        if (HttpContext.Current.Session["user_id"] == null)
        {
            strTopNav += "<li><a href='/Default.aspx'>Home<br /><span></span></a></li>";
            strTopNav += "<li><a href='/games/Riddle/forms/riddle_search.php'>Game<br /><span></span></a></li>";
            strTopNav += "<li><a href='/dictionary'>Dictionary<br /><span></span></a></li>";
            ///strTopNav += "<li><a href='/createAccount.aspx'>New Account<br /><span></span></a></li> ";
            strTopNav += "<li><a href='/login.aspx'>Log In<br /><span></a></li>  ";
        }
        else
        {
            User curUser = dbManager.returnUserInfo(HttpContext.Current.Session["user_id"].ToString());

            if (curUser.getRoleID() >= 4)
            {
                strTopNav += "<li><a href='/admin/'>Admin</a></li>";
                ///strTopNav += "<li><a href='/games/Riddle/forms/riddle_search.php'>Game<br /></a></li>";
                strTopNav += "<li><a href='/contribute/default.aspx'>Create<br /></a></li>";
            }
            else
            {
                strTopNav += "<li><a href='/Default.aspx'>Home<br /></a></li>";
            }
            /// strTopNav += "<li><a href='/games/default.aspx'>Games<br /></a></li>";
            strTopNav += "<li><a href='/dictionary'>Dictionary<br /></a></li>";
            strTopNav += "<li><a href='/dashboard'>My Locker<br /></a></li> ";
            strTopNav += "<li><a href='/formHandlers/logout.aspx'>Log Out<br /></a></li>  ";
        }

        strTopNav += "</ul>";
        strTopNav += "</div> <!-- end of menu -->";

        return strTopNav;
    }

    public static string initializeTopNav()
    {
        return initializeTopNav(true);
    }
}