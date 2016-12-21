using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// The AudemeGridColumn class holds AudemeGridCells, which contain information about specific audemes
/// </summary>
public class AudemeGridColumn
{
	//Variable Declaration
    private string name;
    private List<AudemeGridCell> listCells;

    //Constructors
    public AudemeGridColumn(string name)
	{
        this.name = name;
        this.listCells = new List<AudemeGridCell>();
	}
    public AudemeGridColumn()
    {
        //Create a blank column
        this.listCells = new List<AudemeGridCell>();
    }
    
    //Get and Set functions
    public List<AudemeGridCell> getCells()
    {
        return this.listCells;
    }
    public AudemeGridCell getCell(int index)
    {
        return this.listCells[index];
    }
    public void setCell(int index, AudemeGridCell cell)
    {
        this.listCells.Add(cell);
    }
    public string getName()
    {
        return this.name;
    }
    public void setName(string name)
    {
        this.name = name;
    }
}