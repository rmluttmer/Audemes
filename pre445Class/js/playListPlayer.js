var waitingOnResponse = false;
var arrayTeams = new Array();
var numTeams = 0;
var selectedTeamID = "team0";
var clickedCellPoints = 0;

/*====================================
    Team Functions
====================================*/

function addPoints() {
    var curPoints = parseInt($('.quizTeam.selected .score').html());
    curPoints += parseInt(clickedCellPoints);
    $('.quizTeam.selected .score').html(curPoints);
}

function addTeam() {
    numTeams++;
    
    var teamHTML = "";
    teamHTML += '<div class="quizTeam" id="team' + numTeams + '" onclick="selectTeam(\'team' + numTeams + '\')">';
    teamHTML += '<p class="name">Team ' + numTeams + '</p>';
    teamHTML += '<p class="score">0</p>';
    teamHTML += '</div>';

    quizTeamsElement.innerHTML += teamHTML;

    selectTeam("team" + numTeams);
}

function initializeTeams() {
    document.write('<section id="quizTeams"><div id="teamList"></div><button id="addTeam" onclick="addTeam()">Add Team</button></section>');
    quizTeamsElement = document.getElementById('teamList');
    addTeam();
}

function selectTeam(teamID) {
    $('.quizTeam').removeClass('selected');
    selectedTeamID = teamID;
    var teamSelector = "#" + selectedTeamID;
    $(teamSelector).addClass('selected');
}

/*====================================
    Cell Functions
====================================*/

function playListPlay(mp3Name, keyword, audemeID, points){
    if (waitingOnResponse) {
        alert("You must finish the current question before proceeding.");
        return;
    } else {
        waitingOnResponse = true;
    }

    clickedCellPoints = points;
    var mp3FileName = "/mp3s/audemes/" + mp3Name + ".mp3";

    var cellHTML = '<audio controls="controls" autoplay="autoplay" id="playListAudioTag"><source src="' + mp3FileName + '" type="audio/mpeg" />Your browser does not support the audio element.</audio>';
    cellHTML += '<br /><button id="showAnswer">Show Answer</button>';
    $(event.target).html(cellHTML);
    $(event.target).css("cursor", "default");
    event.target.onclick = "";
    
    $("#showAnswer").click(function () {
        onShowAnswerClicked(keyword, audemeID);
    });
}

function onShowAnswerClicked(keyword, audemeID) {
    var feedbackText = "<p style='font-size: 16px'>" + keyword + "</p><p style='font-size: 10px; font-color: #ffffff'>Were you correct?</p>";
    feedbackText += "<button id='btnYes'>Yes!</button><button id='btnNo'>No.</button>";
    $(event.target).parent().html(feedbackText);
    $("#btnYes").click(function () {
        addPoints();
        onResponseClicked(1, audemeID);
    });
    $("#btnNo").click(function () {
        onResponseClicked(0, audemeID);
    });
}

function onResponseClicked(answeredCorrectly, audemeID) {
    waitingOnResponse = false;

    $(event.target).parent().html('');
    $.get("/formHandlers/audemeCorrect.aspx", { audemeID: audemeID, correct: answeredCorrectly });
}