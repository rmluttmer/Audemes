<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultSusan.aspx.cs" Inherits="jhesch_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <!--#Include virtual="~\includes\header.html"-->
    <title>Audemes</title>
    <% 
        Response.Write(styleManager.initializeStyles());  
    %>
    <style type="text/css">
        #menu
        {
            margin-left: 0px;   
        }
    </style>

</head>
    <body>
        <div id="container"> 

            <div><!--begin top section with logo, top nav and riddle of the day -->
                        <div id="logo"><img src="images/listeningnew.png" alt="Audemes student listening" height="300" width="315" /> </div>
                        <% Response.Write(styleManager.initializeTopNav(false)); %> 

                        
                        <br />
                        <br />
                        <div id="daily" style="width: 535px; height: 155px;">
                            <h3>Try the Riddle of the Day:</h3>
                            
                                    <p style="float: left">Riddle:&nbsp;&nbsp;</p><br /><audio id="Riddle of the Day" controls="controls"><source src="../MP3s/audemes/02%20Solar%20Energy%20dawn%20rooster%20sun%20electricty%20energy%20lightning.mp3"></audio><br /><br />
                                    <p style="float: left">Answer:&nbsp;</p><br /><audio id="Answer" controls="controls"><source src="../MP3s/audemes/A_solar_energy.mp3"></audio></div>
            </div><!--end top section with logo, top nav and riddle of the day -->

            
            <div id="content">
            	
                <div id="content-left" style="display: inline-block; margin: 30px; overflow: scroll; -webkit-overflow-scrolling: touch;">
           

        	        <div class="title">What are Audemes?</div>
                    
                    <p>Pronounced "awe deems," they are brief audio collages that combine sound effects, sometimes with music, to form aural symbols that signify various ideas, things, actions and situations. For example, the sound
of a dog barking combined with a cat meow can combine to create a 3 to 4 second audeme that
signifies the idea "pets." Audemes can be very flexible in their meanings. If we add the rumble of
thunder and the splish-splash of raindrops, the "pets" audeme becomes an audeme for "raining
cats and dogs." Or, we might start with the splish-splash but add sleigh bells jingling to suggest
the idea of "snow." </p><br />
                    <p>Although many things or concepts in the world can be immediately
associated with a specific sound (like the concept "dog" is clearly signified by the sound of
barking), other concepts are basically silent and must be metaphorically suggested (like "snow"
can be signified as "precipitation in winter"). This requires some mental agility, and students
really enjoy the challenge of figuring out audeme meanings, and suggesting new audemes, and
competing in audeme riddle games. For blind and visually impaired students, the opportunity to
engage in a sound-based learning activity can be especially gratifying.</p><br />

<p>Since 2007 we have worked with blind and visually impaired students and their teachers to
develop audemes and audeme games. The results have been very encouraging. Students who
hear audemes presented with educational materials score significantly better in tests of those
materials than students who did not hear the audemes. And when students play audeme riddle
games based on chapters from standard science textbooks, they score significantly better in
end-of-chapter tests than in tests for chapters learned without audeme games. After a year of
audeme game play, students expressed significantly more positive subjective attitudes about
science and science learning. These results have helped our work generate grant funding from
the Nina Mason Pulliam Charitable Trust, Google Research Awards and the National Science
Foundation.</p><br />

<p>This website offers a basic introduction to the whole idea of audemes and audeme games. We
believe we have just begun to explore the possibilities of audemes, audeme games and other
applications yet to be developed. We welcome your comments, questions and ideas.</p><br />

<p>Let us know what you think about the whole thing by using our contact form here: <a href="/contact">Contact Us</a>.</p> 
<br /><br />              
                </div> <!-- end of content left -->
                
                
            </div> <!-- end of content -->
            
            <!--#Include virtual="~\includes\footer.html"--> 
        </div> <!-- end of container -->
        
        <script type="text/javascript">
            $("a:contains('Home')").addClass('current'); //Makes the proper top nav item selected
        </script>
    </body>
</html>