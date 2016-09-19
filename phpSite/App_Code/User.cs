using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    private int user_id;
    private string username;
    private string first_name;
    private string last_name;
    private string phone;
    private string email;
    private string school;
    private int role_id;
    private List<audemeSession> audemeSessionList;

    public List<audemeSession> getAudemeSessionList(int user_id)
    {
        return dbManager.returnAudemeSessionList(user_id);
    }

    public int getUserID()
    {
        return this.user_id;
    }

    public void setUserID(int user_id)
    {
        this.user_id = user_id;
    }

    public string getUserName()
    {
        return this.username;
    }

    public void setUserName(string username)
    {
        this.username = username;
    }

    public string getFirstName()
    {
        return this.first_name;
    }

    public void setFirstName(string first_name)
    {
        this.first_name = first_name;
    }

    public string getLastName()
    {
        return this.last_name;
    }

    public void setLastName(string last_name)
    {
        this.last_name = last_name;
    }

    public string getPhone()
    {
        return this.phone;
    }

    public void setPhone(string phone)
    {
        this.phone = phone;
    }

    public string getEmail()
    {
        return this.email;
    }

    public void setEmail(string email)
    {
        this.email = email;
    }

    public string getSchool()
    {
        return this.school;
    }

    public void setSchool(string school)
    {
        this.school = school;
    }

    public int getRoleID()
    {
        return this.role_id;
    }

    public void setRoleID(int role_id)
    {
        this.role_id = role_id;
    }
}