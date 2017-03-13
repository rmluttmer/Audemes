<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Audeme Game</title>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/homeStyle.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="../css/playerStyles.css"/>

</head>


<body id="body">

<nav class="navbar navbar-default" role="navigation">
    <div class="container-fluid text-center">
        <div class="navbar-header">
            <a class="navbar-brand logo" href="#">
                <img id="logoimage" alt="logo" src="../images/Audeme-Logo-small3.png">
            </a>
        </div>
        <ul class="nav navbar-nav tabs" role="tablist">
            <li role="presentation" id="home"><a role="tab" tabindex="0" href="../index.html">Home</a></li>
            <li role="presentation" id="dictionary"><a role="tab" tabindex="0" href="../search/dictionary.php">Dictionary</a>
            </li>
            <li role="presentation" id="game"><a role="tab" tabindex="0" href="#">Games</a></li>
            <li role="presentation" id="about"><a role="tab" tabindex="0" href="../about.html">About</a></li>
        </ul>
    </div>
</nav>
<?php

echo '<h1 tabindex="0"> Atomic Guessing Game </h1>';
echo '<p tabindex="0"> Listen to the three atomic Audemes on the left and guess the concept they represent from the choices on the right </p>';

function checkAnswer($answer){
    if ($answer == 1){
        $correct = "../audio/RIGHT ANSWER CHEER.mp3";
        echo '<audio autoplay src="' . $correct . '" preload="auto"></audio>';
    }
    else {
        $incorrect = "../audio/WRONG ANSWER oops.mp3";
        echo '<audio autoplay src="' . $incorrect . '" preload="auto"></audio>';
    }

}


function getGame()
{
    include '/home/phpcredentials/access.php';
// Create connection
    $conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
//atomic, name, hint
    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    }

    $sql = "SELECT * FROM gridgame";
    $result = $conn->query($sql);


    if ($result->num_rows > 0) {
        // output data of each row
        for ($i = 0; $array[$i] = $result->fetch_assoc(); $i++) ;
        shuffle($array);
        $row = $array[0];
        $wrong1 = $array[1]["name"];
        $wrong2 = $array[2]["name"];
        $name = $row["name"];
        $atomics = $row["atomic"];
        $hint = $row["hint"];
        $atomicarray = explode(" ", $atomics);
        $answerarray = array($name);
        array_push($answerarray, $wrong1);
        array_push($answerarray, $wrong2);
        echo '<div class="row">';
        echo '<div class="col-md-6" id=left>';
        echo '<h3 tabindex="0"> Atomic Audemes </h3>';
        foreach ($atomicarray as $atomic) {
            $atomic = trim($atomic);
            if (empty($atomic)) {
                continue;
            }
            echo '<div class="col-md-2">';
            echo '<audio id="' . strtolower($atomic) . '" src="http://audemes.aphtech.org/audio/' . strtolower($atomic) . '.mp3" preload="auto"></audio>';
            echo '<button type="submit" onclick="document.getElementById(\'' . strtolower($atomic) . '\').play();">' . $atomic . '</button>';
            echo '</div>';
        }
        echo '<div class="col-md-2">';
        echo '<p tabindex="0"> Hint: ' . $hint . '</p>';
        echo '</div>';
        echo '</div>';
        echo '<div class="col-md-6 text-left" id=right>';
        echo '<h3 tabindex="0"> Answer choices </h3>';
        shuffle($answerarray);
        foreach ($answerarray as $answer) {
            echo '<div class="col-md-2">';
            echo '<form method="post">';
            echo '<button type="submit" name="answer" value="' . ($answer == $name) . '">' . $answer . '</button>';
            echo '</form>';
            echo '</div>';
        }
        echo '</div>';
        echo '</div>';

        echo '</div>';
    } else {
        echo "Connection problems with the game server.";
    }
    $conn->close();
}
echo '<div class="row">';
echo '<form method="post">';
echo '<div class="col-md-6" >';
echo '<button type="submit" name="next"> Next </button>';
echo '</div>';
echo '</form>';
echo '</div>';
if (isset($_POST['next'])) {
    //var_dump($_POST);
    getGame();
}

if (isset($_POST['answer'])) {
    //var_dump($_POST);
    checkAnswer($_POST['answer']);
    getGame();
}

?>
