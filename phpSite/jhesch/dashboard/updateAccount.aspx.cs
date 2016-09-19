using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class jhesch_UpdateAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["PreviousPage"] = Request.Url.ToString();

        

        if (!IsPostBack)
        {
            if (isUserLoggedIn() == "Yes")
            {
                fName.Text = Session["first_name"].ToString();
                lName.Text = Session["last_name"].ToString();
                phone.Text = Session["phone"].ToString();
                email.Text = Session["email"].ToString();
                school.Text = Session["school"].ToString();
                styleSheet.SelectedValue = Session["styleSheet"].ToString();
            }
        }
        
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        lblMessage.Text = "";

        if (isUserLoggedIn() == "Yes")
        {
            //If the user has not entered anything for the passwords, do not update them and do not validate them.
            if (!(password.Text.Length == 0 && password2.Text.Length == 0))
            {
                if (password.Text.Length < 6 || password.Text.Length > 16)
                {
                    lblMessage.Text += "Password must be between 6 and 16 characters.  ";
                }

                if (!password.Text.Equals(password2.Text, StringComparison.Ordinal))
                {
                    lblMessage.Text += "Passwords do not match.  ";
                }
            }

            if (fName.Text.Length == 0)
            {
                lblMessage.Text += "First Name is required.  ";
            }

            if (lName.Text.Length == 0)
            {
                lblMessage.Text += "Last Name is required.  ";
            }

            if (email.Text.Length == 0)
            {
                lblMessage.Text += "Email is required.  ";
            }

            //If there are no other lblMessage.Texts, verify that the username does not exist in the database already
            if (lblMessage.Text == "")
            {

                if (password.Text.Length == 0 && password2.Text.Length == 0)
                {
                    dbManager.updateAccount(Session["user_id"].ToString(), fName.Text, lName.Text, phone.Text, email.Text, school.Text, styleSheet.SelectedValue.ToString());
                }
                else
                {
                    dbManager.updateAccount(Session["user_id"].ToString(), fName.Text, lName.Text, phone.Text, email.Text, school.Text, styleSheet.SelectedValue.ToString(), password.Text);
                }

                lblMessage.Text = "Account updated successfully.";

            }

        }
        else
        {
            lblMessage.Text = "Please log in.";
        }
    }

    protected string isUserLoggedIn()
    {
        short userID = 0;
        string strUserID;
        string strMessage = "";


        //Get the current User ID
        if (Session["user_id"] != null)
        {
            strUserID = Session["user_id"].ToString();
            if (Int16.TryParse(strUserID, out userID))
            {
                userID = Int16.Parse(strUserID);
            }
            else
            {
                strMessage += "Invalid user id.  ";
            }
        }
        else
        {
            strMessage += "Please log in.  ";
        }

        if (strMessage == "")
        {
            strMessage = "Yes";
        }

        return strMessage;
    }
}