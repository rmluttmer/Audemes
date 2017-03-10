<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Audeme Game</title>
    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/homeStyle.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="../css/playerStyles.css"/>
    <script type="text/javascript" >
        var choice;
        var array = ['machine 1', 'rising', 'air 1'];
        var answers = ['hot air balloon', 'airplane', 'tea kettle'];
        function checkAnswer(choice){
            if(choice.getAttribute('id') == 'airplane'){
                alert('Correct!')
            }
            else {
                alert('Sorry, try again!')
            }
        }

        function demo(){
            document.getElementById('gameStart').remove();
            var list = document.createElement('ol');
            var body = document.getElementById('left');
            list.setAttribute('class', 'row');
            list.setAttribute('id', 'advance');
            body.appendChild(list);
            for (var i = 0; i < 3; i++){
                var audeme = document.createElement('li');
                audeme.setAttribute('class', 'col-md-2');
                list.appendChild(audeme);
                var audio = document.createElement('audio');
                audio.setAttribute('preload', 'auto');
                audio.setAttribute('src', '../audio/'+array[i]+'.mp3');
                audio.setAttribute('id', array[i]);
                audeme.appendChild(audio);
                var button = document.createElement('button');
                button.setAttribute('onclick', 'document.getElementById("'+array[i]+'").play();');
                button.setAttribute('tabindex', '0');
                button.innerHTML = 'Play Sound';
                audeme.appendChild(button);
                var description = document.createElement('p');
                description.innerHTML = 'Description: '+array[i];
                description.setAttribute('tabindex', '0');
                audeme.appendChild(description);
            }
            var listright = document.createElement('ol');
            var right = document.getElementById('right');
            var answerheading = document.createElement('h1');
            answerheading.innerHTML = 'Answers';
            right.appendChild(answerheading);
            listright.setAttribute('class', 'row');
            listright.setAttribute('id', 'advance');
            right.appendChild(listright);
            for (i = 0; i < 3; i++){
                var answer = document.createElement('li');
                answer.setAttribute('class', 'col-md-2');
                listright.appendChild(answer);
                var descriptionAnswer = document.createElement('p');
                descriptionAnswer.innerHTML = 'Description: '+answers[i];
                descriptionAnswer.setAttribute('tabindex', '0');
                answer.appendChild(descriptionAnswer);
                var buttonAnswer = document.createElement('button');
                buttonAnswer.setAttribute('id', answers[i]);
                buttonAnswer.setAttribute('onclick', 'checkAnswer('+buttonAnswer.getAttribute('id')+');');
                buttonAnswer.setAttribute('tabindex', '0');
                buttonAnswer.innerHTML = 'Choose';
                answer.appendChild(buttonAnswer);
            }
        }
    </script>

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
            <li role="presentation" id="dictionary"><a role="tab" tabindex="0" href="../search/dictionary.php">Dictionary</a></li>
            <li role="presentation" id="game"><a role="tab" tabindex="0" href="#" >Games</a></li>
            <li role="presentation" id="about"><a role="tab" tabindex="0" href="../about.html">About</a></li>
        </ul>
    </div>
</nav>
<?php
include '/home/phpcredentials/access.php';

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

$sql = "SELECT name FROM gridgame";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        //echo "name: " . $row["name"]. "<br>";
    }
} else {
    echo "0 results";
}
$conn->close();
?>
<div class="row">
    <div class="col-sm-6 text-left" id="left">
        <h1 class="audemeTitle" tabindex="0">Atomic Guessing Game</h1>
        <p tabindex="0">Listen to the three atomic audemes and guess the concept they represent from the choices on the right</p>
        <button onclick="demo()" class="customButton center" id="gameStart" tabindex="0">GAME START</button>
    </div>
    <div class="col-sm-6 text-left" id="right">

    </div>
</div>
