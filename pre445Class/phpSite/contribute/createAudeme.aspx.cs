using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class jhesch_CreateAudeme : System.Web.UI.Page
{
    string strFileName = "";
    string strFileNameNoExtension = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["PreviousPage"] = Request.Url.ToString();
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string tags = txtTags.Text;
        string name = txtName.Text;
        string description = txtDescription.Text;
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

        if (txtName.Text == "")
        {
            strMessage += "Name requried.  ";
        }

        if (strMessage != "")
        {
            lblMessage.Text = strMessage;
            return;
        }

        if (UploadFile())
        {
            DateTime dateTime = DateTime.Now;
            string soundComposition = Request.Form["soundComposition"];

            ///Create the audeme if there are no errors
            if (strMessage == "")
            {
                int audemeID = dbManager.createAudeme(tags, strFileNameNoExtension, name, description, userID, dateTime, soundComposition);
                dbManager.addToDashboard(userID.ToString(), audemeID.ToString());

                lblMessage.Text = "Audeme '" + name + "' created successfully.";

                //Response.Redirect("/createAudeme.aspx?error=Audeme '" + name + "' created successfully.");

            }
            else
            {
                lblMessage.Text = "Audeme " + name + " created successfully.";
                //Response.Redirect("/createAudeme.aspx?error=" + strMessage);
            }
        }
    }

    protected bool UploadFile()
    {
        // Specify the path to save the uploaded file to.
        string strMessage = "";
        string savePath = @"C:\Inetpub\wwwroot\MP3s\audemes\";
        strFileName = Server.HtmlEncode(fuMP3.FileName);     

        if (fuMP3.HasFile)
        {
            int fileSize = fuMP3.PostedFile.ContentLength;

            // Allow only files less than 6,000,000 bytes (approximately 6 MB) to be uploaded.
            if (fileSize > 6000000)
            {
                strMessage += "Your file was not uploaded because it exceeds the 6 MB size limit.";
            }

            // Get the extension of the uploaded file.
            string extension = System.IO.Path.GetExtension(strFileName);

            // Allow only files with the .mp3 extension to be uploaded.
            if (extension != ".mp3")
            {
                // Notify the user why their file was not uploaded.
                strMessage += "Your file was not uploaded because it is not an MP3 file.";
            }

        }
        else
        {
            strMessage += "You did not specify a file to upload.";
        }

        //If there are no errors, upload the file
        if (strMessage == "")
        {
            strFileName = DateTime.Now.ToString("ddmmyyhhmmss") + strFileName;
            savePath += strFileName;
            fuMP3.SaveAs(savePath);
            strFileNameNoExtension = Path.GetFileNameWithoutExtension(strFileName);
            lblMessage.Text = "Your file was uploaded successfully.";
            return true;
        }
        else
        {
            //Otherwise, display an error message.
            lblMessage.Text = strMessage;
            return false;
        }
    }

    
}