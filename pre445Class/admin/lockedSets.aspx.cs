using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class jhesch_admin_lockedSets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Set this page as the "Previous Page" so that the user can be redirected here when they save an audeme or log in
        Session["PreviousPage"] = Request.Url.ToString();
        string strMessage = "";

        //Get the current User ID
        if (Session["role_id"] != null)
        {
            string strRoleID = Session["role_id"].ToString();
            short roleID;
            if (Int16.TryParse(strRoleID, out roleID))
            {
                roleID = Int16.Parse(strRoleID);

                if (roleID >= 3)
                {
                    //Searches the database
                    DataTable dt = new DataTable();
                    dt = dbManager.returnAudemeCols();

                    DataRow[] foundRows;

                    DataTable dtFormatted = new DataTable();
                    dtFormatted.Columns.Add("ID");
                    dtFormatted.Columns.Add("Name");
                    dtFormatted.Columns.Add("Audemes");
                    dtFormatted.Columns.Add("Type");
                    DataRow drFormatted;

                    String strSearch = "";

                    //Adds the AudemeColumns to the grid
                    foreach (DataRow dr in dt.Rows)
                    {
                        strSearch = "ID = '" + dr["AudemeCol_id"].ToString() + "'";
                        foundRows = dtFormatted.Select(strSearch);

                        if (foundRows.Length == 0)
                        {
                            drFormatted = dtFormatted.NewRow();
                            drFormatted["ID"] = dr["AudemeCol_id"].ToString();
                            drFormatted["Name"] = dr["ColName"].ToString();
                            drFormatted["Audemes"] = dr["AudemeName"].ToString();


                            if (dr["locked"].ToString() == "True")
                            {
                                dtFormatted.Rows.Add(drFormatted);
                                drFormatted["Type"] = "User&nbsp;Set";
                            }
                        }
                        else
                        {
                            foundRows[0]["Audemes"] += ", " + dr["AudemeName"].ToString();
                        }
                    }

                    grdColumns.DataSource = dtFormatted;
                    grdColumns.DataBind();
                }
                else
                {
                    strMessage += "Access Denied.  This page is for system administrators only.";
                }
            }
            else
            {
                strMessage += "Invalid role id.  ";
            }
        }
        else
        {
            strMessage += "<a href='/login.aspx'>Please log in</a>.  ";
        }

        if (Request.QueryString["Message"] != null)
        {
            strMessage += Request.QueryString["Message"].ToString();
        }
    }

    public void grdColumns_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        dbManager.unlockAudemeColByID(e.CommandArgument.ToString());
        Response.Redirect(Session["PreviousPage"].ToString());
    }
}