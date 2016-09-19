<%@ Page Language="C#" %>

<html>
    <head>
        <!--#Include virtual="~\jhesch\includes\header.html"-->
        <title>Create</title>
        <% 
            Response.Write(styleManager.initializeStyles());  
        %>
    </head>    
    <body>
        <div id="container">  <!--  Free CSS Template from www.TemplateMo.com  -->
	        <% Response.Write(styleManager.initializeTopNav()); %>	
            <div id="content">
            	<div id="content_left">
                    <div class="title">Create</div>
                    <p>Use the tools below to contribute your own content to the audeme community.</p>

                    <p><a href="createAudeme.aspx">Create an Audeme</a> - upload an MP3 file from your computer and fill in details about it.</p>

                    <p><a href="gridCreator.aspx">Create a Grid</a> - use existing sets of audemes to create your own grid.</p>

                    <h2>Create Sequences</h2> 
                    <p>Combine audemes and sound effects to create new sound sequences.</p>                   
                    <p><a href="sequenceCreator.aspx?AudemeGridID=4">Audeme Set 1</a> (contains:  Elements, Biology, Transformations, Size)</p>
                    <p><a href="sequenceCreator.aspx?AudemeGridID=5">Audeme Set 2</a> (contains:  Elements, Energy Sources, Energy Properties, Transformations)</p>

                    
                               
                </div> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\jhesch\includes\footer.html"-->
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Create')").addClass('current'); //Makes the proper top nav item selected
    </script>
    </body>
</html>    
