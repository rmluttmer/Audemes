function playGame() {
    window.location.href = "/games/quizgame.aspx?AudemeGridID=1";
}

function sequenceDashboardPlay(mp3Name, description, soundID) {
    if ($('#sequenceInput').attr("value") == "") {
        $('#sequenceInput').attr("value", description);
        $('#sequenceSoundIDs').attr("value", soundID);
    } else {
        $('#sequenceInput').attr("value", $('#sequenceInput').attr("value") + ", " + description);
        $('#sequenceSoundIDs').attr("value", $('#sequenceSoundIDs').attr("value") + ", " + soundID);
    }
    trainingPlay(mp3Name, description);
}

function sequencePlay(mp3Name, description, cellIndex) {
    var firstWord = description.split(",", 1);
    if ($('#sequenceInput').attr("value") == "") {
        $('#sequenceInput').attr("value", cellIndex + " - " + firstWord);
        $('#sequenceSoundIDs').attr("value", arrayCellToSoundID[cellIndex]);
    } else {
        $('#sequenceInput').attr("value", $('#sequenceInput').attr("value") + ", " + cellIndex + " - " + firstWord);
        $('#sequenceSoundIDs').attr("value", $('#sequenceSoundIDs').attr("value") + ", " + arrayCellToSoundID[cellIndex]);
    }
    trainingPlay(mp3Name, description);
}

function trainingPlay(mp3Name, description, event) {
    if (!event) { event = window.event; }
    if (event.target.className != "clicked") {
        var descriptionObject = document.getElementById("description");
        var mp3FileName = "/mp3s/audemes/" + mp3Name + ".mp3";

        event.target.innerHTML += ('<audio controls="controls" autoplay="autoplay" id="playListAudioTag" style="display: none;"><source src="' + mp3FileName + '" type="audio/mpeg" />Your browser does not support the audio element.</audio>');
        descriptionObject.innerHTML = description;
    }
}

function trainingPlay_ChangeColor(mp3Name, description, event) {
    if (!event) { event = window.event; }
    if (event.target.className != "clicked") {
        var descriptionObject = document.getElementById("description");
        var mp3FileName = "/mp3s/audemes/" + mp3Name + ".mp3";

        event.target.className += "clicked";
        event.target.innerHTML += ('<audio controls="controls" autoplay="autoplay" id="playListAudioTag" style="display: none;"><source src="' + mp3FileName + '" type="audio/mpeg" />Your browser does not support the audio element.</audio>');
        descriptionObject.innerHTML = description;
    }
}

function resetSequence(tableID) {
    //Resets the form (except the Submit button)
    $("#sequenceCreation :input:not(:last-child)").attr("value", "");
        
    //Resets the links in the Dashboard
    $("#sequenceDashboard li").attr("class", "clickable");
    $("#sequenceDashboard li audio").remove();

    //Makes the circles clickable again
    resetRSS(tableID); 
}

function resetRSS( tableID ) {
    //Makes the circles in the specified sound grid clickable again
    var resetTable = document.getElementById(tableID);
    var currentCell;

    document.getElementById("description").innerHTML = "(Nothing Selected)";
    
    for (row = 0; row < resetTable.rows.length; row++) {
        for (cell = 0; cell < resetTable.rows[row].cells.length; cell++) {
            currentCell = resetTable.rows[row].cells[cell];
            currentCell.className = "ready";

            if (currentCell.childNodes.length > 1) {
                currentCell.removeChild(currentCell.childNodes[1]);
            }
        }
    }
}