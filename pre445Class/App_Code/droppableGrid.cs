using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

/// <summary>
/// Summary description for droppableGrid
/// </summary>
public class droppableGrid : System.Web.UI.Control
{
    private DataTable dtGrid = new DataTable();
    private List<List<TextBox>> lCols = new List<List<TextBox>>();
    
    public droppableGrid()
	{   
        buildGrid();
    }

    public droppableGrid(int cols, int rows)
    {
        ViewState.Add("numColumns", cols);
        ViewState.Add("numRows", rows);
        buildGrid();
    }

    public DataTable getDropGrid()
    {
        //Build the blank datatable
        short numColumns = Int16.Parse(ViewState["numColumns"].ToString());
        short numRows = Int16.Parse(ViewState["numRows"].ToString());
        
        dtGrid.Clear();
        for (int iCol = 0; iCol < numColumns; iCol++)
        {
            dtGrid.Columns.Add();
        }
        for (int iRow = 0; iRow < numRows; iRow++)
        {
            dtGrid.Rows.Add();
        }

        for (int iCol = 0; iCol < dtGrid.Columns.Count; iCol++)
        {
            for (int iRow = 0; iRow < dtGrid.Rows.Count; iRow++)
            {
                dtGrid.Rows[iRow][iCol] = lCols[iCol][iRow].Text;
                
            }
        }
        return dtGrid;
    }

    private void buildGrid()
    {
        //Build the blank datatable
        short numColumns = Int16.Parse(ViewState["numColumns"].ToString());
        short numRows = Int16.Parse(ViewState["numRows"].ToString());

        //Add the columns
        for (int iCol = 0; iCol < numColumns; iCol++)
        {
            //For each column, add a new list of textboxes
            lCols.Add(new List<TextBox>());
            for (int iRow = 0; iRow < numRows; iRow++)
            {
                //For each row, add a text box to the column
                TextBox cell = new TextBox();
                int CellIndex = iCol + (iRow * numColumns);
                cell.ID = CellIndex.ToString();
                cell.CssClass = "droppable";
                lCols[iCol].Add(cell);
            }
        }
    }

    public void saveGrid()
    {
        int index = 0;
        string audemeID = "";
        foreach (List<TextBox> Ltb in lCols)
        {
            foreach (TextBox tb in Ltb)
            {
                index++;
                if (tb.Attributes["droppedAudemeID"] == null)
                {
                    audemeID = "null";
                }
                else
                {
                    if (tb.Attributes["droppedAudemeID"] == "")
                    {
                        audemeID = "";
                    }
                    else
                    {
                        audemeID = tb.Attributes["droppedAudemeID"].ToString();
                    }
                }
                HttpContext.Current.Response.Write(index.ToString() + ": " + audemeID + "<br />");
            }
        }
    }
}