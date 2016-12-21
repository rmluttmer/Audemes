using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class jhesch_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dtRiddle = new DataTable();
        int riddleID = Int16.Parse(pnlRiddle.Attributes["riddleID"].ToString());
        dtRiddle = dbManager.returnRiddlesByID(riddleID);
        
        if ( dtRiddle.Rows.Count > 0 ) 
        {
            audemeViewer av = new audemeViewer();
            Audeme audeme = new Audeme(riddleID);
            LiteralControl txtRiddle = pnlRiddle.Controls[0] as LiteralControl;
            DataRow dr = dtRiddle.Rows[0];
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
            txtRiddle.Text = strRiddle;
        }
    }
}