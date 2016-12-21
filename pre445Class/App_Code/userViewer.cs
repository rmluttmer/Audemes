using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Displays user info
/// </summary>
public static class userViewer
{
    public static string viewUserInfoPage ( int userID )
    {
        string pageText = "";

        //Display user info

        User myUser = dbManager.returnUserInfo(userID.ToString());

        pageText += "<h1>User Info</h1>";
        pageText += "<p>Username: " + myUser.getUserName() + "</p>";
        pageText += "<p>Name: " + myUser.getFirstName() + " " + myUser.getLastName() + "</p>";

        if (myUser.getSchool() != "")
        {
            pageText += "<p>School: " + myUser.getSchool() + "</p>";
        }
        
        //Display audemes in user's locker
        pageText += "<h2>Audemes in " + myUser.getUserName() + "'s Locker</h2>";
        List<Audeme> myAudemeList = dbManager.returnDashboardList(userID);
        pageText += audemeListViewer.viewAsSearchList(myAudemeList);

        //Display audemes that the user has created
        pageText += "<h2>Audemes Created By " + myUser.getUserName() + "</h2>";
        myAudemeList = dbManager.returnAudemesCreatedBy(userID);
        pageText += audemeListViewer.viewAsSearchList(myAudemeList);

        return pageText;
    }
}