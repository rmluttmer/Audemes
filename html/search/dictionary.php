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
                <option value="APPLIED SCIENCE">Applied Science</option>
                <option value="ASTRONOMY">Astronomy</option>
                <option value="BIOLOGY">Biology</option>
                <option value="EARTH SCIENCE">Earth Science</option>
                <option value="ENERGY">Energy</option>
                <option value="GENERAL">General</option>
                <option value="GEOLOGY">Geology</option>
                <option value="IDIOMS">Idioms</option>
                <option value="PHYSICS.">Physics</option>
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
    // name, category, keywords, description (table columns)
    if ($catname == 'All') {
        if ($string == "") {
            $sql = "SELECT * FROM dictionary";
        } else {
            $sql = "SELECT * FROM dictionary WHERE name LIKE '" . $string .
                "%' OR keywords LIKE '" . $string . "%' OR description LIKE '" . $string . "%'";
        }
    } else {
        if ($string == "") {
            $sql = "SELECT * FROM dictionary WHERE category = '" . $catname . "'";
        } else {
            $sql = "SELECT * FROM dictionary WHERE (category = '" . $catname . "') AND (name LIKE '" . $string .
                "%' OR keywords LIKE '" . $string . "%' OR description LIKE '" . $string . "%')";
        }

    }

    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
        // output data of each row
        while ($row = $result->fetch_assoc()) {
            $name = $row["name"];
            $name = trim($name);
            $description = $row["description"];
            $keywords = $row["keywords"];
            $category = $row["category"];
            echo '<div class="row">';

            echo '<div class="col-md-3">';
            echo '<audio id="' . $name . '" src="http://audemes.aphtech.org/audio/' . strtolower($name) . '.mp3" preload="auto"></audio>';
            echo '<button type="submit" onclick="document.getElementById(\'' . $name . '\').play();">' . $name . '</button>';
            echo '</div>';

            echo '<div class="col-md-3">';
            echo '<p tabindex="0">';
            echo '<strong> Category: </strong>';
            echo $category;
            echo '</p>';
            echo '</div>';

            echo '<div class="col-md-3">';
            echo '<p tabindex="0">';
            echo '<strong>Description: </strong>';
            echo $description;
            echo '</p>';
            echo '</div>';

            echo '<div class="col-md-3">';
            echo '<p tabindex="0">';
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
    //var_dump($_POST);
    showSearch($_POST['catname'], $_POST['search']);
}
?>
</body>
</html>