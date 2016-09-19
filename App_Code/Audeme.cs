using System;
using System.Collections.Generic;

/// <summary>
/// Audeme object
/// </summary>
public class Audeme
{
    private int id;
    private string tags;
    private string fileName;
    private int soundType;
    private string name;
    private string description;
    private string creator;
    private string creationDate;
    private string soundComposition;
    private string relatedAudemes;
    private bool locked;
    
    public Audeme(int AudemeID)
	{
        this.id = AudemeID;
        dbManager.configureAudeme(this);               
    }

    public Audeme()
    {
        //Create a blank audeme
    }

    public enum SoundTypes
    {
        None,
        Audeme,
        AtomicSound,
        Sequence,
        SoundEffect
    }

    public string getCreator()
    {
        return this.creator;
    }

    public void setCreator(string creator)
    {
        this.creator = creator;
    }

    public string getCreationDate()
    {
        return this.creationDate;
    }

    public void setCreationDate(string creationDate)
    {
        this.creationDate = creationDate;
    }

    public int getID()
    {
        return this.id;
    }

    public string getName()
    {
        return this.name;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public string getDescription()
    {
        return this.description;
    }

    public void setDescription(string description)
    {
        this.description = description;
    }

    public string getTags()
    {
        return this.tags;
    }

    public void setID(int id)
    {
        this.id = id;
    }

    public void setTags(string tags)
    {
        this.tags = tags;
    }

    public string getFileName()
    {
        return this.fileName;
    }

    public void setFileName(string fileName)
    {
        this.fileName = fileName;
    }

    public string getSoundComposition()
{
    return this.soundComposition;
}

    public void setSoundComposition(string soundComposition)
    {
        this.soundComposition = soundComposition;
    }
    public int getSoundType()
    {
        return this.soundType;
    }

    public void setSoundType(int soundType)
    {
        this.soundType = soundType;
    }

    public string getRelatedAudemes()
    {
        return this.relatedAudemes;
    }

    public void setRelatedAudemes(string relatedAudemes)
    {
        this.relatedAudemes = relatedAudemes;
    }

    public bool getLocked()
    {
        return this.locked;
    }

    public void setLocked(bool bLocked)
    {
        this.locked = bLocked;
    }
}

