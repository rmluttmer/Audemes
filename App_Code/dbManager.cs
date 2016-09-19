using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Assists with most of the Database Management
///     -There are currently three classes that bypass this manager (because I couldn't figure out how to get them to work otherwise)
///         1.  AudemeGridGenerator
///         2.  Audeme
///         3.  audemeListViewer
/// </summary>
public static class dbManager
{
    //Declare Connection String
    public static string connectionString {
        get
        {
            return "user id=audemedbuser;" +
                    "password=pirates jasmin apexes nievelt bismite1!;" +
                    "Trusted_Connection=SSPI;" +
                    "database=audeme_db; " +
                    "connection timeout=30";
        }
    }

#region "Dashboard" 
    public static void addToDashboard(string userID, string audemeID)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "addToDashboard";

        //Add Parameters to the SQLCommand

        SqlParameter paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@user_id";
        paramUserID.Value = userID;
        myCommand.Parameters.Add(paramUserID);

        SqlParameter paramAudemeID = new SqlParameter();
        paramAudemeID.ParameterName = "@audeme_id";
        paramAudemeID.Value = audemeID;
        myCommand.Parameters.Add(paramAudemeID);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    public static void addToDashboard_Grid(string userID, string audemeGridID)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "addToDashboard_Grid";

        //Add Parameters to the SQLCommand

        SqlParameter paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@user_id";
        paramUserID.Value = userID;
        myCommand.Parameters.Add(paramUserID);

        SqlParameter paramAudemeID = new SqlParameter();
        paramAudemeID.ParameterName = "@audemeGrid_id";
        paramAudemeID.Value = audemeGridID;
        myCommand.Parameters.Add(paramAudemeID);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    public static bool isAudemeInDashboard(string userID, string audemeID)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "checkIfAudemeIsInDashboard";

        //Add Parameters to the SQLCommand

        SqlParameter paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@user_id";
        paramUserID.Value = userID;
        myCommand.Parameters.Add(paramUserID);

        SqlParameter paramAudemeID = new SqlParameter();
        paramAudemeID.ParameterName = "@audeme_id";
        paramAudemeID.Value = audemeID;
        myCommand.Parameters.Add(paramAudemeID);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        if (myReader.HasRows)
        {
            myConnection.Close();
            return true;
        }
        else
        {
            myConnection.Close();
            return false;
        }
    }

    public static bool isAudemeGridInDashboard(string userID, string audemeGridID)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "checkIfAudemeGridIsInDashboard";

        //Add Parameters to the SQLCommand

        SqlParameter paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@user_id";
        paramUserID.Value = userID;
        myCommand.Parameters.Add(paramUserID);

        SqlParameter paramAudemeID = new SqlParameter();
        paramAudemeID.ParameterName = "@audemeGrid_id";
        paramAudemeID.Value = audemeGridID;
        myCommand.Parameters.Add(paramAudemeID);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        if (myReader.HasRows)
        {
            myConnection.Close();
            return true;
        }
        else
        {
            myConnection.Close();
            return false;
        }
    }

    public static void removeFromDashboard(string user_id, string audeme_id)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "removeFromDashboard";

        //Add Parameters to the SQLCommand

        SqlParameter paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@user_id";
        paramUserID.Value = user_id;
        myCommand.Parameters.Add(paramUserID);

        SqlParameter paramAudemeID = new SqlParameter();
        paramAudemeID.ParameterName = "@audeme_id";
        paramAudemeID.Value = audeme_id;
        myCommand.Parameters.Add(paramAudemeID);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    public static void removeFromDashboard_Grid(string user_id, string audemeGrid_id)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "removeFromDashboard_Grid";

        //Add Parameters to the SQLCommand

        SqlParameter paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@user_id";
        paramUserID.Value = user_id;
        myCommand.Parameters.Add(paramUserID);

        SqlParameter paramAudemeID = new SqlParameter();
        paramAudemeID.ParameterName = "@audemeGrid_id";
        paramAudemeID.Value = audemeGrid_id;
        myCommand.Parameters.Add(paramAudemeID);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

#endregion

#region "Content Creation"
    public static int createAudeme(string tags, string file_name, string name, string description, int userID, DateTime datetime, string soundComposition)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "CreateAudeme";

        //Add Parameters to the SQLCommand

        SqlParameter param = new SqlParameter();
        param.ParameterName = "@tags";
        param.Value = tags;
        myCommand.Parameters.Add(param);

        param = new SqlParameter();
        param.ParameterName = "@file_name";
        param.Value = file_name;
        myCommand.Parameters.Add(param);

        param = new SqlParameter();
        param.ParameterName = "@name";
        param.Value = name;
        myCommand.Parameters.Add(param);

        param = new SqlParameter();
        param.ParameterName = "@description";
        param.Value = description;
        myCommand.Parameters.Add(param);

        param = new SqlParameter();
        param.ParameterName = "@userID";
        param.Value = userID;
        myCommand.Parameters.Add(param);

        param = new SqlParameter();
        param.ParameterName = "@datetime";
        param.Value = datetime;
        myCommand.Parameters.Add(param);

        param = new SqlParameter();
        param.ParameterName = "@soundComposition";
        param.Value = soundComposition;
        myCommand.Parameters.Add(param);

        //Read the Response from the DB
        myCommand.Prepare();
        Int32 audemeID = (System.Int32)myCommand.ExecuteScalar();
        myConnection.Close();

        return audemeID;
    }

    public static int createSequence(string userID, string sequenceName, string sequenceDescription, string sequenceTags)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "createSequence";

        //Add Parameters to the SQLCommand
        SqlParameter param2 = new SqlParameter();
        param2.ParameterName = "@user_id";
        param2.Value = userID;
        myCommand.Parameters.Add(param2);

        SqlParameter param3 = new SqlParameter();
        param3.ParameterName = "@name";
        param3.Value = sequenceName;
        myCommand.Parameters.Add(param3);

        SqlParameter param4 = new SqlParameter();
        param4.ParameterName = "@description";
        param4.Value = sequenceDescription;
        myCommand.Parameters.Add(param4);

        SqlParameter param5 = new SqlParameter();
        param5.ParameterName = "@tags";
        param5.Value = sequenceTags;
        myCommand.Parameters.Add(param5);

        myCommand.Prepare();
        Int32 sequenceID = (System.Int32)myCommand.ExecuteScalar();

        myConnection.Close();

        return sequenceID;
    }

    public static void createSession(string userID, string sessionName)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "createSession";

        //Add Parameters to the SQLCommand
        SqlParameter param2 = new SqlParameter();
        param2.ParameterName = "@user_id";
        param2.Value = userID;
        myCommand.Parameters.Add(param2);

        SqlParameter param3 = new SqlParameter();
        param3.ParameterName = "@name";
        param3.Value = sessionName;
        myCommand.Parameters.Add(param3);

        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    public static int createGrid(string strName, int numCols, int[] colIDs)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "audemeGrid_Insert";

        //Add Parameters to the SQLCommand
        SqlParameter param2 = new SqlParameter();
        param2.ParameterName = "@Name";
        param2.Value = strName;
        myCommand.Parameters.Add(param2);

        param2 = new SqlParameter();
        param2.ParameterName = "@NumCols";
        param2.Value = numCols;
        myCommand.Parameters.Add(param2);

        myCommand.Prepare();
        Int32 gridID = (System.Int32)myCommand.ExecuteScalar();
        myConnection.Close();

        for (int i = 0; i < colIDs.Length; i++)
        {
            if (colIDs[i] != 0)
            {
                myConnection = new SqlConnection(dbManager.connectionString);
                myConnection.Open();

                //Create and Execute the SQL Command
                myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.CommandText = "audemeGrid_AddColumn";

                //Add Parameters to the SQLCommand
                param2 = new SqlParameter();
                param2.ParameterName = "@audemeGrid_id";
                param2.Value = gridID;
                myCommand.Parameters.Add(param2);

                param2 = new SqlParameter();
                param2.ParameterName = "@audemeCol_id";
                param2.Value = colIDs[i];
                myCommand.Parameters.Add(param2);

                param2 = new SqlParameter();
                param2.ParameterName = "@position";
                param2.Value = i + 1;
                myCommand.Parameters.Add(param2);

                myCommand.Prepare();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        return gridID;
    }

    public static void addSoundToSequence(int sequenceID, string soundID, int soundPosition)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "addSoundToSequence";

        //Add Parameters to the SQLCommand
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@audeme_id";
        param.Value = sequenceID;
        myCommand.Parameters.Add(param);

        SqlParameter param2 = new SqlParameter();
        param2.ParameterName = "@component_id";
        param2.Value = soundID;
        myCommand.Parameters.Add(param2);

        SqlParameter param3 = new SqlParameter();
        param3.ParameterName = "@component_position";
        param3.Value = soundPosition;
        myCommand.Parameters.Add(param3);

        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        myConnection.Close();
    }

    public static void deleteSession(string SessionID)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "deleteSessionBySessionID";

        //Add Parameters to the SQLCommand

        SqlParameter paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@sessionID";
        paramUserID.Value = SessionID;
        myCommand.Parameters.Add(paramUserID);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    public static void addAudemeToSession(string session_id, string audeme_id, string user_id, int position)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "addAudemeToSession";

        //Add Parameters to the SQLCommand

        SqlParameter paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@session_id";
        paramUserID.Value = session_id;
        myCommand.Parameters.Add(paramUserID);

        paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@audeme_id";
        paramUserID.Value = audeme_id;
        myCommand.Parameters.Add(paramUserID);

        paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@user_id";
        paramUserID.Value = user_id;
        myCommand.Parameters.Add(paramUserID);

        paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@position";
        paramUserID.Value = position;
        myCommand.Parameters.Add(paramUserID);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    public static void removeAudemeFromSession(string session_id, string audeme_id)
    {

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "removeAudemeFromSession";

        //Add Parameters to the SQLCommand

        SqlParameter paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@session_id";
        paramUserID.Value = session_id;
        myCommand.Parameters.Add(paramUserID);

        paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@audeme_id";
        paramUserID.Value = audeme_id;
        myCommand.Parameters.Add(paramUserID);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    public static bool checkSession_ForUserSessionMatch(string SessionID, string UserID)
    {
        bool doIDsMatch = false;

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "getSessionBySessionIDUserID";

        //Add Parameters to the SQLCommand

        SqlParameter paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@session_id";
        paramUserID.Value = SessionID;
        myCommand.Parameters.Add(paramUserID);

        paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@user_id";
        paramUserID.Value = UserID;
        myCommand.Parameters.Add(paramUserID);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();


        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        if (myReader.HasRows)
        {
            doIDsMatch = true;
        }


        myConnection.Close();
        return doIDsMatch;
    }

    public static bool isAudemeInSession(int audeme_id, int session_id)
    {
        bool audemeFoundInSession = false;

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "isAudemeInSession";

        //Add Parameters to the SQLCommand

        SqlParameter paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@session_id";
        paramUserID.Value = session_id;
        myCommand.Parameters.Add(paramUserID);

        paramUserID = new SqlParameter();
        paramUserID.ParameterName = "@audeme_id";
        paramUserID.Value = audeme_id;
        myCommand.Parameters.Add(paramUserID);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();


        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        if (myReader.HasRows)
        {
            audemeFoundInSession = true;
        }


        myConnection.Close();

        return audemeFoundInSession;
    }

    public static void reorderAudeme(string user_id, string audeme_id, int index)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "updateDashboardOrder";

        //Add Parameters to the SQLCommand
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@user_id";
        param.Value = user_id;
        myCommand.Parameters.Add(param);

        SqlParameter param2 = new SqlParameter();
        param2.ParameterName = "@audeme_id";
        param2.Value = audeme_id;
        myCommand.Parameters.Add(param2);

        SqlParameter param3 = new SqlParameter();
        param3.ParameterName = "@audeme_position";
        param3.Value = index;
        myCommand.Parameters.Add(param3);

        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        myConnection.Close();
    }

    public static void unlockAudemeByID(string audemeID)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "audeme_UnlockByID";

        //Add Parameters to the SQLCommand
        SqlParameter paramUsername = new SqlParameter();
        paramUsername.ParameterName = "@audemeID";
        paramUsername.Value = audemeID;
        myCommand.Parameters.Add(paramUsername);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    public static void unlockAudemeColByID(string audemeColID)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "UnlockAudemeCol_ByID";

        //Add Parameters to the SQLCommand
        SqlParameter paramUsername = new SqlParameter();
        paramUsername.ParameterName = "@AudemeCol_ID";
        paramUsername.Value = audemeColID;
        myCommand.Parameters.Add(paramUsername);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

#endregion

#region "Account Management"
    public static void createAccount(string username, string password, string fName, string lName, string email, string phone, string school, string styleSheet)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "CreateAccount";

        //Add Parameters to the SQLCommand

        SqlParameter paramUsername = new SqlParameter();
        paramUsername.ParameterName = "@username";
        paramUsername.Value = username;
        myCommand.Parameters.Add(paramUsername);

        SqlParameter paramPassword = new SqlParameter();
        paramPassword.ParameterName = "@password";
        paramPassword.Value = password;
        myCommand.Parameters.Add(paramPassword);

        SqlParameter paramFName = new SqlParameter();
        paramFName.ParameterName = "@fName";
        paramFName.Value = fName;
        myCommand.Parameters.Add(paramFName);

        SqlParameter paramLName = new SqlParameter();
        paramLName.ParameterName = "@lName";
        paramLName.Value = lName;
        myCommand.Parameters.Add(paramLName);

        SqlParameter paramEmail = new SqlParameter();
        paramEmail.ParameterName = "@email";
        paramEmail.Value = email;
        myCommand.Parameters.Add(paramEmail);

        SqlParameter paramPhone = new SqlParameter();
        paramPhone.ParameterName = "@phone";
        paramPhone.Value = phone;
        myCommand.Parameters.Add(paramPhone);

        SqlParameter paramSchool = new SqlParameter();
        paramSchool.ParameterName = "@school";
        paramSchool.Value = school;
        myCommand.Parameters.Add(paramSchool);

        SqlParameter paramRoleID = new SqlParameter();
        paramRoleID.ParameterName = "@roleID";
        paramRoleID.Value = 1;
        myCommand.Parameters.Add(paramRoleID);

        SqlParameter paramStyleSheet = new SqlParameter();
        paramStyleSheet.ParameterName = "@styleSheet";
        paramStyleSheet.Value = styleSheet;
        myCommand.Parameters.Add(paramStyleSheet);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    public static User returnUserInfo(string userID)
    {
        //Creates and returns a User based on userID
        User myUser = new User();

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "getUserInfo";

        //Add Parameters to the SQLCommand

        SqlParameter paramUsername = new SqlParameter();
        paramUsername.ParameterName = "@user_id";
        paramUsername.Value = userID;
        myCommand.Parameters.Add(paramUsername);

        //Execute the procedure
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        //Read the Response from the DB

        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        if (myReader.HasRows)
        {
            //Store the results
            while (myReader.Read())
            {
                //Setup the User
                myUser.setUserName(myReader["username"].ToString());
                myUser.setEmail(myReader["email"].ToString());
                myUser.setFirstName(myReader["first_name"].ToString());
                myUser.setLastName(myReader["last_name"].ToString());
                myUser.setPhone(myReader["phone"].ToString());
                myUser.setRoleID(Convert.ToInt16(myReader["role_id"].ToString()));
                myUser.setSchool(myReader["school"].ToString());
                myUser.setUserID(Convert.ToInt16(userID));
            }
        }

        myConnection.Close();
        return myUser;
    }

    public static bool login(string username, string password)
    {
        bool returnValue = false;

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "LogIn";

        //Add Parameters to the SQLCommand

        SqlParameter paramUsername = new SqlParameter();
        paramUsername.ParameterName = "@username";
        paramUsername.Value = username;
        myCommand.Parameters.Add(paramUsername);

        SqlParameter paramPassword = new SqlParameter();
        paramPassword.ParameterName = "@password";
        paramPassword.Value = password;
        myCommand.Parameters.Add(paramPassword);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        //Handle Success
        if (myReader.HasRows)
        {
            //Store the results
            while (myReader.Read())
            {
                //Setup the Session object
                HttpContext.Current.Session["user_id"] = myReader["user_id"].ToString();
                HttpContext.Current.Session["first_name"] = myReader["first_name"].ToString();
                HttpContext.Current.Session["last_name"] = myReader["last_name"].ToString();
                HttpContext.Current.Session["phone"] = myReader["phone"].ToString();
                HttpContext.Current.Session["email"] = myReader["email"].ToString();
                HttpContext.Current.Session["school"] = myReader["school"].ToString();
                HttpContext.Current.Session["role_id"] = myReader["role_id"].ToString();
                HttpContext.Current.Session["styleSheet"] = myReader["styleSheet"].ToString();

                returnValue = true;
            }
        }
        myConnection.Close();
        return returnValue;
    }
    
    //Updates account and password
    public static void updateAccount(string userID, string fName, string lName, string phone, string email, string school, string styleSheet, string password)
    {

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "account_UpdateWithPassword";

        //Add Parameters to the SQLCommand
        SqlParameter sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@user_id";
        sqlParam.Value = userID;
        myCommand.Parameters.Add(sqlParam);

        sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@fName";
        sqlParam.Value = fName;
        myCommand.Parameters.Add(sqlParam);

        sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@lName";
        sqlParam.Value = lName;
        myCommand.Parameters.Add(sqlParam);

        sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@phone";
        sqlParam.Value = phone;
        myCommand.Parameters.Add(sqlParam);

        sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@email";
        sqlParam.Value = email;
        myCommand.Parameters.Add(sqlParam);

        sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@school";
        sqlParam.Value = school;
        myCommand.Parameters.Add(sqlParam);

        sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@styleSheet";
        sqlParam.Value = styleSheet;
        myCommand.Parameters.Add(sqlParam);

        sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@password";
        sqlParam.Value = password;
        myCommand.Parameters.Add(sqlParam);


        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    //Updates account but not password
    public static void updateAccount(string userID, string fName, string lName, string phone, string email, string school, string styleSheet)
    {

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "account_UpdateNoPassword";

        //Add Parameters to the SQLCommand
        SqlParameter sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@user_id";
        sqlParam.Value = userID;
        myCommand.Parameters.Add(sqlParam);

        sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@fName";
        sqlParam.Value = fName;
        myCommand.Parameters.Add(sqlParam);

        sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@lName";
        sqlParam.Value = lName;
        myCommand.Parameters.Add(sqlParam);

        sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@phone";
        sqlParam.Value = phone;
        myCommand.Parameters.Add(sqlParam);

        sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@email";
        sqlParam.Value = email;
        myCommand.Parameters.Add(sqlParam);

        sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@school";
        sqlParam.Value = school;
        myCommand.Parameters.Add(sqlParam);

        sqlParam = new SqlParameter();
        sqlParam.ParameterName = "@styleSheet";
        sqlParam.Value = styleSheet;
        myCommand.Parameters.Add(sqlParam);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    public static bool usernameExists(string username)
    {
        bool returnValue = false;

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "CheckForExistingUsername";

        //Add Parameters to the SQLCommand
        SqlParameter paramUsername = new SqlParameter();
        paramUsername.ParameterName = "@username";
        paramUsername.Value = username;
        myCommand.Parameters.Add(paramUsername);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        if (myReader.HasRows)
        {
            returnValue = true;
        }

        myConnection.Close();
        return returnValue;
    }

#endregion

#region "Content Retrieval"

    public static void configureAudeme(Audeme myAudeme)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "returnAudemeDetails";

        //Add Parameters to the SQLCommand
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@audeme_id";
        param.Value = myAudeme.getID();
        myCommand.Parameters.Add(param);

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        if (!myReader.HasRows)
        {
            //If there are no rows returned, close the DB connection and return an error
            myConnection.Close();
        }
        else
        {
            //Store the results
            while (myReader.Read())
            {
                //Setup the Audeme object
                myAudeme.setCreationDate(myReader["datetime"].ToString());
                myAudeme.setCreator(myReader["user_id"].ToString());
                myAudeme.setDescription(myReader["description"].ToString());
                myAudeme.setFileName(myReader["file_name"].ToString());
                myAudeme.setName(myReader["name"].ToString());
                myAudeme.setSoundType(Convert.ToInt16(myReader["soundtype_id"]));
                myAudeme.setTags(myReader["tags"].ToString());
                myAudeme.setSoundComposition(myReader["soundComposition"].ToString());
                myAudeme.setRelatedAudemes(myReader["relatedAudemes"].ToString());
                myAudeme.setLocked(Convert.ToBoolean(myReader["locked"].ToString()));
            }
            myConnection.Close();
        }
    }

    public static List<audemeSession> returnAudemeSessionList(int userID)
    {
        List<audemeSession> myAudemeSessionList = new List<audemeSession>();
        
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "returnAudemeSessionList";

        //Add Parameters to the SQLCommand
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@user_id";
        param.Value = userID;
        myCommand.Parameters.Add(param);

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        if (myReader.HasRows)
        {
            //Store the results
            while (myReader.Read())
            {
                int curSessionIndex = -1;
                int curSessionID = Convert.ToInt16(myReader["AudemeCol_ID"]);

                //See if this Session is already in the list
                for (int i = 0; i < myAudemeSessionList.Count; i++)
                {
                    if (myAudemeSessionList[i].audemeSessionID == curSessionID)
                    {
                        curSessionIndex = i;
                        break;
                    }
                }

                //If it doesn't exist, add the Session to the sessions list
                if ( curSessionIndex == -1)
                {
                    audemeSession mySession = new audemeSession(
                                                    curSessionID,
                                                    myReader["Name"].ToString(),
                                                    new List<Audeme>());
                    myAudemeSessionList.Add(mySession);
                    curSessionIndex = myAudemeSessionList.Count - 1;
                }                
                    
                Audeme tempAudeme = new Audeme();

                if ( myReader["audeme_id"].ToString() != null && myReader["audeme_id"].ToString() != "" )
                {    
                    tempAudeme.setID(Convert.ToInt16(myReader["audeme_id"]));
                    tempAudeme.setFileName(myReader["file_name"].ToString());
                    tempAudeme.setName(myReader["name"].ToString());
                    tempAudeme.setSoundComposition(myReader["soundComposition"].ToString());
                    tempAudeme.setSoundType(Convert.ToInt16(myReader["soundtype_id"]));
                    tempAudeme.setTags(myReader["tags"].ToString());
                    tempAudeme.setDescription(myReader["description"].ToString());
                    myAudemeSessionList[curSessionIndex].audemesList.Add(tempAudeme);
                }                                
            }
            myConnection.Close();
        }
        myConnection.Close();
        return myAudemeSessionList;
    }

    public static DataTable returnAudemeCols()
    {
        DataTable dt = new DataTable();

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "Columns_GetAll";

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();
        dt.Load(myReader);
        
        myConnection.Close();
        return dt;
    }

    public static DataTable returnAudemeCol_ByID(int audemeCol_id)
    {
        DataTable dt = new DataTable();

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "Columns_GetByID";

        //Add Parameters to the SQLCommand
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@columnID";
        param.Value = audemeCol_id;
        myCommand.Parameters.Add(param);

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();
        dt.Load(myReader);

        myConnection.Close();
        return dt;
    }

    public static AudemeGrid returnAudemeGrid(int audemeGrid_id)
    {
        //By default, returning an audeme grid means to play it
        AudemeGrid ag = dbManager.returnAudemeGrid(audemeGrid_id, false);
        return ag;
    }

    public static AudemeGrid returnAudemeGrid(int audemeGrid_id, bool ignorePlayCount)
    {
        if (ignorePlayCount)
        {
            AudemeGrid_RecordPlayed(audemeGrid_id);
        }

        AudemeGrid myAudemeGrid = new AudemeGrid();
        
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "returnAudemeGridComposition";

        //Add Parameters to the SQLCommand
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@audemeGrid_id";
        param.Value = audemeGrid_id;
        myCommand.Parameters.Add(param);

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        if (myReader.HasRows)
        {
            //Store the results
            while (myReader.Read())
            {

                if (myAudemeGrid.getnumColumns() == 0)
                {
                    //Setup the AudemeGrid object if it has not been done
                    int numColumns = Convert.ToInt16(myReader["numColumns"].ToString());
                    myAudemeGrid.setName(myReader["GridName"].ToString());
                    myAudemeGrid.setnumColumns(numColumns);
                    /* myAudemeGrid.setnumRows(Convert.ToInt16(myReader["numRows"].ToString())); */

                    //Create empty AudemeGridColumns and put them in the AudemeGrid
                    for (int i = 0; i < numColumns; i++)
                    {
                        AudemeGridColumn tempColumn = new AudemeGridColumn();
                        myAudemeGrid.setColumn(i, tempColumn);
                    }
                }

                //Set the AudemeGridColumn information
                int columnPosition = Convert.ToInt16(myReader["Col_position"].ToString()) - 1;
                AudemeGridColumn myColumn = myAudemeGrid.getColumn(columnPosition);

                if (myColumn.getName() == null)
                {
                    //Setup the Column if it hasn't been done
                    myColumn.setName(myReader["Col_Name"].ToString());
                }

                //Set the AudemeGridCell information
                int cellPosition = Convert.ToInt16(myReader["Sound_Position"].ToString()) - 1;
                AudemeGridCell myCell = new AudemeGridCell();

                myColumn.setCell(cellPosition, myCell);

                myCell.setID(Convert.ToInt16(myReader["Sound_id"].ToString()));
                myCell.setName(myReader["Sound_Name"].ToString());
                myCell.setFileName(myReader["Sound_FileName"].ToString());
                myCell.setTags(myReader["tags"].ToString());
            }
        }
        //Closes the database connection
        myConnection.Close();
        return myAudemeGrid;
    }

    public static List<Audeme> returnAudemesCreatedBy(int user_id)
    {
        List<Audeme> myAudemeList = new List<Audeme>();
        
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "returnAudemesCreatedByUser";

        //Add Parameters to the SQLCommand
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@user_id";
        param.Value = user_id;
        myCommand.Parameters.Add(param);

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        if (myReader.HasRows)
        {
            //Store the results
            while (myReader.Read())
            {
                //Setup the Audeme list
                int audeme_id = Convert.ToInt16(myReader["audeme_id"].ToString());
                Audeme audeme = new Audeme(audeme_id);
                myAudemeList.Add(audeme);
            }
        }

        myConnection.Close();

        return myAudemeList;
    }

    public static List<Audeme> returnAudemesInSession(int session_id)
    {
        List<Audeme> myAudemeList = new List<Audeme>();

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "returnAudemesInSession";

        //Add Parameters to the SQLCommand
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@session_id";
        param.Value = session_id;
        myCommand.Parameters.Add(param);

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        if (myReader.HasRows)
        {
            //Store the results
            while (myReader.Read())
            {
                //Setup the Audeme list
                int audeme_id = Convert.ToInt16(myReader["audeme_id"].ToString());
                Audeme audeme = new Audeme(audeme_id);
                myAudemeList.Add(audeme);
            }
        }

        myConnection.Close();
        return myAudemeList;
    }

    public static List<Audeme> returnDashboardList(int user_id)
    {
        List<Audeme> myAudemeList = new List<Audeme>();

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "returnAudemesInDashboard";

        //Add Parameters to the SQLCommand
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@user_id";
        param.Value = user_id;
        myCommand.Parameters.Add(param);

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        if (myReader.HasRows)
        {
            //Store the results
            while (myReader.Read())
            {
                //Setup the Audeme list
                int audeme_id = Convert.ToInt16(myReader["audeme_id"].ToString());
                Audeme audeme = new Audeme(audeme_id);
                myAudemeList.Add(audeme);
            }
        }

        myConnection.Close();
        return myAudemeList;
    }

    public static DataTable returnDashboardList_Grids(int user_id)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "ReturnGridsInDashboard";

        //Add Parameters to the SQLCommand
        SqlParameter param2 = new SqlParameter();
        param2.ParameterName = "@user_id";
        param2.Value = user_id;
        myCommand.Parameters.Add(param2);

        //Run the Query
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        //Store the response in a DataTable
        DataTable dt = new DataTable();
        dt.Load(myReader);

        //Close the connection
        myConnection.Close();

        //Return the results
        return dt;
    }

    public static DataTable returnRiddleCategories()
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "ReturnRiddleCategories";

        //Run the Query
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        //Store the response in a DataTable
        DataTable dt = new DataTable();
        dt.Load(myReader);

        //Close the connection
        myConnection.Close();

        //Return the results
        return dt;
    }

    public static DataTable returnRiddlesByCategory(string Category)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "Riddles_GetByCategory";

        //Add Parameters to the SQLCommand
        SqlParameter param2 = new SqlParameter();
        param2.ParameterName = "@category";
        param2.Value = Category;
        myCommand.Parameters.Add(param2);

        //Run the Query
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        //Store the response in a DataTable
        DataTable dt = new DataTable();
        dt.Load(myReader);

        //Close the connection
        myConnection.Close();

        //Return the results
        return dt;
    }

    public static DataTable returnRiddlesByID(int RiddleID)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "Riddles_GetByID";

        //Add Parameters to the SQLCommand
        SqlParameter param2 = new SqlParameter();
        param2.ParameterName = "@riddleID";
        param2.Value = RiddleID;
        myCommand.Parameters.Add(param2);

        //Run the Query
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        //Store the response in a DataTable
        DataTable dt = new DataTable();
        dt.Load(myReader);

        //Close the connection
        myConnection.Close();

        //Return the results
        return dt;
    }

    public static List<Audeme> returnSearchResults(string searchTerm)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "search";

        //Add Parameters to the SQLCommand
        SqlParameter param2 = new SqlParameter();
        param2.ParameterName = "@searchTerm";
        param2.Value = searchTerm;
        myCommand.Parameters.Add(param2);

        //Run the Query
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();
        List<Audeme> audemeList = new List<Audeme>();

        if (myReader.HasRows)
        {
            //Store the results
            while (myReader.Read())
            {
                //Setup the Audeme list
                int audeme_id = Convert.ToInt16(myReader["audeme_id"].ToString());
                Audeme audeme = new Audeme(audeme_id);
                audemeList.Add(audeme);
            }
        }

        //Close the connection
        myConnection.Close();

        //Return the audeme list
        return audemeList;
    }

    public static List<Audeme> returnSearchResults_FilteredByType(string searchTerm, int filterTypeID)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "search";

        //Add Parameters to the SQLCommand
        SqlParameter param2 = new SqlParameter();
        param2.ParameterName = "@searchTerm";
        param2.Value = searchTerm;
        myCommand.Parameters.Add(param2);

        param2 = new SqlParameter();
        param2.ParameterName = "@filterTypeID";
        param2.Value = filterTypeID;
        myCommand.Parameters.Add(param2);

        //Run the Query
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();
        List<Audeme> audemeList = new List<Audeme>();

        if (myReader.HasRows)
        {
            //Store the results
            while (myReader.Read())
            {
                //Setup the Audeme list
                int audeme_id = Convert.ToInt16(myReader["audeme_id"].ToString());
                Audeme audeme = new Audeme(audeme_id);
                audemeList.Add(audeme);
            }
        }

        //Close the connection
        myConnection.Close();

        //Return the audeme list
        return audemeList;
    }

    public static DataTable returnSearchResults_Grids(string searchTerm)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "Search_Grids";

        //Add Parameters to the SQLCommand
        SqlParameter param2 = new SqlParameter();
        param2.ParameterName = "@searchTerm";
        param2.Value = searchTerm;
        myCommand.Parameters.Add(param2);

        //Run the Query
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();
        
        //Store the response in a DataTable
        DataTable dt = new DataTable();
        dt.Load(myReader);

        //Close the connection
        myConnection.Close();

        //Return the results
        return dt;
    }

    public static List<Audeme> returnSearchResults_Locked()
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "audeme_FindLocked";
        
        //Run the Query
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();
        List<Audeme> audemeList = new List<Audeme>();

        if (myReader.HasRows)
        {
            //Store the results
            while (myReader.Read())
            {
                //Setup the Audeme list
                int audeme_id = Convert.ToInt16(myReader["audeme_id"].ToString());
                Audeme audeme = new Audeme(audeme_id);
                audemeList.Add(audeme);
            }
        }

        //Close the connection
        myConnection.Close();

        //Return the audeme list
        return audemeList;
    }

    public static List<Audeme> returnSequenceComposition(string audeme_id)
    {
        List<Audeme> mySequence = new List<Audeme>();

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "returnSequenceComposition";

        //Add Parameters to the SQLCommand
        SqlParameter param2 = new SqlParameter();
        param2.ParameterName = "@audeme_id";
        param2.Value = audeme_id;
        myCommand.Parameters.Add(param2);

        //Run the Query
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();
        
        if (myReader.HasRows)
        {
            //Store the results
            while (myReader.Read())
            {
                //Setup the Audeme list
                int componentID = Convert.ToInt16(myReader["component_id"].ToString());
                Audeme component = new Audeme(componentID);
                mySequence.Add(component);
            }
        }

        //Close the connection
        myConnection.Close();

        return mySequence;
    }

    #endregion

#region Tracking and Rating
    public static void rateAudeme(string audeme_id, string concept_rating, string component_rating)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "rateAudeme";

        //Add Parameters to the SQLCommand

        SqlParameter paramAudemeID = new SqlParameter();
        paramAudemeID.ParameterName = "@audeme_id";
        paramAudemeID.Value = audeme_id;
        myCommand.Parameters.Add(paramAudemeID);

        SqlParameter paramConcept = new SqlParameter();
        paramConcept.ParameterName = "@concept_rating";
        paramConcept.Value = concept_rating;
        myCommand.Parameters.Add(paramConcept);

        SqlParameter paramComponent = new SqlParameter();
        paramComponent.ParameterName = "@component_rating";
        paramComponent.Value = component_rating;
        myCommand.Parameters.Add(paramComponent);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    public static void audeme_RecordPlayed(string audeme_id)
    {
        //Call this if there is no user logged in.  It will pass the "guest" user ID to the real function

        //Get the user id
        object oUser_ID = HttpContext.Current.Session["user_id"];
        string strUser_ID;

        if (oUser_ID != null)
        {
            strUser_ID = HttpContext.Current.Session["user_id"].ToString();
        }
        else
        {
            strUser_ID = "7";
        }

        audeme_RecordPlayed(audeme_id, strUser_ID);
    }

    public static void audeme_RecordPlayed(string audeme_id, string user_id)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "Audeme_RecordPlayed";

        //Add Parameters to the SQLCommand
        SqlParameter paramAudemeID = new SqlParameter();
        paramAudemeID.ParameterName = "@audemeID";
        paramAudemeID.Value = audeme_id;
        myCommand.Parameters.Add(paramAudemeID);

        SqlParameter paramConcept = new SqlParameter();
        paramConcept.ParameterName = "@userID";
        paramConcept.Value = user_id;
        myCommand.Parameters.Add(paramConcept);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    public static void audemeGrid_RecordPlayed(string audemeGrid_id)
    {
        //Call this if there is no user logged in.  It will pass the "guest" user ID to the real function

        audemeGrid_RecordPlayed(audemeGrid_id, "7");
    }

    public static void audemeGrid_RecordPlayed(string audemeGrid_id, string user_id)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "Audeme_RecordPlayed";

        //Add Parameters to the SQLCommand
        SqlParameter paramAudemeID = new SqlParameter();
        paramAudemeID.ParameterName = "@audemeGridID";
        paramAudemeID.Value = audemeGrid_id;
        myCommand.Parameters.Add(paramAudemeID);

        SqlParameter paramConcept = new SqlParameter();
        paramConcept.ParameterName = "@userID";
        paramConcept.Value = user_id;
        myCommand.Parameters.Add(paramConcept);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    public static void audemeCorrect(string audemeID, string correct)
    {
        //Open DB
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;

        //Check to see if there is already a playListRecord for the audeme
        myCommand.CommandText = "SELECT * FROM playListRecords WHERE audemeID = " + audemeID;
        myCommand.ExecuteNonQuery();

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();

        if (myReader.HasRows)
        {
            if (correct == "1")
            {
                myCommand.CommandText = "UPDATE playListRecords SET correct = correct + 1 WHERE audemeID = " + audemeID;
            }
            else
            {
                myCommand.CommandText = "UPDATE playListRecords SET incorrect = incorrect + 1 WHERE audemeID = " + audemeID;
            }
        }
        else
        {
            if (correct == "1")
            {
                myCommand.CommandText = "INSERT INTO playListRecords VALUES ('" + audemeID + "', '1', '0')";
            }
            else
            {
                myCommand.CommandText = "INSERT INTO playListRecords VALUES ('" + audemeID + "', '0', '1')";
            }
        }

        myReader.Close();
        myCommand.ExecuteNonQuery();

        //Closes the database connection
        myConnection.Close();
    }

    public static void AudemeGrid_RecordPlayed(int audemeGrid_id)
    {
        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "AudemeGrid_RecordPlayed";

        //Get the user id
        object oUser_ID = HttpContext.Current.Session["user_id"];
        string strUser_ID;

        if (oUser_ID != null)
        {
            strUser_ID = HttpContext.Current.Session["user_id"].ToString();
        }
        else
        {
            strUser_ID = "7";
        }

        //Add Parameters to the SQLCommand
        SqlParameter param = new SqlParameter();
        param.ParameterName = "@audemeGridID";
        param.Value = audemeGrid_id;
        myCommand.Parameters.Add(param);

        param = new SqlParameter();
        param.ParameterName = "@userID";
        param.Value = strUser_ID;
        myCommand.Parameters.Add(param);

        //Read the Response from the DB
        myCommand.Prepare();
        myCommand.ExecuteNonQuery();
        myConnection.Close();
    }

    public static DataTable report_AudemeActivity()
    {
        DataTable dt = new DataTable();

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "report_AudemeActivity";

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();
        dt.Load(myReader);

        myConnection.Close();
        return dt;
    }

    public static DataTable report_AudemesInGrids()
    {
        DataTable dt = new DataTable();

        SqlConnection myConnection = new SqlConnection(dbManager.connectionString);
        myConnection.Open();

        //Create and Execute the SQL Command
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.CommandType = CommandType.StoredProcedure;
        myCommand.CommandText = "report_AudemesInGrids";

        //Read the Response from the DB
        SqlDataReader myReader = null;
        myReader = myCommand.ExecuteReader();
        dt.Load(myReader);

        myConnection.Close();
        return dt;
    }

    #endregion

}