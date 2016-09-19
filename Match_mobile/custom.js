// JavaScript Document
var animalriddles = [
    {
        mp3: "mp3/bird.mp3",
        answer: "BIRD",
},
    {
        mp3: "mp3/cat.mp3",
        answer: "CAT",
},
    {
        mp3: "mp3/chicken.mp3",
        answer: "CHICKEN",
        
},
    {
        mp3: "mp3/dog.mp3",
        answer: "DOG",
},
    {
        mp3: "mp3/duck.mp3",
        answer: "DUCK",
},
    {
        mp3: "mp3/elephant.mp3",
        answer: "ELEPHANT",

},
    {
        mp3: "mp3/horse.mp3",
        answer: "HORSE",

},
    {
        mp3: "mp3/tiger.mp3",
        answer: "TIGER",

},
    {
        mp3: "mp3/wind.mp3",
        answer: "WIND",

},
    {
        mp3: "mp3/water.mp3",
        answer: "WATER",
},

{
        mp3: "mp3/a_bird.mp3",
        answer: "BIRD",
},
    {
        mp3: "mp3/a_cat.mp3",
        answer: "CAT",
},
    {
        mp3: "mp3/a_chicken.mp3",
        answer: "CHICKEN",
        
},
    {
        mp3: "mp3/a_dog.mp3",
        answer: "DOG",
},
    {
        mp3: "mp3/a_duck.mp3",
        answer: "DUCK",
},
    {
        mp3: "mp3/a_elephant.mp3",
        answer: "ELEPHANT",

},
    {
        mp3: "mp3/a_horse.mp3",
        answer: "HORSE",

},
    {
        mp3: "mp3/a_tiger.mp3",
        answer: "TIGER",

},
    {
        mp3: "mp3/a_wind.mp3",
        answer: "WIND",

},
    {
        mp3: "mp3/a_water.mp3",
        answer: "WATER",
}
]

var astronomyriddles = [
    {
        mp3: "mp3/venus.mp3",
        answer: "VENUS",
},
    {
        mp3: "mp3/comet.mp3",
        answer: "COMET",
},
    {
        mp3: "mp3/constellation.mp3",
        answer: "CONSTELLATION",
        
},
    {
        mp3: "mp3/galaxy.mp3",
        answer: "GALAXY",
},
    {
        mp3: "mp3/orbit.mp3",
        answer: "ORBIT",
},
    {
        mp3: "mp3/mercury.mp3",
        answer: "MERCURY",

},
    {
        mp3: "mp3/moon.mp3",
        answer: "MOON",

},
    {
        mp3: "mp3/star.mp3",
        answer: "STAR",

},
    {
        mp3: "mp3/mars.mp3",
        answer: "MARS",

},
    {
        mp3: "mp3/earth.mp3",
        answer: "EARTH",
},

{
        mp3: "mp3/a_comet.mp3",
        answer: "COMET",
},
    {
        mp3: "mp3/a_constellation.mp3",
        answer: "CONSTELLATION",
},
    {
        mp3: "mp3/a_orbit.mp3",
        answer: "ORBIT",
        
},
    {
        mp3: "mp3/a_earth.mp3",
        answer: "EARTH",
},
    {
        mp3: "mp3/a_moon.mp3",
        answer: "MOON",
},
    {
        mp3: "mp3/a_star.mp3",
        answer: "STAR",

},
    {
        mp3: "mp3/a_mars.mp3",
        answer: "MARS",

},
    {
        mp3: "mp3/a_galaxy.mp3",
        answer: "GALAXY",

},
    {
        mp3: "mp3/a_mercury.mp3",
        answer: "MERCURY",

},
    {
        mp3: "mp3/a_venus.mp3",
        answer: "VENUS",
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

var riddles = [];

var hash = window.location.hash;
if (hash)
{
	riddles = astronomyriddles;
	$('#selectedCategory').text('Astronomy');
	$('#extraCategory').text('Animal').attr('href','single.html');
	$('.gameArea').css('background-image','url(image/astronomy.jpg)');
	
	}
	else {
		
	riddles = animalriddles ;
	$('.gameArea').css('background-image','url(image/animals.jpg)');
	}

shuffle(riddles);

var words = $('.cell');
var audioArray = [];
for (var i = 0; i < riddles.length; i++) {
    words.eq(i).attr('id', 'word-' + i);
    var audio = new Audio();
    audio.src = riddles[i].mp3;
    audioArray.push(audio);
	
	words.eq(i).html("<span class='glyphicon glyphicon-play' aria-hidden='true' ></span>" + "<div class='hintText'>"+riddles[i].answer+"</div>");
}


//mode control
if($("input[name='mode']:checked").val() == "Student"){
		$('.hintText').css("opacity", 0);}
else{
	$('.hintText').css("opacity", 0.6);
	}
$("label[name='mode']").click(function(){
	if($("input[name='mode']:checked").val() == "Student"){
		$('.hintText').css("opacity", 0.6);}
else if($("input[name='mode']:checked").val() == "Teacher"){
	$('.hintText').css("opacity", 0);
	}
	})


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




function check(buttonItem){
	
		if(!playing){
			
			var p = $(buttonItem).attr('id').substr(5, 2);
			playedGrid = parseInt(p);
			p = parseInt(p);
            audioArray[p].play();
			playing=true;
			playingAnimation($('#word-' + p).children("span"), audioArray[p]);
			
			if(flag == 0){
            
			flag =1;
			formerPlayedGrid = playedGrid;
			audioArray[playedGrid].addEventListener('ended', function() {
   				playing = false;
				
			});
			}
			else{
			
			audioArray[playedGrid].addEventListener('ended', function() {
   				playing = false;
				flag = 0;
			});
           
			
			if( riddles[playedGrid].answer == riddles[formerPlayedGrid].answer ){

                    audioArray[p].addEventListener('ended', function () {
                        $('#word-' + formerPlayedGrid).hide(500);

                        $('#word-' + playedGrid).hide(500)
						/*$('#word-' + playedGrid).attr('disabled', '').removeClass("btn-warning").addClass("btn-success");*/
                        
						
               
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
	









/*//timer
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

*/

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

/*bindKeyboard();

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

}*/


function shuffle(array) {
  var currentIndex = array.length, temporaryValue, randomIndex;

  // While there remain elements to shuffle...
  while (0 !== currentIndex) {

    // Pick a remaining element...
    randomIndex = Math.floor(Math.random() * currentIndex);
    currentIndex -= 1;

    // And swap it with the current element.
    temporaryValue = array[currentIndex];
    array[currentIndex] = array[randomIndex];
    array[randomIndex] = temporaryValue;
  }

  return array;
}


$('#refresh').click(function() {
    location.reload();
});


$('#extraCategory').click(function() {
    location.reload();
	$('#extraCategory').text("");
});




