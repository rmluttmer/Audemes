using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class jhesch_contribute_gridCreator : System.Web.UI.Page
{
    protected User myUser = new User();
    protected List<audemeSession> mySessionList = new List<audemeSession>();
    protected OrderedDictionary myAudemeDictionary = new OrderedDictionary();
    protected droppableGrid dg;
    
protected void Page_Load(object sender, EventArgs e)
    {
        Session["user_id"] = 2;
    
        if (Session["user_id"] != null && Session["user_id"] != "")
        {
            myUser.setUserID(Int16.Parse(Session["user_id"].ToString()));
            mySessionList = myUser.getAudemeSessionList(myUser.getUserID());
            renderUserSequences();
        }

        if (!Page.IsPostBack)
        {
            ViewState.Add("numColumns", 4);
            ViewState.Add("numRows", 3);
        }

        createNewDG();
    }

    protected void createNewDG()
    {
        short numColumns = Int16.Parse(ViewState["numColumns"].ToString());
        short numRows = Int16.Parse(ViewState["numRows"].ToString());
        grdDrop.Width = numColumns * 183;
        dg = new droppableGrid(numColumns, numRows);
        grdDrop.DataSource = dg.getDropGrid();
        grdDrop.DataBind();

        foreach ( DataGridItem dgi in grdDrop.Items)
        {
            foreach (TableCell tc in dgi.Cells)
            {
                tc.CssClass = "droppable";
            }
        }
    }

    

    protected void renderUserSequences()
    {
        string outputTable = "";
        
        for ( int i = 0; i < mySessionList.Count; i++)
        {
            
            List<Audeme> myAudemeList = dbManager.returnAudemesInSession(mySessionList[i].audemeSessionID);

            outputTable += "<td>";                            
            myAudemeList.ForEach(delegate(Audeme a)
            {
                //Add the Audeme to myAudemeDictionary if it isn't there already
                if (!myAudemeDictionary.Contains(a.getID()))
                {
                    myAudemeDictionary.Add(a.getID(), a.getFileName());
                }
            });

            outputTable += audemeListViewer.viewAsSequenceList(myAudemeList, mySessionList[i].audemeSessionName);
            outputTable += "</td>";
        }   
        
        outputTable = "<table id='audemeBlocks'>\n<tr>" + outputTable + "</tr>\n</table>";
        selectionArea.InnerHtml = outputTable;

    }
    protected void btnAddColumn_Click(object sender, EventArgs e)
    {
        ViewState["numColumns"] = (int)ViewState["numColumns"] + 1;
        createNewDG();
    }
    protected void btnRemoveColumn_Click(object sender, EventArgs e)
    {
        ViewState["numColumns"] = (int)ViewState["numColumns"] - 1;
        createNewDG();
    }
    protected void btnAddRow_Click(object sender, EventArgs e)
    {
        ViewState["numRows"] = (int)ViewState["numRows"] + 1;
        createNewDG();
    }
    protected void btnRemoveRow_Click(object sender, EventArgs e)
    {
        ViewState["numRows"] = (int)ViewState["numRows"] - 1;
        createNewDG();
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
        dg.saveGrid(); 
    }
}