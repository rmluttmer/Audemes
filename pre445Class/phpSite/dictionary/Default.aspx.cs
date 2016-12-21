using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class jhesch_dictionary_Default3 : System.Web.UI.Page
{
    string searchTerm; 

    protected void Page_Load(object sender, EventArgs e)
    {
        //Set this page as the "Previous Page" so that the user can be redirected here when they save an audeme or log in
        Session["PreviousPage"] = Request.Url.ToString();

        //Get the search term from the URL
        searchTerm = txtSearchTerm.Text;
        
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["searchTerm"] != null)
            {
                searchTerm = Request.QueryString["searchTerm"].ToString();
            }

            
            //Handle setting what appears in the search text box
            if (String.IsNullOrEmpty(txtSearchTerm.Text))
            {
                txtSearchTerm.Text = searchTerm;
            }
        }

        //Set which panels show based on checkbox filters
        initializePanelVisibility();

        Search(searchTerm);

        
    }

    protected void Search(string strTerm)
    {
        if (String.IsNullOrEmpty(strTerm))
        {
            pnlResults_Audemes.Visible = false;
            pnlResults_Grids.Visible = false;
            pnlResults_SoundEffects.Visible = false;
            pnlResults_Default.Visible = true;
            return;
        }

        pnlResults_Audemes.Visible = chkAudemes.Checked;
        pnlResults_Grids.Visible = chkGrids.Checked;
        pnlResults_SoundEffects.Visible = chkSoundEffects.Checked;

        //Search for audemes
        if (chkAudemes.Checked)
        {
            List<Audeme> audemeList = dbManager.returnSearchResults(strTerm);
            results_Audemes.InnerHtml = audemeListViewer.viewAsSearchList(audemeList);
        }

        //Search for grids
        if (chkGrids.Checked)
        {
            DataTable dt = new DataTable();
            dt = dbManager.returnSearchResults_Grids(strTerm);

            if (dt.Rows.Count > 0)
            {
                results_Grids.InnerHtml = audemeListViewer.viewAsSearchList_Grids(dt);
            }

        }

        //Search for sound effects
        if (chkSoundEffects.Checked)
        {
            List<Audeme> audemeList = dbManager.returnSearchResults_FilteredByType(strTerm, (int)Audeme.SoundTypes.SoundEffect);
            results_SoundEffects.InnerHtml = audemeListViewer.viewAsSearchList_SoundEffectsOnly(audemeList);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search(txtSearchTerm.Text);
    }

    protected void initializePanelVisibility()
    {
        if (!String.IsNullOrEmpty(searchTerm))
        {
            pnlResults_Default.Visible = false;

            if (chkAudemes.Checked)
            {
                pnlResults_Audemes.Visible = true;
                
            }
            else
            {
                pnlResults_Audemes.Visible = false;
            }

            if (chkSoundEffects.Checked)
            {
                pnlResults_SoundEffects.Visible = true;
            }
            else
            {
                pnlResults_SoundEffects.Visible = false;
            }

            if (chkGrids.Checked)
            {
                pnlResults_Grids.Visible = true;
            }
            else
            {
                pnlResults_Grids.Visible = false;
            }

            if (!chkAudemes.Checked && !chkGrids.Checked && !chkSoundEffects.Checked)
            {
                pnlResults_Audemes.Visible = true;
                results_Audemes.InnerHtml = "<p style='color: red'>You must search for at least one type of content (audemes, atomic sounds, or grids).  Please check the appropriate box(es) and click search again.</p>";
            }

        }
        else
        {
            pnlResults_Audemes.Visible = false;
            pnlResults_Grids.Visible = false;
            pnlResults_SoundEffects.Visible = false;
            pnlResults_Default.Visible = true;
        }
    }

    protected void searchByTopic(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        searchTerm = lb.Text;
        txtSearchTerm.Text = searchTerm;
        Search(searchTerm);
        initializePanelVisibility();
    }
}