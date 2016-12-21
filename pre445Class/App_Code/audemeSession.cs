using System;
using System.Collections.Generic;

/// <summary>
/// AudemeSession Struct
/// </summary>
public class audemeSession
{
    public int audemeSessionID;
    public string audemeSessionName;
    public List<Audeme> audemesList;

    public audemeSession() { }

    public audemeSession(int audemeSessionID, string audemeSessionName, List<Audeme> audemesList)
    {
        this.audemeSessionID = audemeSessionID;
        this.audemeSessionName = audemeSessionName;
        this.audemesList = audemesList;
    }
}