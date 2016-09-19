<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="jhesch_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <!--#Include virtual="~\includes\header.html"-->
    <title>Audemes</title>
    <% 
        Response.Write(styleManager.initializeStyles());  
    %>
</head>
    <body>
        <div id="container"> 
            <% Response.Write(styleManager.initializeTopNav()); %> 
            <div id="banner">
                <div id="one" class="contentslider">
                    <div class="cs_wrapper">
                        <div class="cs_slider">
                        
                            <div class="cs_article">
                                <a href="#">
                                <img src="/images/articles/sound.jpg" alt="Sound Wave" />
                                </a>
                                
                                <div class="text">
                                    <h2> <a href="#">Have a Listen!</a> </h2>
                                    
                                    <p>
							        Welcome to the audemes web site.  
                                    </p>
                                    
                                    <p>Take a look at our database of audemes in the <a href="/dictionary">Dictionary</a>.</p>
                                    <p>Use pre-built audeme collections from the <a href="/games">Games</a> section.</p>
                                    <p>Store and sort your favorite audemes in the <a href="/dashboard">Dashboard</a>.</p>
                                    <p>Let us know what you think about the whole thing by <a href="/contact">Contacting Us</a>.</p>
                   		        </div>
                	        </div><!-- End cs_article -->
                            
                            <div class="cs_article">
                                <a href="#">
                                <img src="/images/articles/volcano.jpg" alt="Volcano exploding" />
                                </a>
                                
                                <div class="text">
                                    <h2> <a href="#">Featured Audeme:  Volcano</a> </h2>
                                    
                                    <p>
                                    <script type="text/javascript">
                                        var clicksound16 = createsoundbite('/MP3s/audemes/NSF WEB 2 Volcano.mp3'); var audemeID = 515;
                                    </script>
                                    <a href="#current" onclick="clicksound16.playclip()">Play</a>
                                    </p>

                                    <p>Definition:  A volcano is an opening in a planet's surface that allows hot magma, volcanic ash and gases to escape from below the surface.</p>
                                    
                                    <p>Atomic sound breakdown:  the volcano audeme consists of three atomic sounds, which relate to the ideas of earth, rising, and fire.</p>
                                    
                   		        </div>
                	        </div><!-- End cs_article -->
                            
                        </div><!-- End cs_slider -->
                    </div><!-- End cs_wrapper -->
                </div><!-- End contentslider -->

	        <!-- Site JavaScript -->
	        <script type="text/javascript" src="js/jquery.easing.1.3.js"></script>
	        <script type="text/javascript" src="js/jquery.ennui.contentslider.js"></script>
	        <script type="text/javascript">
	            $(function () {
	                $('#one').ContentSlider({
	                    width: '940px',
	                    height: '300px',
	                    speed: 800,
	                    easing: 'easeInOutBack'
	                });
	            });
		        </script>
            	
            </div><!-- end ob banner -->
            
            <div id="content">
            	
                <div id="content_left">
                
        	        <div class="title">What is an Audeme?</div>
                    
                    <p>Audemes are brief audio collages that combine sound effects, sometimes with music, to form
aural symbols that signify various ideas, things, actions and situations. For example, the sound
of a dog barking combined with a cat meow can combine to create a 3-4 second audeme that
signifies the idea "pets." Audemes can be very flexible in their meanings. If we add the rumble of
thunder and the splish-splash of raindrops, the "pets" audeme becomes an audeme for "raining
cats and dogs." Or, we might start with the splish-splash but add sleigh bells jingling to suggest
the idea of "snow." Although many things or concepts in the world can be immediately
associated with a specific sound (like the concept "dog" is clearly signified by the sound of
barking), other concepts are basically silent and must be metaphorically suggested (like "snow"
can be signified as "precipitation in winter"). This requires some mental agility, and students
really enjoy the challenge of figuring out audeme meanings, and suggesting new audemes, and
competing in audeme riddle games. For blind and visually impaired students, the opportunity to
engage in a sound-based learning activity can be especially gratifying.</p>

<p>Since 2007 we have worked with blind and visually impaired students and their teachers to
develop audemes and audeme games. The results have been very encouraging. Students who
hear audemes presented with educational materials score significantly better in tests of those
materials than students who did not hear the audemes. And when students play audeme riddle
games based on chapters from standard science textbooks, they score significantly better in
end-of-chapter tests than in tests for chapters learned without audeme games. After a year of
audeme game play, students expressed significantly more positive subjective attitudes about
science and science learning. These results have helped our work generate grant funding from
the Nina Mason Pulliam Charitable Trust, Google Research Awards and the National Science
Foundation.</p>

<p>This website offers a basic introduction to the whole idea of audemes and audeme games. We
believe we have just begun to explore the possibilities of audemes, audeme games and other
applications yet to be developed. We welcome your comments, questions and ideas.</p>
                
                </div> <!-- end of content left -->
                
                <div id="bottom_bg"></div>
            </div> <!-- end of content -->
            
            <!--#Include virtual="~\includes\footer.html"--> 
        </div> <!-- end of container -->
        
        <script type="text/javascript">
            $("a:contains('Home')").addClass('current'); //Makes the proper top nav item selected
        </script>
    </body>
</html>