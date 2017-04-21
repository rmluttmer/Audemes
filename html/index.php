<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>APH Tech Audemes</title>
    <?php include_once 'includes/universalCSS.php' ?>

</head>


<body>

<?php include_once 'includes/navigation.php' ?>

<div class="container-fluid text-center">
    <div class="row">
        <div class="col-sm-6 text-left">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="text-center" tabindex="0">What is an Audeme?</h3>
                </div>
                <div class="panel-body" tabindex="0">
                    <p>Pronounced "awe deems," they are brief audio illustrations that combine sound effects,
                        sometimes with music, to form aural symbols that signify various ideas, things, actions
                        and situations. For example, an Audeme combining the sound of a cat's meow and a person
                        snoring could mean "Cat Nap". <br> <br> Since 2007 Professor Mannheimer of Indiana University
                        Purdue University Indianapolis has worked with blind and visually
                        impaired students
                        and their teachers to develop audemes and audeme games. The results have been very encouraging.
                        Students who hear audemes presented with educational materials score significantly better in
                        tests
                        of those materials than students who did not hear the audemes. And when students play audeme
                        riddle
                        games based on chapters from standard science textbooks, they score significantly better in
                        end-of-chapter
                        tests than in tests for chapters learned without audeme games. After a year of audeme game play,
                        students
                        expressed significantly more positive subjective attitudes about science and science learning.
                        These results
                        have helped Professor Mannheimer's work generate grant funding from the Nina Mason Pulliam
                        Charitable Trust, Google
                        Research Awards
                        and the National Science Foundation. In 2016, Professor Mannheimer partnered with the American
                        Printing House for the Blind and students from Indiana University Southeast to continue work on
                        the project. <br> <br> This website offers a basic introduction to the
                        whole idea of audemes and
                        audeme games. We believe we have just begun to explore the possibilities of audemes, audeme
                        games and other
                        applications yet to be developed. We welcome- your comments, questions and ideas.</p>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="text-center" tabindex="0">Try it now!</h3>
                </div>
                <div class="panel-body">
                    <div class="track-info-container">
                        <audio id="endofroad" src="audio/end of the road.mp3" preload="auto"></audio>
                        <button tabindex="0" onclick="document.getElementById('endofroad').play();">Play
                            Sound
                        </button>
                        <p tabindex="0">Description: End of the Road</p>
                    </div>
                    <img class="img-responsive" src="images/listeningnew.png">
                </div>
            </div>
        </div>
    </div>
</div>
</body>

</html>