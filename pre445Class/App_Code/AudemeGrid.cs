using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// The AudemeGrid class is the base class for the jeopardy style game show.  
///     It contains AudemeGridColumns, which have titles and a list of AudemeGridCells.  
///     AudemeGridCells contain information for individual audemes.
/// </summary>
public class AudemeGrid
{
    //Variable declaration
    private string name;
    private int numColumns;
    private int numRows;
    private List<AudemeGridColumn> listColumns;

    //Constructors
    public AudemeGrid(string name, int numColumns, int numRows)
	{
        this.name = name;
        this.numColumns = numColumns;
        this.numRows = numRows;
        this.listColumns = new List<AudemeGridColumn>();
        this.listColumns.Capacity = numColumns;
	}

    public AudemeGrid()
    {
        this.listColumns = new List<AudemeGridColumn>();
        this.listColumns.Capacity = numColumns;
    }

    //Get and Set functions
    public List<AudemeGridColumn> getColumns()
    {
        return this.listColumns;
    }

    public AudemeGridColumn getColumn(int index)
    {
        return this.listColumns[index];
    }

    public void setColumn(int index, AudemeGridColumn column)
    {
        this.listColumns.Insert(index, column);
    }

    public string getName()
    {
        return this.name;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public int getnumColumns()
    {
        return this.numColumns;
    }

    public void setnumColumns(int numColumns)
    {
        this.numColumns = numColumns;
    }

    public int getnumRows()
    {
        return this.numRows;
    }

    public void setnumRows(int numRows)
    {
        this.numRows = numRows;
    }

    public static string viewAddToDashboardLink(int audemeGridID)
    {
        string returnHTML = "";

        if (HttpContext.Current.Session["user_id"] == null)
        {
            returnHTML += "<a class='promptAuthentication clickable'>Add to Locker</a>";
        }
        else
        {
            if (dbManager.isAudemeGridInDashboard(HttpContext.Current.Session["user_id"].ToString(), audemeGridID.ToString()))
            {
                //If audeme is in the user's dashboard, let them know
                returnHTML += "<a>(in Locker)</a>";
            }
            else
            {
                //If audeme is not in the user's dashboard, let them add it
                returnHTML += "<a class='addGridToDashboard clickable' id='" + audemeGridID + "'>Add to Locker</a>";
            }
        }

        return returnHTML;
    }

    public static string viewRemoveFromDashboardLink(int audemeGridID)
    {
        string returnHTML = "";

        if (HttpContext.Current.Session["user_id"] == null)
        {
            returnHTML += "<a class='promptAuthentication clickable'>Add to Locker</a>";
        }
        else
        {
            if (dbManager.isAudemeGridInDashboard(HttpContext.Current.Session["user_id"].ToString(), audemeGridID.ToString()))
            {
                //If audeme is in the user's dashboard, let them know
                returnHTML += "<a>(in Locker)</a>";
            }
            else
            {
                //If audeme is not in the user's dashboard, let them add it
                returnHTML += "<a class='addGridToDashboard clickable' id='" + audemeGridID + "'>Add to Locker</a>";
            }
        }

        return returnHTML;
    }
}