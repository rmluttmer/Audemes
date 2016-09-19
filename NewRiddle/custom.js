// JavaScript Document
var riddles = [
{mp3: "mp3/r_abrasion.mp3",
answer: "Abrasion",
mp3Answer: "mp3/a_abrasion.mp3"
},
{mp3: "mp3/r_agriculture_farming.mp3",
answer: "Agriculture Farming",
mp3Answer: "mp3/a_agriculture_farming.mp3"
},
{mp3: "mp3/r_air_pressure.mp3",
answer: "Air Pressure",
mp3Answer: "mp3/a_air_pressure.mp3",
},
{mp3: "mp3/r_allergy.mp3",
answer: "Allergy",
mp3Answer: "mp3/a_allergy.mp3"
},
{mp3: "mp3/r_amphibian.mp3",
answer: "Amphibian",
mp3Answer: "mp3/a_amphibian.mp3",
},
{mp3: "mp3/r_aquaculture.mp3",
answer: "Aquaculture",
mp3Answer: "mp3/a_aquaculture.mp3"
},
{mp3: "mp3/r_atom.mp3",
answer: "Atom",
mp3Answer: "mp3/a_atom.mp3",
},
{mp3: "mp3/r_biodiversity.mp3",
answer: "Biodiversity",
mp3Answer: "mp3/a_biodiversity.mp3"
},
{mp3: "mp3/r_biomass.mp3",
answer: "Biomass",
mp3Answer: "mp3/a_biomass.mp3",
},
{mp3: "mp3/r_biome.mp3",
answer: "Biome",
mp3Answer: "mp3/a_biome.mp3"
},
{mp3: "mp3/r_bird.mp3",
answer: "Bird",
mp3Answer: "mp3/a_bird.mp3",
},
{mp3: "mp3/r_blizzard.mp3",
answer: "Blizzard",
mp3Answer: "mp3/a_blizzard.mp3"
},
{mp3: "mp3/r_cell.mp3",
answer: "Cell",
mp3Answer: "mp3/a_cell.mp3",
},
{mp3: "mp3/r_chain_reaction.mp3",
answer: "Chain Reaction",
mp3Answer: "mp3/a_chain_reaction.mp3"
},
{mp3: "mp3/r_chemical_reaction.mp3",
answer: "Chemical Reaction",
mp3Answer: "mp3/a_chemical_reaction.mp3",
}
]

var words = $('.cell');
var audioArray = [];
for(var i=0; i< riddles.length; i++){
	words.eq(i).attr('id', 'word-'+i);
	var audio = new Audio();
		audio.src = riddles[i].mp3;
		audioArray.push(audio);
	}

$('#category').tooltip('show');

$('.cell').attr('disabled','');
$('#submit').attr('disabled','');
$("label[name='category']").click(function(){
	
	for(var i=0; i< riddles.length; i++){
	words.eq(i).removeAttr("disabled");
	}
	
	$('#submit').removeAttr("disabled");
	});
	

//player


var playedGrid;
$('.cell').on('click', function(){
	progressTimerClear();
	var p = $(this).attr('id');
	p = p.substr(5, '2');
	playedGrid = p;
	audioArray[p].play();
	playingAnimation($('#word-'+p).children(), audioArray[p]);
	 $('#submit').tooltip('show');
	})	

  
$('#submit').click(function(){
	
	if($("input[name='mode']:checked").val() == "Student"){
		$('#submitLayer-student').modal('show');}
else{
	$('#submitLayer-teacher').modal('show');
	}
	
	$('.answer').html(riddles[playedGrid].answer);
	$('#submit').tooltip('destroy');
	})

$('.answer-audio').on('click', function(){
	var audio = new Audio();
		audio.src = riddles[playedGrid].mp3Answer;
		audio.play();
	})

$('#save-point').click(function(){
	var current_point = $('#point').text();
	$("input[name='point']:checked").parent().removeClass("active");
	current_point = parseInt(current_point) + parseInt($("input[name='point']:checked").val());
	$('#point').text(current_point);
	});


//mode control
if($("input[name='mode']:checked").val() == "Student"){
		$('.timer').hide();}
else{
	$('.timer').show();
	}
$("label[name='mode']").click(function(){
	if($("input[name='mode']:checked").val() == "Student"){
		$('.timer').fadeIn();}
else if($("input[name='mode']:checked").val() == "Teacher"){
	$('.timer').fadeOut();
	}
	})
	
	
	
	
//timer
var counting =0;
var progressTimer = function(){
	$('.timer').children('.alert').addClass("timer-glow");
	var timer;
	timer = 0;
	counting = 1;
    var progress = setInterval(function() {
		if(timer < 30 && counting == 1){
			timer= timer+1;
			$('#timer').text(30-timer);
			}
			else{ clearInterval(progress);	
			counting = 0;
				}
	 
		}, 1000);
	}
	
var progressTimerClear = function(){
	counting = 0;
	$('#timer').text(30);
	$('.timer').children('.alert').removeClass("timer-glow");
	}
 
function playingAnimation(span, audioItem){
	span.removeClass("glyphicon-play").addClass("glyphicon-volume-up");
	
	var spanClass = setInterval(function() {
		if(span.hasClass("glyphicon-volume-up")){
			span.removeClass("glyphicon-volume-up").addClass("glyphicon-volume-down");}
			else{
				span.removeClass("glyphicon-volume-down").addClass("glyphicon-volume-up");
				}
		
		audioItem.addEventListener('ended', function(){
			clearInterval(spanClass);
			span.parent().attr('disabled','').removeClass("btn-warning");
			
			span.removeClass("glyphicon-volume-down").removeClass("glyphicon-volume-up").addClass("glyphicon-ok");
			progressTimer();
			})

		}, 500);
	}

