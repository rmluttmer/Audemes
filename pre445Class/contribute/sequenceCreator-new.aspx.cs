using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class jhesch_contribute_sequenceCreator_new : System.Web.UI.Page
{
    protected User myUser = new User();
    protected List<Int16> myColumnList = new List<Int16>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_id"] != null && Session["user_id"] != "")
        {
            myUser.setUserID(Int16.Parse(Session["user_id"].ToString()));
            btnLogin.Visible = false;    
        }
        else
        {
            btnLogin.Visible = true;    
        }

        if (ViewState["columns"] != null)
        {
            myColumnList = (List<Int16>)ViewState["columns"];
        }

        lblError.Text = "";
        bindgrdAudemes();
    }

    protected void bindgrdAudemes()
    {
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

                //Audeme Col Type:  1 = Game Set, 2 = Toolbox Set, 3 = User Generated
                short intAudemeColTypeID = 0;
                if ( Int16.TryParse(dr["AudemeColTypeID"].ToString(), out intAudemeColTypeID ) )
                {
                    intAudemeColTypeID = Int16.Parse(dr["AudemeColTypeID"].ToString());
                }
                
            }
            else
            {
                foundRows[0]["Audemes"] += ", " + dr["AudemeName"].ToString();
            }
        }

        grdAudemes.DataSource = dtFormatted;
        grdAudemes.DataBind();

    }

    protected void grdAudemes_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "AddToGrid")
        {
            if (myColumnList.Count < 5)
            {
                GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                Label lblSource = (Label)row.FindControl("lblSource");

                myColumnList.Add(Int16.Parse(e.CommandArgument.ToString()));
                ViewState["columns"] = myColumnList;
                renderMyGrid();
            }
            else
            {
                lblError.Text = "Maximum number of columns exceeded.  Limit:  5.";
            }
        }
    }

    protected void renderMyGrid()
    {
        DataTable dtColumn = new DataTable();

        DataTable dtColumnFormatted;
        
        DataRow drColumnFormatted;
        
        GridView gvCurrentColumn;
        LinkButton lbCurrentRemove;

        //Cycle through the current list of columns that have been added to the grid
        for (int i = 0; i < 5; i++)
        {
            //Get the current column and remove link
            gvCurrentColumn = (GridView)tblMySequence.FindControl("grdCol" + i);
            lbCurrentRemove = (LinkButton)tblMySequence.FindControl("lnkRemove" + i);
            
            //If there is a column in the current index, format and show the grid and remove link
            if (i < myColumnList.Count)
            {
                dtColumnFormatted = new DataTable();
                dtColumnFormatted.Columns.Add();

                //Show the remove link
                lbCurrentRemove.Visible = true;
                gvCurrentColumn.Visible = true;

                //Get the audeme column info based on the ID
                //TODO - update this to check if it's user generated
                dtColumn = dbManager.returnAudemeCol_ByID(myColumnList[i]);

                string colName = dtColumn.Rows[0]["ColName"].ToString();

                drColumnFormatted = dtColumnFormatted.NewRow();
                drColumnFormatted[0] = dtColumn.Rows[0]["ColName"].ToString();
                dtColumnFormatted.Rows.Add(drColumnFormatted);

                foreach (DataRow dr in dtColumn.Rows)
                {
                    drColumnFormatted = dtColumnFormatted.NewRow();
                    drColumnFormatted[0] = dr["AudemeName"].ToString();
                    dtColumnFormatted.Rows.Add(drColumnFormatted);
                }

                gvCurrentColumn.ShowHeader = false;
                gvCurrentColumn.DataSource = dtColumnFormatted;
                gvCurrentColumn.DataBind();
            }
            else
            {
                gvCurrentColumn.Visible = false;
                lbCurrentRemove.Visible = false;
            }
    
        }
    }    

    protected void grdAudemes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAudemes.PageIndex = e.NewPageIndex;
        grdAudemes.DataBind();
    }

    protected void removeColumn(object sender, CommandEventArgs e)
    {
        myColumnList.RemoveAt(Int16.Parse(e.CommandArgument.ToString()));
        
        ViewState["columns"] = myColumnList;
        renderMyGrid();
    }

    protected void redirectToLogin(object sender, EventArgs e)
    {
        Response.Redirect("/login.aspx");
    }

    protected void saveGrid(object sender, EventArgs e)
    {
        string strError = "";
        
        if (myColumnList.Count == 0)
        {
            strError += "Must have at least one column in the grid.  ";
        }

        if (txtName.Text.Trim() == "")
        {
            strError += "Grid name required.";
        }

        if (strError != "")
        {
            lblError.Text = strError;
            return;
        }

        int[] colIDs = new int[5];

        for (int i = 0; i < myColumnList.Count; i++)
        {
            if (myColumnList.Count > i)
            {
                colIDs[i] = myColumnList[i];
            }
        }

        int GridID = dbManager.createGrid(txtName.Text, myColumnList.Count, colIDs);

        if (myUser.getUserID() > 0)
        {
            dbManager.addToDashboard_Grid(myUser.getUserID().ToString(), GridID.ToString());
        }

        Response.Redirect("gridSuccess.aspx?GridID=" + GridID);
    }
}