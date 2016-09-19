using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class jhesch_admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lnkViewLocked.Visible = false;
        lblMessage.Text = "Access Denied.  Please <a href='/jhesch/login.aspx'>log in as an administrator</a> to view this page.";

        if (Session["user_id"] != null)
        {
            User curUser = dbManager.returnUserInfo(Session["user_id"].ToString());

            if (curUser.getRoleID() >= 4)
            {
                lblMessage.Visible = false;
                lnkViewLocked.Visible = true;
            }
        }
    }

    protected void Report_AudemeActivity(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = dbManager.report_AudemeActivity();

        grdReports.DataSource = dt;
        grdReports.DataBind();
    }

    protected void Export_AudemeActivity(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = dbManager.report_AudemeActivity();
        exportReport(dt, "AudemeActivity");
    }

    protected void Report_AudemesInGrids(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = dbManager.report_AudemesInGrids();

        grdReports.DataSource = dt;
        grdReports.DataBind();
    }

    protected void Export_AudemesInGrids(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = dbManager.report_AudemesInGrids();
        exportReport(dt, "AudemesInGrids");
    }


    protected void exportReport(DataTable dt, String ReportName)
    {
        string attachment = "attachment; filename=" + ReportName + ".csv";
        Response.ClearContent();
        Response.AddHeader("content-disposition", attachment);
        Response.ContentType = "application/vnd.ms-excel";
        string tab = "";
        foreach (DataColumn dc in dt.Columns)
        {
            Response.Write(tab + dc.ColumnName);
            tab = ",";
        }
        Response.Write("\n");
        int i;
        foreach (DataRow dr in dt.Rows)
        {
            tab = "";
            for (i = 0; i < dt.Columns.Count; i++)
            {
                string output = dr[i].ToString().Replace(",", "-");
                Response.Write(tab + output);
                tab = ",";
            }
            Response.Write("\n");
        }
        Response.End();
    }
}