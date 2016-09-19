using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Defaultsplash : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie myCookie = new HttpCookie("SkipSplashPage");

        myCookie = Request.Cookies["SkipSplashPage"];

        if (myCookie != null)
        {
            if (myCookie.Value == "True")
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    protected void skipIntro(object sender, EventArgs e)
    {
        HttpCookie myCookie = new HttpCookie("SkipSplashPage");

        myCookie.Value = chkSkipIntro.Checked.ToString();

        Response.Cookies.Add(myCookie);

        Response.Redirect("Default.aspx");
    }
}