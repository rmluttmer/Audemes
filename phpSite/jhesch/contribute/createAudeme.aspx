<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createAudeme.aspx.cs" Inherits="jhesch_CreateAudeme" %>

<html>
    <head>
        <!--#Include virtual="~\jhesch\includes\header.html"--> 
        <title>Create an Audeme</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
        <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	        <% Response.Write(styleManager.initializeTopNav()); %> 	
            <div id="content">
            	<asp:Panel id="content_left" runat="server">

                    <div class="title">Create an Audeme</div>                    
                
                    <form id="formCreateAudeme" runat="server">
                        <label for="name" class="text">Name*<br /></label>
                        <asp:TextBox id="txtName"  name="name" type="text" autofocus="true" required="required" maxlength="50" placeholder="Up to 50 characters" runat="server"></asp:TextBox><br />

                        <label for="description" class="text">Concept<br /></label>
                        <asp:TextBox id="txtDescription"  name="description" maxlength="250" type="text" placeholder="How do the sounds explain the audeme" runat="server" /><br />

                        <label for="tags" class="text">Tags<br /></label>
                        <asp:TextBox id="txtTags"  name="tags" type="text" maxlength="250" placeholder="Separate tags with a comma (e.g., 'tag, tag, tag')" runat="server" /><br />
                            
                        <label for="soundComposition" class="text">Sound Composition</label>
                        <asp:TextBox id="txtSoundComposition"  name="soundComposition" type="text" maxlength="100" placeholder="What sounds are in the audeme?" runat="server" /><br />
                        
                        <label for="fuMP3" class="text" >MP3 File*</label>
                        <asp:FileUpload ID="fuMP3" runat='server' />
                        <br />
                        <asp:Label ID="lblMessage" runat="server" />
                        <br />
                        <button type="button" class='promptAuthentication'>Login to Save</button>
                        <asp:button type='submit' id='Submit' OnClick="Submit_Click" Text="Create" runat="server"/>
                        
                        <br /><br />

                        <label style="width: 500px;">* required field</label>
                    </form>            
                </asp:Panel> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\jhesch\includes\footer.html"--> 
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Dictionary')").addClass('current'); //Makes the proper top nav item selected
        $("#error").html(getParameterByName("error")); //Fills in any errors
    </script>
    </body>
</html>    
