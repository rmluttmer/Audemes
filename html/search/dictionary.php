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
    <link rel="stylesheet" type="text/css" href="../css/playerStyles.css"/>

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
<h1>Search Audemes</h1>
<div class="row" id="advance">
    <form method="post">
        <div class="col-md-4">
            <p>Category: </p>
            <select id="category" name="catname">
                <option value="All">All</option>
                <option value="Applied Science">Applied Science</option>
                <option value="Astronomy">Astronomy</option>
                <option value="BIOLOGY">Biology</option>
                <option value="4">Earth Science</option>
                <option value="5">Energy</option>
                <option value="6">General</option>
                <option value="7">Geology</option>
                <option value="8">Idioms</option>
                <option value="9">Physics</option>
            </select>
        </div>
        <div class="col-md-4">
            <p>Word or phrase: </p>
            <div class="search-wrapper">
                <input id="search" name="search" type="text"/>
            </div>
        </div>

        <div class="col-md-4">
            <p>Search:</p>
                       <input id="submit" type="submit" value="Go">
        </div>
    </form>
</div>
<br>
<?php

function showSearch($catname, $string)
{
    include '/home/phpcredentials/access.php';
// Create connection
    $conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
    if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
    }
    $selectedCategory = $_POST['category'];
    $sql;
    if ($catname == 'All') {
        if ($string == ""){
            $sql = "SELECT * FROM dictionary";
        }
        else{
            $sql = "SELECT * FROM dictionary WHERE ";
        }
    } else {
        if ($string == ""){
            $sql = "SELECT * FROM dictionary WHERE category = '" . $catname . "'";
        }
        else {
            $sql = "SELECT * FROM dictionary WHERE category = '" . $catname . "'";
        }

    }

    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        // output data of each row
        while ($row = $result->fetch_assoc()) {
            $name = $row["name"];
            $description = $row["description"];
            $keywords = $row["keywords"];
            $category = $row["category"];
            echo '<div class="row">';

            echo '<div class="col-md-3">';
            echo '<audio id="' . $name . '" src="http://audemes.aphtech.org/audio/' . strtolower($name) . '.mp3" preload="auto"></audio>';
            echo '<button type="submit" onclick="document.getElementById(\'' . $name . '\').play();">' . $name . '</button>';
            echo '</div>';

            echo '<div class="col-md-3">';
            echo '<p>';
            echo '<strong> Category: </strong>';
            echo $category;
            echo '</p>';
            echo '</div>';

            echo '<div class="col-md-3">';
            echo '<p>';
            echo '<strong>Description: </strong>';
            echo $description;
            echo '</p>';
            echo '</div>';

            echo '<div class="col-md-3">';
            echo '<p>';
            echo '<strong>Keywords: </strong>';
            echo $keywords;
            echo '</p>';
            echo '</div>';

            echo '</div>';
        }
    } else {
        echo "0 results";
    }
    $conn->close();
}

if (isset($_POST['catname'])) {
    var_dump($_POST);
    showSearch($_POST['catname'], $_POST['search']);
}
?>
</body>
</html>