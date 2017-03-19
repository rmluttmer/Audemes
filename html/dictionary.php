<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8"/>
    <meta http-equiv="x-ua-compatible" content="ie=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1"/>
    <title>Audeme - Dictionary</title>

    <?php include_once 'includes/universalCSS.php' ?>
    <link href="css/dictionary.css" rel="stylesheet">

</head>
<body>

<?php include_once 'includes/navigation.php' ?>

<h1 class="text-center" >Search Audemes</h1>
<div class="row center-block" id="advance">
    <div class="col-md-3"></div>
    <form method="post">
        <div class="col-md-2 form-group">
            <label for="category">Category:</label>
            <select class="form-control" id="category" name="catname">
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
        <div class="col-md-2 form-group">
            <label for="search">Word or phrase: </label>
            <input class="form-control" id="search" name="search" type="text"/>
        </div>

        <div class="col-md-2">
            <label>Search:</label> <br>
            <input class="btn" id="submit" type="submit" value="Go">
        </div>
    </form>
    <div class="col-md-3"></div>
</div>
<br>
<?php
    require 'search/objects/Dictionary.php';

    $dictionary = new Dictionary();

    if (isset($_POST['catname'])) {
        //var_dump($_POST);
        $dictionary->showSearch($_POST['catname'], $_POST['search']);
    }
?>
</body>
</html>