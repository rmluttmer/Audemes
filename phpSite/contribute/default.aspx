<%@ Page Language="C#" %>

<html>
    <head>
        <!--#Include virtual="~\includes\header.html"-->
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

                    <p><a href="/dashboard/createSession.aspx">Create a Set</a> - organize audemes in your locker into a set than can be used to create game grids.</p>

                    <p><a href="gridCreator.aspx">Create a Grid</a> - use existing sets of audemes to create your own grid.</p>

                    <h2>Create Sequences</h2> 
                    <p>Combine audemes and atomic sounds to create new sound sequences.  Any grid of audemes from the dictionary can be used to as a "toolbox" for creating new sequences.  Alternately, you can make your own grids (above) and use those to create new sequences.</p>                   
                    <p><a href="sequenceCreator.aspx?AudemeGridID=26">General Toolbox</a></p>
                    <p><a href="sequenceCreator.aspx?AudemeGridID=24">Animals and Nature</a></p>
                    <p><a href="/dictionary">Find other grids in the Dictionary &raquo;</a></p>

                    
                               
                </div> <!-- end of content_left -->        
    	    <div id="bottom_bg"></div>
        </div> <!-- end of content -->
               
        <!--#Include virtual="~\includes\footer.html"-->
    </div> <!-- end of container -->
        
    <script type="text/javascript">
        $("a:contains('Create')").addClass('current'); //Makes the proper top nav item selected
    </script>
    </body>
</html>    
