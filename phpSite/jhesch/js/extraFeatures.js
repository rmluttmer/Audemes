// Mouseover/ Click sound effect- by JavaScript Kit (www.javascriptkit.com)
// Visit JavaScript Kit at http://www.javascriptkit.com/ for full source code

//** Usage: Instantiate script by calling: var uniquevar=createsoundbite("soundfile1", "fallbackfile2", "fallebacksound3", etc)
//** Call: uniquevar.playclip() to play sound

var html5_audiotypes={ //define list of audio file extensions and their associated audio types. Add to it if your specified audio file isn't on this list:
	"mp3": "audio/mpeg",
	"mp4": "audio/mp4",
	"ogg": "audio/ogg",
	"wav": "audio/wav"
}

function createsoundbite(sound, nextSound){
    var html5audio=document.createElement('audio')
	if (html5audio.canPlayType){ //check support for HTML5 audio
		for (var i=0; i<arguments.length; i++){
			var sourceel=document.createElement('source')
			sourceel.setAttribute('src', arguments[i])
			if (arguments[i].match(/\.(\w+)$/i))
				sourceel.setAttribute('type', html5_audiotypes[RegExp.$1])
			html5audio.appendChild(sourceel)
		}
		html5audio.load()
		html5audio.playclip=function(){
			    html5audio.pause()
			    html5audio.currentTime=0
			    html5audio.play()
        }
        if (typeof nextSound != "undefined") {
            //If this sound needs to chain, trigger the next sound when this one ends
            html5audio.addEventListener('ended', function () {
                document.getElementById('nextSound').play();
            });
        }

		return html5audio
	}
	else{
		return {playclip:function(){throw new Error("Your browser doesn't support HTML5 audio unfortunately")}}
	}
}

function createSoundChain(soundArray) {
    //Create a chain of sounds (for Sequences)
    var html5AudioChain = "";
    for (var i = 0; i < soundArray.length; i++) {
        //Check if this is the last sound in the chain
        if (i == soundArray.length - 1) {
            //The last sound does not trigger another
            html5_audiotypes += createsoundbite(soundArray[i]);
        } else {
            //Chain sounds
            html5_audiotypes += createsoundbite(soundArray[i], soundArray[i + 1]);
        }
    }
    return html5AudioChain;
}

//Form Error Handler Stuff 
function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regexS = "[\\?&]" + name + "=([^&#]*)";
    var regex = new RegExp(regexS);
    var results = regex.exec(window.location.search);
    if (results == null)
        return "";
    else
        return decodeURIComponent(results[1].replace(/\+/g, " "));
}

//Add some onClick handlers to various items
$(document).ready(function () {

    //Audeme Expand in a list (to show details)
    $('.showDetails').click(function () {
        $(this).parent().children(".details").toggleClass("visible");
        $(this).children(".expandIcon").toggleClass("collapse");
    });

    //Add to Dashboard
    $('.addToDashboard').click(function () {
        var audemeID = $(this).attr("id");
        $.get("/jhesch/formHandlers/addToDashboard.aspx", { audeme_id: audemeID });
        $(this).text("(In Dashboard)");
        $(this).unbind('click');
        $(this).toggleClass("clickable");
    });

    //Add to Dashboard
    $('.addGridToDashboard').click(function () {
        var audemeGridID = $(this).attr("id");
        $.get("/jhesch/formHandlers/addToDashboard_Grids.aspx", { audemeGrid_id: audemeGridID });
        $(this).text("(In Dashboard)");
        $(this).unbind('click');
        $(this).toggleClass("clickable");
    });

    //Change Text Size
    $('#changeTextSize').click(function () {
        $.post("/jhesch/formHandlers/changeTextSize.aspx", { fontSize: "0" });
    });

    //Create Sequence
    $('.createSequence').click(function () {
        $("#sequenceCreationWrapper").addClass("active");
    });

    //Prompt Authentication 
    $('.promptAuthentication').click(function () {
        window.location = "/jhesch/login.aspx";
    });

    //Remove From Dashboard
    $('.removeFromDashboard').click(function () {
        var audemeID = $(this).attr('id');
        $.get("/jhesch/formHandlers/removeFromDashboard.aspx", { audeme_id: audemeID });
        $(this).text("(Removed)");
        $(this).unbind('click');
        $(this).toggleClass("clickable");
    });

    //Remove From Dashboard
    $('.removeGridFromDashboard').click(function () {
        var audemeGridID = $(this).attr('id');
        $.get("/jhesch/formHandlers/removeFromDashboard_Grid.aspx", { audemeGrid_ID: audemeGridID });
        $(this).text("(Removed)");
        $(this).unbind('click');
        $(this).toggleClass("clickable");
    });

    //Submit Audeme Rating
    $('.submitAudemeRating').click(function () {
        var audeme = $(this).parent().parent().attr('name');

        //Determine which options are selected
        var component = $(this).parent().children().children('input[name="components"]:checked').val();
        var concept = $(this).parent().children().children('input[name="concept"]:checked').val();

        $.get("/jhesch/formHandlers/rateAudeme.aspx", { audemeVar: audeme, conceptVar: concept, componentVar: component });
    });

    //Increment number of times played
    $('.audeme').click(function () {
        var audeme = $(this).attr('audemeID');

        $.get("/jhesch/formHandlers/Audeme_RecordPlayed.aspx", { audeme_ID: audeme });
    });

    //Organize Audemes
    $('#dashboardAudemeList').sortable();
    $('#dashboardAudemeList').sortable("disable");

    $('#organizeAudemes').click(function () {

        $('#organizeAudemes').toggleClass("sort");

        if ($('#organizeAudemes').hasClass("sort")) {
            //Make the audeme list sortable
            $('#dashboardAudemeList').sortable("enable");
            $('#dashboardAudemeList').disableSelection();
            $('#organizeAudemes').text("Save Order");
            $('#dashboardAudemeList .details').removeClass('visible');
            $('#dashboardAudemeList .expandIcon').removeClass('collapse');
        } else {
            //Store the new order
            var listPOST = $('#dashboardAudemeList').sortable('toArray').toString();
            $.post("/jhesch/formHandlers/reorderAudemeList.aspx", { orderedList: listPOST });
            //window.location = window.location.pathname;

            //Disable sorting of the list
            $('#dashboardAudemeList').sortable("disable");
            $('#organizeAudemes').text("Organize Audemes");
        }

        //Change the styles of the list items
        $('#dashboardAudemeList').children().toggleClass("ui-state-default");
    });
});

