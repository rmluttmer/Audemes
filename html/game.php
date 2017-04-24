<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <?php include_once 'includes/universalCSS.php' ?>
    <script type="text/javascript">
        (window).onload = (function () {
            if (document.getElementById("start") != null) {
                document.getElementById("start").focus();
            }
        });
    </script>
</head>


<body id="body">


<?php include_once 'includes/navigation.php' ?>

<?php

echo '<h1 tabindex="0"> Atomic Guessing Game </h1>';
echo '<p tabindex="0"> Listen to the three atomic Audemes on the left and guess the concept they represent from the choices on the right </p>';

session_start();

function checkAnswer($answer)
{
    if ($answer == 1) {
        $correct = "../audio/4D FUN.mp3";
        echo '<audio autoplay src="' . $correct . '" preload="auto"></audio>';
        unset($_SESSION['hint']);
        unset($_SESSION['repeatrow']);
    } else {
        $incorrect = "../audio/wrong answer oops.mp3";
        echo '<audio autoplay src="' . $incorrect . '" preload="auto"></audio>';
        $_SESSION['hint'] = true;
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
        if (isset($_SESSION['hint'])) {
            $hint = true;
        }
        else {
            $hint = false;
        }
        if (isset($_SESSION['repeatrow'])){
            $row = $_SESSION['repeatrow'];
        }
        else {
            $row = $array[0];
            $_SESSION['repeatrow'] = $array[0];
        }
        $wrong1 = $array[1]["name"];
        $wrong2 = $array[2]["name"];
        $name = $row["name"];
        $atomics = $row["atomic"];
        $hinttext = $row["hint"];
        $atomicarray = explode(" ", $atomics);
        $answerarray = array($name);
        array_push($answerarray, $wrong1);
        array_push($answerarray, $wrong2);
        echo '<div class="row">';
        echo '<div class="col-md-6" id=left>';
        if (!$hint) {
            echo '<h3 tabindex="0" id="start"> Atomic Audemes </h3>';
        } else {
            echo '<h3 tabindex="0"> Atomic Audemes </h3>';
        }
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
        if ($hint) {
            echo '<p tabindex="0" id="start"> Hint: ' . $hinttext . '</p>';
        }
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
    unset($_SESSION['hint']);
    unset($_SESSION['repeatrow']);
    getGame();
}

if (isset($_POST['answer'])) {
    //var_dump($_POST);
    checkAnswer($_POST['answer']);
    getGame();
}

?>
