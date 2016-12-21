using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class games_Riddles : System.Web.UI.Page
{
    public string strCategory = ""; 
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["riddleCategory"] != null)
        {
            strCategory = Session["riddleCategory"].ToString();
        }

        
        DataTable dtRiddles = dbManager.returnRiddlesByCategory(strCategory);
        if (dtRiddles.Rows.Count > 0)
        {
            displayRiddles(dtRiddles);
        }

        DataTable dtCategory = dbManager.returnRiddleCategories();
        if (dtCategory.Rows.Count > 0)
        {
            displayCategories(dtCategory);
        }
    }

    protected void onCategoryClicked(object sender, EventArgs e)
    {
        LinkButton lnkCategory = (LinkButton)sender;

        if (lnkCategory.Text == "All")
        {
            Session["riddleCategory"] = "";
        }
        else
        {
            Session["riddleCategory"] = lnkCategory.Text;
        }
        
        Page.Response.Redirect(Page.Request.Url.ToString(), false);
    }

    protected void displayRiddles(DataTable dtRiddles)
    {
        audemeViewer av = new audemeViewer();
        
        string strEasy = "";
        string strMedium = "";
        string strHard = "";

        foreach (DataRow dr in dtRiddles.Rows)
        {
            Audeme audeme = new Audeme();
            audeme.setName((string)dr["Title"]);
            audeme.setID((int)dr["Riddle_ID"]);

            if (dr["Text"] == DBNull.Value)
            {
                dr["Text"] = "";
            }

            audeme.setDescription((string)dr["Text"]);
            audeme.setFileName((string)dr["SoundName"]);
            
            string strRiddle = "";
            strRiddle += "<div class='riddle'>";

            strRiddle += "<div class='name showDetails' href><img class='expandIcon expand' alt='expand / collapse'>";
            strRiddle += dr["Title"];
            strRiddle += "</div>"; //End title / show details

            strRiddle += "<div class='details'>";
            
                strRiddle += "<p>Riddle:  " + dr["Text"] + "</p>";
                strRiddle += "<div class='answer'><br />Answer:  " + dr["Answer"] + "</div>";
                strRiddle += "<br />";

                strRiddle += audemeViewer.viewPlayLink(audeme);
                strRiddle += "<a class='showRiddleAnswer clickable' style='margin-left: 15px;'>Show / Hide Answer</a>";

            strRiddle += "</div>"; //End details

            strRiddle += "</div>"; //End riddle

            int Difficulty = (int)dr["Difficulty"];
            switch (Difficulty)
            {
            case 1:
                strEasy += strRiddle;
                break;
            case 2:
                strMedium += strRiddle;
                break;
            case 3:
                strHard += strRiddle;
                break;
            }
        }

        if (strEasy != "")
        {
            LiteralControl txtEasy = pnlEasy.Controls[0] as LiteralControl;
            txtEasy.Text = "<h2>Easy</h2>" + strEasy;
        }

        if (strMedium != "")
        {
            LiteralControl txtMedium = pnlMedium.Controls[0] as LiteralControl;
            txtMedium.Text = "<h2>Medium</h2>" + strMedium;
        }

        if (strHard != "")
        {
            LiteralControl txtHard = pnlHard.Controls[0] as LiteralControl;
            txtHard.Text = "<h2>Hard</h2>" + strHard;
        }

    }

    protected void displayCategories(DataTable dtCategories)
    {
        foreach (DataRow dr in dtCategories.Rows)
        {
            LinkButton lnkCategory = new LinkButton();
            lnkCategory.Text = dr["Categories"].ToString();
            lnkCategory.Click += new EventHandler(onCategoryClicked);
            pnlCategories.Controls.Add(lnkCategory);

            Label lblLineBreak = new Label();
            lblLineBreak.Text = "<br />";
            pnlCategories.Controls.Add(lblLineBreak);
        }
    }
}