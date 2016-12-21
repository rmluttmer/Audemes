using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// AudemeGridCell contains Audeme information for the cells in a given AudemeGrid
/// </summary>
public class AudemeGridCell
{
    private int id;
    private string name;
    private string fileName;
    private string tags;

    //Constructor function
    public AudemeGridCell(int id, string name, string fileName)
	{
        this.id = id;
        this.name = name;
        this.fileName = fileName;
	}

    public AudemeGridCell()
    {
        //Create a blank cell
    }

    //Get and Set functions
    public int getID()
    {
        return this.id;
    }

    public void setID(int id)
    {
        this.id = id;
    }

    public string getName()
    {
        return this.name;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public string getFileName()
    {
        return this.fileName;
    }

    public void setFileName(string fileName)
    {
        this.fileName = fileName;
    }

    public string getTags()
    {
        return this.tags;
    }

    public void setTags(string tags)
    {
        this.tags = tags;
    }

}