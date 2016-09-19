using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for audemeListViewer
/// </summary>
public class audemeListViewer
{
	public static string viewAsDashboardList (List<Audeme> audemeList, Int16 listType, Int16 session_id)
	{        
        string listHTML = "";
        
        listHTML += "<ul id='dashboardAudemeList'>";
        
        audemeList.ForEach(delegate(Audeme audeme)
        {
            listHTML += "<li id='listID" + audeme.getID() + "'><div class='name' href=''>";
            listHTML += "Audeme: " + audeme.getName();
            listHTML += "</div><br />";

            listHTML += "<div style='padding-left: 25px;'>";

            //Play                        
            listHTML += audemeViewer.viewPlayLink(audeme);

            if (listType == (Int16)enumListType.DashboardList)
            {
                

                //Remove from Dashboard
                listHTML += "<br />Actions: <a class='clickable removeFromDashboard' id='" + audeme.getID() + "'>Remove</a>";

                //Download
                listHTML += "<a href='/downloadFile.aspx?FileName=" + audeme.getFileName() + "' target='_blank' id='downloadLink'>Download</a>";
                
                //Add to session
                
                //Create the session list
                User myUser = new User();
                int userID = Convert.ToInt32(HttpContext.Current.Session["user_id"].ToString());
                List<audemeSession> mySessionList = new List<audemeSession>();

                mySessionList = myUser.getAudemeSessionList(userID);

                listHTML += "<form class='addToSessionForm' id='addToSessionForm" + audeme.getID() + "' action='/formHandlers/addAudemeToSession.aspx'>";
                listHTML += "<select id='addToSessionSelector" + audeme.getID() + "' name='session_id'>";
                listHTML += "<option value='0'>Add to Set</option>";

                mySessionList.ForEach(delegate(audemeSession myAudemeSession)
                {
                    if ( !dbManager.isAudemeInSession(audeme.getID(), myAudemeSession.audemeSessionID )){
                        listHTML += "<option value='" + myAudemeSession.audemeSessionID + "'>";
                        listHTML += myAudemeSession.audemeSessionName + " - " + myAudemeSession.audemeSessionID + "</option>";
                    }                    
                });

                listHTML += "</select>";

                listHTML += "<input name='audeme_id' type='hidden' value='" + audeme.getID() + "' />";
                listHTML += "</form>";

                listHTML += "<script type='text/javascript'>";
                listHTML += "$('#addToSessionSelector" + audeme.getID() + "').change(function() {";
                listHTML += "$('#addToSessionForm" + audeme.getID() + "').submit();});";
                listHTML += "</script>";

                
            }
            else
            {
                //Remove from Session
                listHTML += "<br />Actions: <a class='clickable' id='" + audeme.getID() + "' href='/formHandlers/removeAudemeFromSession.aspx?";
                listHTML += "SessionID=" + session_id + "&AudemeID=" + audeme.getID() + "'>Remove from Set</a>";
            }
            listHTML += "</div>";
            listHTML += "<div class='details'>";
            
            //Tags
            listHTML += "<p>Tags: " + audemeViewer.viewTagsList(audeme.getTags()) + "</p>";
            
            listHTML += "<p>Full concept: " + audeme.getDescription() + "</p>";

            listHTML += "<p><a href='/audemeFactSheet.aspx?AudemeID=" + audeme.getID() + "'>Fact Sheet &raquo;</a></p>";

            listHTML += "<form name='" + audeme.getID() + "' action='/formHandlers/rateAudeme.aspx'><fieldset>";
            listHTML += "<legend>How well did the students understand this audeme?</legend>";
            listHTML += @"<p><span class='dashboardFormQuestion'>They got the individual components:</span> Not at all
                                <input type='radio' name='components' value='1' />
                                <input type='radio' name='components' value='2' />
                                <input type='radio' name='components' value='3' />
                                <input type='radio' name='components' value='4' />
                                <input type='radio' name='components' value='5' />
                                Definitively
                            </p>";
            listHTML += @"<p><span class='dashboardFormQuestion'>They got the full concept:</span> Not at all
                                <input type='radio' name='concept' value='1' />
                                <input type='radio' name='concept' value='2' />
                                <input type='radio' name='concept' value='3' />
                                <input type='radio' name='concept' value='4' />
                                <input type='radio' name='concept' value='5' />
                                Definitively
                            </p>";
            listHTML += "<input style='display: none;' type='text' name='audeme_id' value='" + audeme.getID() + "' />";
            listHTML += "<input type='Submit' value='Submit' />";
            listHTML += "</fieldset></form></div></li>";
        });

        listHTML += "</ul>";
        
        return listHTML;
	}

    public static string viewAsTextRiddleList(List<Audeme> audemeList)
    {
        string listHTML = "";

        listHTML += "<ul id='riddleList'>";

        audemeList.ForEach(delegate(Audeme audeme)
        {
            listHTML += "<li id='listID" + audeme.getID() + "'><div class='name showDetails' href=''><img class='expandIcon expand' alt='expand/collapse' />";

            if (String.IsNullOrEmpty(audeme.getName()))
            {
                listHTML += "(Atomic Sound)";
            }
            else
            {
                listHTML += audeme.getName();
            }

            listHTML += " (ID: " + audeme.getID() + ")</div>";

            //Play                        
            listHTML += audemeViewer.viewPlayLink(audeme);

            //Description
            if (String.IsNullOrEmpty(audeme.getDescription()) || audeme.getDescription() == "NULL")
            {
                listHTML += "<p>Full concept: (not specified)</p>";
            }
            else
            {
                listHTML += "<p>Full concept: " + audeme.getDescription() + "</p>";
            }

            listHTML += "</li>";
        });

        listHTML += "</ul>";

        return listHTML;
    }

    public static string viewAsSearchList(List<Audeme> audemeList)
    {
        string listHTML = "";

        listHTML += "<ul id='dashboardAudemeList'>";

        audemeList.ForEach(delegate(Audeme audeme)
        {
            listHTML += "<li id='listID" + audeme.getID() + "'><div class='name' href=''>";
            
            if(String.IsNullOrEmpty(audeme.getName()))
            {
                listHTML += "<h3>(Atomic Sound)</h3>";
            }
            else
            {
                listHTML += "<h3>Audeme: " + audeme.getName() + "</h3>";
            }
            
            listHTML += "</div><br /><br /><div style='padding-left: 25px;'>";

            

            //Description
            if (String.IsNullOrEmpty(audeme.getDescription()) || audeme.getDescription() == "NULL")
            {
                listHTML += "Concept: (not specified)";
            }
            else
            {
                listHTML += "Concept: " + audeme.getDescription();
            }

            listHTML += "<br /><br />";

            //Play                        
            listHTML += audemeViewer.viewPlayLink(audeme);

            listHTML += "<br /><br />";

            if (audeme.getLocked())
            {
                //If the audeme is locked, allow the admin user to unlock it
                listHTML += "<a class='clickable' id='unlock" + audeme.getID() + "' onClick='unlock(" + audeme.getID() + ");' >Unlock</a>";
            }
            else
            {
                //Add to Dashboard
                listHTML += "Actions: " + audemeViewer.viewAddToDashboardLink(audeme.getID());
            }

            listHTML += "<a href='/downloadFile.aspx?FileName=" + audeme.getFileName() + "' target='_blank' id='downloadLink'>Download</a>";
            listHTML += "</div><div>";

            listHTML += "</li>";
        });

        listHTML += "</ul>";

        return listHTML;
    }

    public static string viewAsSearchList_SoundEffectsOnly(List<Audeme> audemeList)
    {
        string listHTML = "";

        listHTML += "<ul id='dashboardAudemeList'>";

        audemeList.ForEach(delegate(Audeme audeme)
        {
            listHTML += "<li id='listID" + audeme.getID() + "'><div class='name' href=''>";

            if (String.IsNullOrEmpty(audeme.getName()))
            {
                listHTML += "(Atomic Sound)";
            }
            else
            {
                listHTML += "Atomic Sound: " + audeme.getName();
            }

            listHTML += "</div><br /><br /><div style='padding-left: 25px;'>";

            //Play                        
            listHTML += audemeViewer.viewPlayLink(audeme);

            listHTML += "<br /><br />Actions: ";
            if (audeme.getLocked())
            {
                //If the audeme is locked, allow the admin user to unlock it
                listHTML += "<a class='clickable' id='unlock" + audeme.getID() + "' onClick='unlock(" + audeme.getID() + ");' >Unlock</a>";
            }
            else
            {
                //Add to Dashboard
                listHTML += audemeViewer.viewAddToDashboardLink(audeme.getID());
            }

            listHTML += "<a href='/downloadFile.aspx?FileName=" + audeme.getFileName() + "' target='_blank' id='downloadLink'>Download</a>";

            listHTML += "</li>";
        });

        listHTML += "</ul>";

        return listHTML;
    }

    public static string viewAsSearchList_Grids(DataTable dt)
    {
        string listHTML = "";
        char[] charsToTrim = { ',', ' ' };

        listHTML += "<ul id='dashboardAudemeList'>";

        for ( int i = 0; i < dt.Rows.Count; i++ )
        {
            DataRow dr = dt.Rows[i];

            string strID = dr["AudemeGrid_id"].ToString();
            string strName = dr["Name"].ToString();
            
            listHTML += "<li gridID='" + strID + "'>";

            if (String.IsNullOrEmpty(strName))
            {
                listHTML += "(Grid)";
            }
            else
            {
                listHTML += strName;
            }

            listHTML += " (ID: " + strID + ")<br />";

            listHTML += "Contains columns:  ";
            AudemeGrid ag = new AudemeGrid();
            ag = dbManager.returnAudemeGrid(Int16.Parse(strID), true);
            foreach (AudemeGridColumn column in ag.getColumns())
            {
                if (!String.IsNullOrEmpty(column.getName()))
                {
                    listHTML += column.getName() + ", ";
                }
            }
            listHTML = listHTML.TrimEnd(charsToTrim);

            listHTML += "<br />";
            listHTML += "<a href='/games/audemeBlocks.aspx?AudemeGridID=" + strID + "'>View Grid</a><br />";

            listHTML += "<a href='/games/quizgame.aspx?AudemeGridID=" + strID + "'>Play Quiz Game</a><br />";

            listHTML += "<a href='/contribute/sequenceCreator.aspx?AudemeGridID=" + strID + "'>Make Sequence from Grid</a><br />";

            listHTML += AudemeGrid.viewAddToDashboardLink(Int16.Parse(strID));
            
            listHTML += "</li>";
        }

        listHTML += "</ul>";

        return listHTML;
    }

    public static string viewAsDashboardList_Grids(DataTable dt)
    {
        string listHTML = "";
        char[] charsToTrim = { ',', ' ' };

        listHTML += "<ul id='dashboardAudemeList'>";

        for ( int i = 0; i < dt.Rows.Count; i++ )
        {
            DataRow dr = dt.Rows[i];

            string strID = dr["AudemeGrid_id"].ToString();
            string strName = dr["Name"].ToString();
            
            listHTML += "<li gridID='" + strID + "'>";

            if (String.IsNullOrEmpty(strName))
            {
                listHTML += "(Grid)";
            }
            else
            {
                listHTML += strName;
            }

            listHTML += " (ID: " + strID + ")<br />";

            listHTML += "Contains columns:  ";
            AudemeGrid ag = new AudemeGrid();
            ag = dbManager.returnAudemeGrid(Int16.Parse(strID), true);
            foreach (AudemeGridColumn column in ag.getColumns())
            {
                if (!String.IsNullOrEmpty(column.getName()))
                {
                    listHTML += column.getName() + ", ";
                }
            }
            listHTML = listHTML.TrimEnd(charsToTrim);

            listHTML += "<br />";
            listHTML += "<a href='/games/audemeBlocks.aspx?AudemeGridID=" + strID + "'>View Grid</a><br />";

            listHTML += "<a href='/games/quizgame.aspx?AudemeGridID=" + strID + "'>Play Quiz Game</a><br />";

            listHTML += "<a href='/contribute/sequenceCreator.aspx?AudemeGridID=" + strID + "'>Make Sequence from Grid</a><br />";

            listHTML += "<a class='clickable removeGridFromDashboard' id='" + strID + "'>Remove</a>";
            
            listHTML += "</li>";
        }

        listHTML += "</ul>";

        return listHTML;
    }

    public static string viewAsSequenceList(List<Audeme> audemeList)
    {
        string sequenceHTML = "";

        sequenceHTML += "<table style='width: 175px;'>";
        sequenceHTML += "<tr><th>In Your Locker</th></tr>";
        
        audemeList.ForEach(delegate(Audeme audeme)
        {
            sequenceHTML += audemeViewer.viewPlayBlock(audeme);
            
        });
        
        sequenceHTML += "</table>";

        return sequenceHTML;
    }

    public static string viewAsSequenceList(List<Audeme> audemeList, string colName)
    {
        string sequenceHTML = "";

        sequenceHTML += "<table style='width: 175px;'>";
        sequenceHTML += "<tr><th>" + colName + "</th></tr>";

        audemeList.ForEach(delegate(Audeme audeme)
        {
            sequenceHTML += audemeViewer.viewPlayBlock(audeme);

        });

        sequenceHTML += "</table>";

        return sequenceHTML;
    }
}

public enum enumListType:short
{
    DashboardList,
    SessionList
}
