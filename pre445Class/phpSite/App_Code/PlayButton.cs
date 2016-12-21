using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for PlayButton
/// </summary>
public class PlayButton : Button
{
    public string audemes;
    
    public PlayButton()
	{
	    this.Click += new EventHandler(PlayButton_Click);
	}

    private void PlayButton_Click(object sender, EventArgs e)
    {
        
    }    
}