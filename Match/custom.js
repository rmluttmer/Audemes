// JavaScript Document
var riddles = [
    {
        mp3: "mp3/AIR.mp3",
        answer: "Abrasion",
        mp3Answer: "mp3/a_abrasion.mp3"
},
    {
        mp3: "mp3/BALL.mp3",
        answer: "Agriculture Farming",
        mp3Answer: "mp3/a_agriculture_farming.mp3"
},
    {
        mp3: "mp3/BEE.mp3",
        answer: "Air Pressure",
        mp3Answer: "mp3/a_air_pressure.mp3",
},
    {
        mp3: "mp3/BIRD.mp3",
        answer: "Allergy",
        mp3Answer: "mp3/a_allergy.mp3"
},
    {
        mp3: "mp3/BOIL.mp3",
        answer: "Amphibian",
        mp3Answer: "mp3/a_amphibian.mp3",
},
    {
        mp3: "mp3/CASH.mp3",
        answer: "Aquaculture",
        mp3Answer: "mp3/a_aquaculture.mp3"
},
    {
        mp3: "mp3/CRASH.mp3",
        answer: "Atom",
        mp3Answer: "mp3/a_atom.mp3",
},
    {
        mp3: "mp3/DOG.mp3",
        answer: "Biodiversity",
        mp3Answer: "mp3/a_biodiversity.mp3"
},
    {
        mp3: "mp3/EAT.mp3",
        answer: "Biomass",
        mp3Answer: "mp3/a_biomass.mp3",
},
    {
        mp3: "mp3/GUN.mp3",
        answer: "Biome",
        mp3Answer: "mp3/a_biome.mp3"
},
    {
        mp3: "mp3/HORSE.mp3",
        answer: "Bird",
        mp3Answer: "mp3/a_bird.mp3",
},
    {
        mp3: "mp3/JET.mp3",
        answer: "Blizzard",
        mp3Answer: "mp3/a_blizzard.mp3"
},
    {
        mp3: "mp3/RUN.mp3",
        answer: "Cell",
        mp3Answer: "mp3/a_cell.mp3",
},
    {
        mp3: "mp3/AIR.mp3",
        answer: "Abrasion",
        mp3Answer: "mp3/a_abrasion.mp3"
},
    {
        mp3: "mp3/BALL.mp3",
        answer: "Agriculture Farming",
        mp3Answer: "mp3/a_agriculture_farming.mp3"
},
    {
        mp3: "mp3/BEE.mp3",
        answer: "Air Pressure",
        mp3Answer: "mp3/a_air_pressure.mp3",
},
    {
        mp3: "mp3/BIRD.mp3",
        answer: "Allergy",
        mp3Answer: "mp3/a_allergy.mp3"
},
    {
        mp3: "mp3/BOIL.mp3",
        answer: "Amphibian",
        mp3Answer: "mp3/a_amphibian.mp3",
},
    {
        mp3: "mp3/CASH.mp3",
        answer: "Aquaculture",
        mp3Answer: "mp3/a_aquaculture.mp3"
},
    {
        mp3: "mp3/CRASH.mp3",
        answer: "Atom",
        mp3Answer: "mp3/a_atom.mp3",
},
    {
        mp3: "mp3/DOG.mp3",
        answer: "Biodiversity",
        mp3Answer: "mp3/a_biodiversity.mp3"
},
    {
        mp3: "mp3/EAT.mp3",
        answer: "Biomass",
        mp3Answer: "mp3/a_biomass.mp3",
},
    {
        mp3: "mp3/GUN.mp3",
        answer: "Biome",
        mp3Answer: "mp3/a_biome.mp3"
},
    {
        mp3: "mp3/HORSE.mp3",
        answer: "Bird",
        mp3Answer: "mp3/a_bird.mp3",
},
    {
        mp3: "mp3/JET.mp3",
        answer: "Blizzard",
        mp3Answer: "mp3/a_blizzard.mp3"
},
    {
        mp3: "mp3/RUN.mp3",
        answer: "Cell",
        mp3Answer: "mp3/a_cell.mp3",
}
]

var hint = [
    {
        mp3: "hint/cheer.mp3"
    },
    {
        mp3: "hint/oops.mp3"
    },
    {
        mp3: "hint/alarm.mp3"
    }
]
var words = $('.cell');
var audioArray = [];
for (var i = 0; i < riddles.length; i++) {
    words.eq(i).attr('id', 'word-' + i);
    var audio = new Audio();
    audio.src = riddles[i].mp3;
    audioArray.push(audio);
}

var hintAudios = [];
for (var i = 0; i < hint.length; i++) {
    var audio = new Audio();
    audio.src = hint[i].mp3;
    hintAudios.push(audio);
}
//player

var playedGrid;

var flag = 0;
var formerPlayedGrid;

var current_point = parseInt($('#point').text());

$('.cell').on('click', function () {
    check(this);

})

var playing = false;




function check(buttonItem) {
	if (!$(buttonItem).attr('disabled')) {
		if(!playing){
			if(flag == 0){
			var p = $(buttonItem).attr('id').substr(5, 2);
            playedGrid = parseInt(p);
			p = parseInt(p);
            audioArray[p].play();
			playing = true;
            playingAnimation($('#word-' + p).children(), audioArray[p]);
			flag =1;
			formerPlayedGrid = playedGrid;
			audioArray[playedGrid].addEventListener('ended', function() {
   				playing = false;
				
			});
			}
			else{
			var p = $(buttonItem).attr('id').substr(5, 2);
			playedGrid = parseInt(p);
			p = parseInt(p);
            audioArray[p].play();
			playing=true;
			audioArray[playedGrid].addEventListener('ended', function() {
   				playing = false;
				flag = 0;
			});
            playingAnimation($('#word-' + p).children(), audioArray[p]);
			
			if( (formerPlayedGrid == playedGrid - 13) ||  (playedGrid == formerPlayedGrid - 13)){

                    audioArray[p].addEventListener('ended', function () {
                        $('#word-' + formerPlayedGrid).attr('disabled', '').removeClass("btn-warning").addClass("btn-success");

                        $('#word-' + playedGrid).attr('disabled', '').removeClass("btn-warning").addClass("btn-success");
                        
						
               
                        hintAudios[0].play();
                    });
                } 
			else {
                    audioArray[p].addEventListener('ended', function () {
                        $("#wrong").fadeIn().delay(1000).fadeOut();
                        hintAudios[1].play();
                    })	
				}
				
			
			}
			
			}
		else{
			return;}
		}
	else{
		hintAudios[2].play();
		}
	}









//timer
var counting = 0;
var progressTimer = function () {
    $('.timer').children('.alert').addClass("timer-glow");
    var timer;
    timer = 0;
    counting = 1;
    var progress = setInterval(function () {
        if (timer < 30 && counting == 1) {
            timer = timer + 1;
            $('#timer').text(30 - timer);
        } else {
            clearInterval(progress);
            counting = 0;
        }

    }, 1000);
}

var progressTimerClear = function () {
    counting = 0;
    $('#timer').text(30);
    $('.timer').children('.alert').removeClass("timer-glow");
}

function playingAnimation(span, audioItem) {
    span.removeClass("glyphicon-play").addClass("glyphicon-volume-up");

    var spanClass = setInterval(function () {
        if (span.hasClass("glyphicon-volume-up")) {
            span.removeClass("glyphicon-volume-up").addClass("glyphicon-volume-down");
        } else {
            span.removeClass("glyphicon-volume-down").addClass("glyphicon-volume-up");
        }

        audioItem.addEventListener('ended', function () {
            clearInterval(spanClass);

            span.removeClass("glyphicon-volume-down").removeClass("glyphicon-volume-up").addClass("glyphicon-play");
        })

    }, 500);
}

bindKeyboard();

function bindKeyboard() {

    jQuery(document).bind('keydown', 'q', function (evt) {
        check($("#word-0"));
        return false;
    });
    jQuery(document).bind('keydown', 'w', function (evt) {

        check($("#word-1"));
        return false;
    });
    jQuery(document).bind('keydown', 'e', function (evt) {

        check($("#word-2"));
        return false;
    });
    jQuery(document).bind('keydown', 'r', function (evt) {

        check($("#word-3"));
        return false;
    });
    jQuery(document).bind('keydown', 't', function (evt) {

        check($("#word-4"));
        return false;
    });
    jQuery(document).bind('keydown', 'y', function (evt) {

        check($("#word-5"));
        return false;
    });
    jQuery(document).bind('keydown', 'u', function (evt) {

        check($("#word-6"));
        return false;
    });
    jQuery(document).bind('keydown', 'i', function (evt) {

        check($("#word-7"));
        return false;
    });
    jQuery(document).bind('keydown', 'o', function (evt) {

        check($("#word-8"));
        return false;
    });
    jQuery(document).bind('keydown', 'p', function (evt) {

        check($("#word-9"));
        return false;
    });
    jQuery(document).bind('keydown', 'a', function (evt) {

        check($("#word-10"));
        return false;
    });
    jQuery(document).bind('keydown', 's', function (evt) {

        check($("#word-11"));
        return false;
    });
    jQuery(document).bind('keydown', 'd', function (evt) {

        check($("#word-12"));
        return false;
    });
    jQuery(document).bind('keydown', 'f', function (evt) {

        check($("#word-13"));
        return false;
    });
    jQuery(document).bind('keydown', 'g', function (evt) {

        check($("#word-14"));
        return false;
    });
    jQuery(document).bind('keydown', 'h', function (evt) {

        check($("#word-15"));
        return false;
    });
    jQuery(document).bind('keydown', 'j', function (evt) {

        check($("#word-16"));
        return false;
    });
    jQuery(document).bind('keydown', 'k', function (evt) {

        check($("#word-17"));
        return false;
    });
    jQuery(document).bind('keydown', 'l', function (evt) {

        check($("#word-18"));
        return false;
    });
    jQuery(document).bind('keydown', 'z', function (evt) {

        check($("#word-19"));
        return false;
    });
    jQuery(document).bind('keydown', 'x', function (evt) {

        check($("#word-20"));
        return false;
    });
    jQuery(document).bind('keydown', 'c', function (evt) {

        check($("#word-21"));
        return false;
    });
    jQuery(document).bind('keydown', 'v', function (evt) {

        check($("#word-22"));
        return false;
    });
    jQuery(document).bind('keydown', 'b', function (evt) {

        check($("#word-23"));
        return false;
    });
    jQuery(document).bind('keydown', 'n', function (evt) {

        check($("#word-24"));
        return false;
    });
    jQuery(document).bind('keydown', 'm', function (evt) {

        check($("#word-25"));
        return false;
    });

}