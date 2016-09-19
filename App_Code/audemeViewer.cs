using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// audemeViewer helps standardise the presentation of Audeme objects
/// </summary>
public class audemeViewer
{
	public audemeViewer()
	{	
	}

    private static List<string> combineSoundsIntoList(Audeme myAudeme)
    {
        //Helper function to combine sounds from sequences into a list
        
        List<string> mySoundList = new List<string>();

        //If this sound is a sequence, return the list of sounds for the components the component
        if (myAudeme.getSoundType() == (int)Audeme.SoundTypes.Sequence)
        {
            List<Audeme> myAudemeList = dbManager.returnSequenceComposition(myAudeme.getID().ToString());

            myAudemeList.ForEach(delegate(Audeme audeme)
            {
                mySoundList.AddRange(audemeViewer.combineSoundsIntoList(audeme));
            });
        }
        else
        {
            mySoundList.Add(myAudeme.getName());
        }

        return mySoundList;
    }

    public static string viewAddToDashboardLink(int audemeID)
    {
        string returnHTML = "";

        if (HttpContext.Current.Session["user_id"] == null)
        {
            returnHTML += "<a class='promptAuthentication clickable'>Add to Locker</a>";
        }
        else
        {
            if (dbManager.isAudemeInDashboard(HttpContext.Current.Session["user_id"].ToString(), audemeID.ToString()))
            {
                //If audeme is in the user's dashboard, let them know
                returnHTML += "<a>(in Locker)</a>";
            }
            else
            {
                //If audeme is not in the user's dashboard, let them add it
                returnHTML += "<a class='addToDashboard clickable' id='" + audemeID + "'>Add to Locker</a>";
            }
        }       

        return returnHTML;
    }

    public static string viewPlayBlock(Audeme myAudeme)
    {
        string returnHTML = "";

        if (myAudeme.getSoundType() == (int)Audeme.SoundTypes.Sequence)
        {
            string sequenceJavascript = "";

            List<Audeme> myAudemeList = dbManager.returnSequenceComposition(myAudeme.getID().ToString());

            //Play the chain
            int counter = 0;
            string previousID = "";

            myAudemeList.ForEach(delegate(Audeme audeme)
            {
                counter++;
                string currentID = audeme.getFileName() + counter;
                

                //If this is the first Audeme, hook the Play button to it
                if (previousID == "")
                {
                    returnHTML += "<tr><td class='draggable audeme' audemeID='" + audeme.getID() + "' id='lockerBlock" + audeme.getID() + "' onclick='document.getElementById(\"" + currentID + "\").play();'>";
                    
                    //Limit the number of characters that show in an audeme block
                    if ((myAudeme.getName()).Length > 20)
                    {
                        returnHTML += myAudeme.getName().Substring(0, 18) + "...";
                    }
                    else
                    {
                        returnHTML += myAudeme.getName();
                    }
                    
                    returnHTML += "</td></tr>";
                }
                else
                {
                    //Otherwise, setup the chain
                    sequenceJavascript += "document.getElementById('" + previousID + "').addEventListener('ended', ";
                    sequenceJavascript += "function () { document.getElementById('" + currentID + "').play() }, false);\n";
                }

                returnHTML += "<audio id='" + currentID + "' class='invisible'>";
                returnHTML += "<source src='/MP3s/audemes/" + audeme.getFileName() + ".mp3' type='audio/mpeg' />";
                returnHTML += "</audio>";

                previousID = currentID;
            });

            //Add the play functionality for the Audemes within the sequence
            returnHTML += "<script type='text/javascript'>";
            returnHTML += sequenceJavascript;
            returnHTML += "</script>";
        }
        else
        {
            //Add the "Play" option to the top nav                        
            returnHTML += "<tr><td class='draggable audeme' audemeID='" + myAudeme.getID() + "' id='lockerBlock" + myAudeme.getID() + "' onclick='clicksound" + myAudeme.getID() + ".playclip()'>";

            //Limit the number of characters that show in an audeme block
            if ((myAudeme.getName()).Length > 15)
            {
                returnHTML += myAudeme.getName().Substring(0, 12) + "...";
            }
            else
            {
                returnHTML += myAudeme.getName();
            }

            returnHTML += "<script type='text/javascript'>";
            returnHTML += "var clicksound" + myAudeme.getID() + " = createsoundbite('/MP3s/audemes/" + myAudeme.getFileName() + ".mp3');";
            returnHTML += "var audemeID = " + myAudeme.getID() + ";";
            returnHTML += "</script>";
            returnHTML += "</td></tr>";
        }


        return returnHTML;
    }

    public static string viewPlayLink(Audeme myAudeme)
    {
        string returnHTML = "";

        if (myAudeme.getSoundType() == (int)Audeme.SoundTypes.Sequence)
        {
            string sequenceJavascript = "";

            List<Audeme> myAudemeList = dbManager.returnSequenceComposition(myAudeme.getID().ToString());

            //Play the chain
            int counter = 0;
            string previousID = "";

            myAudemeList.ForEach(delegate(Audeme audeme)
            {
                counter++;
                string currentID = audeme.getFileName() + counter;
                returnHTML += "<audio id='" + currentID + "' class='invisible'>";
                returnHTML += "<source src='/MP3s/audemes/" + audeme.getFileName() + ".mp3' type='audio/mpeg' />";
                returnHTML += "</audio>";

                //If this is the first Audeme, hook the Play button to it
                if (previousID == "")
                {
                    returnHTML += "<a class='clickable audeme' audemeID='" + audeme.getID() + "' onclick='document.getElementById(\"" + currentID + "\").play();'>Play</a>";
                }
                else
                {
                    //Otherwise, setup the chain
                    sequenceJavascript += "document.getElementById('" + previousID + "').addEventListener('ended', ";
                    sequenceJavascript += "function () { document.getElementById('" + currentID + "').play() }, false);\n";
                }
                previousID = currentID; 
            });

            //Add the play functionality for the Audemes within the sequence
            returnHTML += "<script type='text/javascript'>";
            returnHTML += sequenceJavascript;
            returnHTML += "</script>";
        }
        else
        {
            returnHTML += "<audio id='" + myAudeme.getFileName() + "' controls='controls'>";
            returnHTML += "<source src='/MP3s/audemes/" + myAudeme.getFileName() + ".mp3' type='audio/mpeg' />";
            returnHTML += "</audio>";
            //Add the "Play" option to the top nav                        
            //returnHTML += "<a href='#' class='audeme' audemeID='" + myAudeme.getID() + "' onclick='clicksound" + myAudeme.getID() + ".playclip(); return false;'>Play</a>";
            //returnHTML += "<script type='text/javascript'>";
            //returnHTML += "var clicksound" + myAudeme.getID() + " = createsoundbite('/MP3s/audemes/" + myAudeme.getFileName() + ".mp3');";
            //returnHTML += "var audemeID = " + myAudeme.getID() + ";";
            //returnHTML += "</script>";
        }
        

        return returnHTML;
    }

    public static string viewSequenceOfSounds(Audeme myAudeme)
    {
        //Returns the list of sounds in an Audeme
        string returnHTML = "";

        //If this sound is a sequence, return the list of sounds for the components the component
        if (myAudeme.getSoundType() == (int)Audeme.SoundTypes.Sequence)
        {
            List<string> mySoundList = audemeViewer.combineSoundsIntoList(myAudeme);

            for (int i = 0; i < mySoundList.Count; i++)
            {
                //Convert the list into a comma-separated string
                if (i < mySoundList.Count - 1)
                {
                    returnHTML += mySoundList[i] + ", ";
                }
                else
                {
                    //The last element does not have a comma
                    returnHTML += mySoundList[i];
                }
            }
        }
        else
        {
            //Otherwise, just return the filename 
            returnHTML += myAudeme.getName();
        }

        return returnHTML;
    }

    public static string viewTagsList(string tags)
    {
        string returnHTML = "";

        if (String.IsNullOrEmpty(tags))
        {
            returnHTML += "(none)";
        }
        else
        {
            string[] tagsArray = tags.Split(',');
            List<string> tagList = new List<string>(tagsArray.Length);
            tagList.AddRange(tagsArray);

            tagList.ForEach(delegate(string tag)
            {
                returnHTML += "<a href='/dictionary/?searchTerm=" + tag + "'>" + tag + "</a>, ";
            });

            returnHTML = returnHTML.Remove(returnHTML.Length - 2);
        }       

        return returnHTML;
    }
}