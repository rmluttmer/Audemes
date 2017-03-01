<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8"/>
    <meta http-equiv="x-ua-compatible" content="ie=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1"/>
    <title>Audeme - Dictionary</title>

    <!-- Bootstrap -->
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/homeStyle.css" rel="stylesheet">
    <link href="../css/dicStyle.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="../css/playerStyles.css"/>
    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript" src="../js/amplitude.js"></script>
    <script type="text/javascript" src="app.js"></script>

    <style>
        .paginate > li {
            float: left;
            display: block;
            margin: 10px;
        }
    </style>
</head>
<body>
<nav class="navbar navbar-default" role="navigation">
    <div class="container-fluid text-center">
        <div class="navbar-header">
            <a class="navbar-brand logo" href="#">
                <img id="logoimage" alt="logo" src="../images/Audeme-Logo-small3.png">
            </a>
        </div>
        <ul class="nav navbar-nav tabs" role="tablist">
            <li role="presentation" id="home"><a role="tab" tabindex="0" href="../index.html">Home</a></li>
            <li role="presentation" id="dictionary"><a role="tab" tabindex="0" href="#">Dictionary</a></li>
            <li role="presentation" id="game"><a role="tab" tabindex="0" href="../game/game.php">Games</a></li>
            <li role="presentation" id="about"><a role="tab" tabindex="0" href="../about.html">About</a></li>
        </ul>
    </div>
</nav>

<div class="container-fluid search-area show-results" tabitem="0">
    <div class="row" id="advance">
        <div class="col-md-2 col-md-offset-1">
            <p>Category: </p>
            <select id="category">
                <option value="0">All</option>
                <option value="1">Applied Science</option>
                <option value="2">Astronomy</option>
                <option value="3">Biology</option>
                <option value="4">Earth Science</option>
                <option value="5">Energy</option>
                <option value="6">General</option>
                <option value="7">Geology</option>
                <option value="8">Idioms</option>
                <option value="9">Physics</option>
            </select>
        </div>
        <div class="col-md-2">
            <p>Difficulty: </p>
            <select id="difficulty">
                <option value="0">All</option>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
            </select>
        </div>
        <div class="col-md-2">
            <p>Show atomics only: </p>
            <form id="atomic">
                <input type="radio" name="atomic" value="1">Yes</input><span> </span>
                <input type="radio" name="atomic" value="0" checked>No</input>
            </form>
        </div>
        <div class="col-md-2">
            <p>Word or phrase: </p>
            <div class="search-wrapper">
                <input id="search" type="text"/>
            </div>
        </div>

        <div class="col-md-2">
            <input id="submit" type="submit" value="Search" onclick=search()>
        </div>
    </div>
</div>
<?php
$allfiles = scandir('../audio/');
$files = array_diff($allfiles, array('.', '..'));
echo '<ul>';
foreach($files as $file) {

    echo '<li>';
    $filename = explode("." , $file);
    $fileonly = $filename[0];
    echo '<audio id="' . $fileonly . '" src="http://audemes.aphtech.org/audio/' . $file . '" preload="auto"></audio>' ;
    echo '<button type="submit" onclick="document.getElementById(\''. $fileonly .'\').play();">' . $file . '</button>';
    echo '</li>';
    echo '<br>';
}
echo '</ul>';
?>
<!--
<div class="resultpanel border">
<h4>Air (ver. 1)</h4>
<h5>Description</h5>
<p>The invisible gaseous substance surrounding the earth, a mixture mainly of oxygen and nitrogen.	</p>
<h5>Category</h5>
<p></p>
<h5>Tags</h5>
<ul>
	<li></li>
	<li></li>
	<li></li>
</ul>
<audio controls>
	<source src="../AudemeOGGs/air 1.ogg" type="audio/ogg">
	<source src="../AudemeMP3s/air 1.mp3" type="audio/mpeg">
</audio>
</div>
<h4 id="results-text">Showing results for: <strong id="search-string"></strong></h4>-->
<div class="content-fluid">
    <div class="row">
        <div class="col-md-6 col-md-offset-3" id="results">

        </div>
    </div>
</div>

<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="../js_2014/jquery-1.11.2.min.js"></script>
<!-- Include all compiled plugins (below), or include individual files as needed -->
<script src="../js/bootstrap.min.js"></script>
<script src="app.js"></script>
</body>
</html>