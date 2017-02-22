"use strict";

var grids = [];  //all the squares
var audios = []; //audeme audios
var columnsAudios = []; //audios that played when changing the number of columns 
var sequence = []; //the audeme sequence being player
var hoveredGrid; //the square hovered
var selectedGrid; //the square clicked
var playing; //whether an audio is being played or not
var sequencePlaying; //whether an audeme sequence is being played or not
var sequenceReply; // whether it is replay mode
var sequenceIndex; //index for sequence playing
var sequenceAnswer; //the answer to current sequence
var numberOfGrids; // how many 
var currentGame; //game object
var states = {'before opening':true, 'opening':false, 'normal':false, 'pause':false, 'bonus':false}; // game states
var opening; //opening anime
var openingStep;
var audemeSequences = []; // all sequences
var levelIndexs = [];
var hoverTimer; //timer used for display hints when hovered on a square
var numberOfPlayers //number of players


/*-------------------Timer object--------------------*/
/*
 function timer(time){
 var that = this;
 var cd;
 this.timerOn = false;
 this.startTime = time;
 this.currentTime = that.startTime;
 this.countdown =  function(){

 that.render();

 if (that.currentTime===0) {
 window.clearInterval(that.cd);
 sequencePlaying = false;


 $('#timeOut h2').html(sequenceAnswer);
 $('#timeOut').fadeIn();
 $('#answer').html(sequenceAnswer).addClass('unclickable');
 }
 else {

 that.currentTime--;

 }};

 this.render = function(){
 $('#digit1').html((that.currentTime-that.currentTime%10)/10);
 $('#digit2').html(that.currentTime%10);
 };
 this.start = function(){
 that.currentTime = that.startTime;
 that.timerOn = true;
 that.cd = self.setInterval(that.countdown, 1000);
 };

 this.stop = function(){
 window.clearInterval(that.cd);
 that.timerOn = false;
 that.render();
 }

 this.reset = function(){
 that.currentTime = that.startTime;
 }
 }

 var gameTimer = new timer(30);
 */
/*-------------------Game object--------------------*/

function game() {
    var that = this;
    this.players = [];
    this.level = 0;
    this.currentPlayer = 0;
    this.currentSequence = 0;
    this.sequencesPlayed = 0;
    this.sequencesRemain = 0;
    this.nextBonusLevel;
    this.playNext = function(){
        //var nextSeq = that.currentSequence +1;
        that.sequencesPlayed++;
        if(that.sequencesRemain!=0){
            if(	that.nextBonusLevel == that.sequencesPlayed){
                that.nextBonusLevel = 4 + Math.floor(Math.random()*2)
                that.sequencesPlayed = 0;
                states.bonus = true;
                gameTimer.reset();
                gameTimer.render();
                $('#answer').html('SUBMIT');
                $('#hints>p').html('bonus level!');
                /*var randomSeqLength = 2+ Math.floor(Math.random()*5);
                 console.log(randomSeqLength);
                 var randomSeq = [Math.floor(numberOfGrids* Math.random()), Math.floor(numberOfGrids* Math.random()), Math.floor(numberOfGrids* Math.random()), Math.floor(numberOfGrids* Math.random()), Math.floor(numberOfGrids* Math.random()),Math.floor(numberOfGrids* Math.random())].slice(6-randomSeqLength);
                 playSequence(randomSeq, 'bonus');*/


                $('#bonus').fadeIn();
                $('#answer').addClass('unclickable');
                $('#playNext').addClass('unclickable');
                //$('#replay').removeClass('unclickable');
                states['normal'] = false;
                states['pause'] = true;
            }
            else {
                var nextSeq = Math.floor(levelIndexs[that.level]* Math.random());
                $('#answer').html('SHOW ANSWER');
                gameTimer.stop();
                gameTimer.reset();
                gameTimer.render();

                that.sequenceRemain--;
                sequenceReply = false;
                for (var i=0; i<grids.length; i++) grids[i].locked = false;
                var shuffledSeq = audemeSequences[nextSeq].sequence.slice(0);
                if(!audemeSequences[nextSeq].fixedOrder) shuffle(shuffledSeq);
                playSequence(shuffledSeq, audemeSequences[nextSeq].answer, audemeSequences[nextSeq].hint);
                //$('#consoleAnswer').html(sequenceAnswer);
                that.switchPlayer(nextSeq);
            }

        }

        else {
            $('#answer').addClass('unclickable');
            $('#endPanel').fadeIn();
        }

    }

    this.addScore = function(score){
        that.players[that.currentPlayer].score+=score;
        drawScores();
    }
    /*
     this.switchPlayer = function(nextSeq){
     var nextPlayer = (that.currentPlayer +1)%(that.players.length);
     var nextHoverColor = 'hover-' + that.players[nextPlayer].color.name;
     $('.panelGrid').removeClass('hover-red').removeClass('hover-green').removeClass('hover-blue').addClass(nextHoverColor);
     that.currentSequence = nextSeq;
     that.currentPlayer = nextPlayer;
     drawPlayerName();
     }
     */
}

/*-------------------Player object--------------------*/


function player(name, color) {
    this.name = name;
    this.score = 0;
    this.color = color;

}

/*-------------------Sequence object--------------------*/


function audemeSequence(id, sequence, answer, hint, fixed) {
    this.id = id;
    this.sequence = sequence;
    this.answer = answer;
    this.hint = hint;
    this.fixedOrder = fixed;

}

/*-------------------Square object--------------------*/

function audemeGrid(id, x, y, image, audio) {
    this.id = id;
    this.x = x;
    this.y = y;
    this.image = image;
    this.audio = audio;
    this.locked = false;
    this.playedInSeq = 0;
    this.clicked = function(){
        if(states['normal']){
            if (selectedGrid==undefined){
                selectedGrid = this.id;
                playing = true;
                this.audio.play();
                highlightGrid(selectedGrid);
                //$('#log').html(audioList[this.id])
            }
        }};
}

/*-------------------Highlight current player in scoreboard and update scores--------------------*/
/*
 function drawPlayerName(){
 //$('#playerName').html(currentGame.players[currentGame.currentPlayer].name);
 //$('#playerName').css('color',currentGame.players[currentGame.currentPlayer].color.hex);
 $('#scoreBoard>p').removeClass('current');
 $('#'+'scoreText' + (currentGame.currentPlayer+1).toString()).addClass('current');
 }
 */
function drawScores(){
    var i;
    for(i=0; i<currentGame.players.length;i++){
        $('#'+'score' + (i+1)).html(currentGame.players[i].score);
        $('#'+'score' + (i+1)).css('color',currentGame.players[i].color.hex);
        $('#'+'scoreText' + (i+1)).css('color',currentGame.players[i].color.hex);


    }
}

/*-------------------Play opening animation--------------------*/
/*

 function playOpening(){

 if(openingStep >= numberOfGrids) {

 window.clearInterval(opening);
 states['opening'] = false;
 states['normal'] = true;
 //console.log('openingstep'+openingStep);
 states['pause'] = false;

 setInterval(gameLoop,30);
 //requestAnimationFrame(gameLoop);

 }
 else {
 //	console.log(openingStep+'  '+Date.now());
 $('.panelGrid[data-id='+openingStep+']').show();
 openingStep++;
 }



 }
 */
/*-------------------Change number of columns--------------------*/

/*
 function removeColumn(game){

 if(numberOfGrids>intialNumberOfGrids){
 var newLeftWidth = parseInt($('#leftPart').css('width')) - gridMargin - 2*gridRadius;
 $('#leftPart').css('width', newLeftWidth);
 //	var newBottomWidth = parseInt($('#controlPanelBottom').css('width')) - 120;
 //	$('#controlPanelBottom').css('width', newLeftWidth);
 var index = numberOfGrids-1;
 var target = index-3;
 while(index!=target){
 $('.panelGrid[data-id='+index+']').hide(); //console.log('remove'+index);

 index--;}
 numberOfGrids = index+1;
 game.level-=1;
 }

 //console.log(game.level);
 }

 function addColumn(game){


 if(numberOfGrids<maxNumberOfGrids){
 //console.log('success');
 var newLeftWidth = parseInt($('#leftPart').css('width'))+ gridMargin + 2*gridRadius;
 $('#leftPart').css('width', newLeftWidth);
 //	var newBottomWidth = parseInt($('#controlPanelBottom').css('width'))+120;
 //	$('#controlPanelBottom').css('width', newLeftWidth);
 var index = numberOfGrids;
 var target = index+3;
 while(index!=target){
 $('.panelGrid[data-id='+index+']').show();//console.log('add'+index);
 index++;}
 numberOfGrids = index;

 game.level+=1;
 }

 //console.log(game.level);
 }

 function changeColumnTo(targetColumn){
 if (targetColumn*3===numberOfGrids) return
 else if(targetColumn*3>numberOfGrids){
 while(targetColumn*3!==numberOfGrids){
 addColumn(currentGame);
 }
 }

 else{
 while(targetColumn*3!==numberOfGrids){
 removeColumn(currentGame);

 }
 }
 }
 */
/*-------------------Game initiation--------------------*/


function inti(numberOfGrid) {
    states['before opening'] = false;
    states['opening'] = true;
    states['normal'] = false;
    states['pause'] = false;

    for(var i = 0; i < 4; i++) {
        var audio = new Audio();
        audio.src = 'audio/Columns-' + (i+3) + '.mp3';
        columnsAudios.push (audio);

    }

    for(var i = 0; i < maxNumberOfGrids; i++)
    {
        var audio = new Audio();
        audio.src = 'audio/' + audioList[i];
        audio.addEventListener('ended', function(){
            if(!sequencePlaying) {
                if(!grids[selectedGrid].locked)
                    $('.panelGrid[data-id='+selectedGrid+']').removeClass('color-red').removeClass('color-green').removeClass('color-blue').addClass('color-grey')}
            selectedGrid = undefined;
            playing = false;


        })
        audios.push (audio);

        var posy = gridTopMargin + (i%3)*gridMargin + (2*(i%3))*gridRadius;
        var posx = gridLeftMargin + (Math.floor(i/3))*gridMargin + (2*Math.floor(i/3))*gridRadius;
        grids.push(new audemeGrid(i, posx, posy, undefined, audio));
        $("<div class='panelGrid' data-id='"+i+"'></div>").appendTo('#sceneWrapper').on('click',function(e){
            e.preventDefault();
            grids[$(this).attr('data-id')].clicked();
        }).mouseenter(function() {
            var that = this;
            hoverTimer = setTimeout(function(){
                var index = $(that).attr('data-id');
                if(grids[index].locked){
                    $('#descriptions>p').html(altList[index]);
                    $('#descriptions').css('visibility', 'visible');}
            }, 1000);
        }).mouseleave(function() {
            var that = this;
            clearTimeout(hoverTimer);
            $('#descriptions>p').html('');
            $('#descriptions').css('visibility', 'hidden');
        });


    }
    selectedGrid = undefined;
    levelIndexs[0] = sequenceList1.length;
    levelIndexs[1] = levelIndexs[0] + sequenceList2.length;
    levelIndexs[2] = levelIndexs[1] + sequenceList3.length;
    levelIndexs[3] = levelIndexs[2] + sequenceList4.length;
    var sequenceId=0;
    var i;

    for(i=0; i<sequenceList1.length; i++)
    {
        sequenceList1[i].list.reverse();
        audemeSequences.push(new audemeSequence(sequenceId++, sequenceList1[i].list, sequenceList1[i].answer.toUpperCase(), sequenceList1[i].hint, sequenceList1[i].fixedOrder));

    }
    for(i=0; i<sequenceList2.length; i++)
    {
        sequenceList2[i].list.reverse();
        audemeSequences.push(new audemeSequence(sequenceId++, sequenceList2[i].list, sequenceList2[i].answer.toUpperCase(), sequenceList2[i].hint, sequenceList2[i].fixedOrder));

    }for(i=0; i<sequenceList3.length; i++)
    {
        sequenceList3[i].list.reverse();
        audemeSequences.push(new audemeSequence(sequenceId++, sequenceList3[i].list, sequenceList3[i].answer.toUpperCase(), sequenceList3[i].hint, sequenceList3[i].fixedOrder));

    }for(i=0; i<sequenceList4.length; i++)
    {
        sequenceList4[i].list.reverse();
        audemeSequences.push(new audemeSequence(sequenceId++, sequenceList4[i].list, sequenceList4[i].answer.toUpperCase(), sequenceList4[i].hint, sequenceList4[i].fixedOrder));

    }
    playing = false;
    sequencePlaying = false;
    sequenceReply = false;
    sequenceIndex = 0;
    sequenceAnswer = "SHOW ANSWER"
    openingStep = 0;
    drawPlayerName();
    drawScores();

    $('#answer').html(sequenceAnswer).addClass('unclickable');
    for(i=0;i<maxNumberOfGrids;i++){
        $('.panelGrid[data-id='+i+']').css('top',grids[i].y+'px').css('left',grids[i].x+'px').addClass('color-grey').addClass('hover-red').css('top',grids[i].y)}
    opening = self.setInterval(playOpening, openingDuration/numberOfGrid);
    $('#controlPanelRight').animate({height:630},openingDuration, function(){$('#revealAnswers').fadeIn(); $('#hints').fadeIn();$('#scoreBoard').fadeIn();});
    //$('#controlPanelBottom').animate({width:600},openingDuration, function(){
    $('.controlButton').fadeIn();
    $('#columns3').addClass('active');
    //bindTipsHandlers();
}

/*-------------------Highlight hovered square--------------------*/


function highlightGrid(id){
    var currentColor = 'color-'+ currentGame.players[currentGame.currentPlayer].color.name;
    if(!($('.panelGrid[data-id='+id+']').hasClass(currentColor))){
        $('.panelGrid[data-id='+id+']').removeClass('color-red').removeClass('color-green').removeClass('color-blue').removeClass('color-grey').addClass(currentColor);
    }
}

/*-------------------Loop for sequence playing--------------------*/


function gameLoop() {
    if(sequencePlaying){
        if(!playing) {
            if(sequenceIndex>=1) {
                var currentGrid = grids[sequence[sequenceIndex-1]];
                currentGrid.clicked();
                currentGrid.locked = true;
                if(++currentGrid.playedInSeq >1) {
                    $('.panelGrid[data-id='+currentGrid.id+']').html('X'+ currentGrid.playedInSeq);
                };

            }
            if(sequenceIndex>0) {
                sequenceIndex--;
            }
            else {
                sequencePlaying = false;
                if (!sequenceReply&&!states.bonus) {
                    $('#answer').removeClass('unclickable');
                    $('#replay').removeClass('unclickable');
                    $('#timer').slideDown(300, function(){gameTimer.start();});

                }
                else if (states.bonus){
                    $('#answer').removeClass('unclickable');
                    $('#replay').removeClass('unclickable');

                }
                else {sequenceReply = false;}
            }
        }
    }
    //requestAnimationFrame(gameLoop);
}

/*-------------------Function for shuffle a array--------------------*/


function shuffle(array){
    var counter = array.length, temp, index;

    while (counter > 0) {
        index = Math.floor(Math.random() * counter);
        counter--;
        temp = array[counter];
        array[counter] = array[index];
        array[index] = temp;
    }

    return array;
}

/*-------------------Play a sequence --------------------*/


function playSequence(seq,answer,hint) {
    $('.panelGrid').html('').removeClass('color-red').removeClass('color-green').removeClass('color-blue').removeClass('color-grey').addClass('color-grey');
    for (var i =0; i<grids.length; i++){
        grids[i].playedInSeq =0;
    }
    sequence = [];
    sequence = seq;
    //sequence = shuffle(sequence);
    sequenceIndex = sequence.length;

    sequencePlaying = true;
    sequenceAnswer = answer;
    if(hint) $('#hints p').html(hint);
    if(!sequenceReply)$('#answer').addClass('unclickable');
}


/*-------------------Game start--------------------*/

function gameStart(){

    $('#beforeGameStart').fadeOut(220,function(){
        //audemeSequences = shuffle(audemeSequences);
        var index = Math.floor(levelIndexs[currentGame.level]* Math.random());
        var shuffledSeq = (audemeSequences[index].sequence).slice(0);
        if(!audemeSequences[index].fixedOrder) shuffle(shuffledSeq);
        playSequence(shuffledSeq, audemeSequences[index].answer, audemeSequences[index].hint);
        //playSequence([1,2,3,4,5,6,7],'test')
        //	console.log(numberOfGrids);
        $('#consoleAnswer').html(sequenceAnswer);});


}

numberOfGrids = intialNumberOfGrids;

/*-------------------Add listeners on elements--------------------*/
/*

 $('#answerYes').on('click',function(e){
 e.preventDefault();
 $('#answerConfirm').fadeOut(400, function(){$('#playNext').removeClass('unclickable'); currentGame.addScore(10*sequence.length);} );

 states['normal'] = true;
 states['pause'] = false;


 });

 $('#bonusContinue').on('click', function(e){
 e.preventDefault();
 console.log('clicked');
 $('#bonus').fadeOut(400, function(){
 var randomSeqLength = 2+ Math.floor(Math.random()*5);
 console.log(randomSeqLength);
 var randomSeq = [Math.floor(numberOfGrids* Math.random()), Math.floor(numberOfGrids* Math.random()), Math.floor(numberOfGrids* Math.random()), Math.floor(numberOfGrids* Math.random()), Math.floor(numberOfGrids* Math.random()),Math.floor(numberOfGrids* Math.random())].slice(6-randomSeqLength);
 playSequence(randomSeq, 'bonus');
 currentGame.switchPlayer(randomSeq);
 });
 states['normal'] = true;
 states['pause'] = false;
 })


 $('#answerNo').on('click',function(e){
 e.preventDefault();
 $('#answerConfirm').fadeOut(400, function(){$('#playNext').removeClass('unclickable');});
 states['normal'] = true;
 states['pause'] = false;

 });

 $('#timeOutNext').on('click', function(e){
 e.preventDefault();
 //console.log('clicked');
 $('#timeOut').fadeOut(400, function(){$('#playNext').removeClass('unclickable');});
 states['normal'] = true;
 states['pause'] = false;

 })
 $('#audemeSubmit').on('click', function(e){
 $('#audemeNameInput').fadeOut(400, function(){$('#playNext').removeClass('unclickable');currentGame.addScore(10*sequence.length);});
 states.bonus = false;
 states['normal'] = true;
 states['pause'] = false;
 })

 $('#answerWrapper').on('click', function(e){
 e.preventDefault();
 if(!$('#answer').hasClass('unclickable')) {
 if(!states.bonus){
 $('#answer').html(sequenceAnswer);
 $('#answer').removeClass('unclickable');
 $('#answerWrapper').removeClass('unclickable');

 gameTimer.stop();
 $('#answerConfirm h2').html(sequenceAnswer);
 $('#answerConfirm').fadeIn();
 $('#answer').addClass('unclickable');
 $('#answerWrapper').addClass('unclickable');

 states['normal'] = false;
 states['pause'] = true;
 //console.log(states);
 }
 else {
 $('#audemeNameInput').fadeIn();
 $('#answer').addClass('unclickable');
 gameTimer.reset();
 states['normal'] = false;
 states['pause'] = true;
 }


 }

 })



 $('#replay').on('click', function(e){
 if(!$(this).hasClass('unclickable')){
 if(states['normal']){
 e.preventDefault();
 if(!sequencePlaying) {
 //if(gameTimer.currentTime>0&&gameTimer){
 sequenceReply=true;
 playSequence(sequence,sequenceAnswer);

 //	}
 }
 }
 }
 })

 $('#add').on('click', function(e){
 if(states['normal']){
 e.preventDefault();
 addColumn(currentGame);
 }
 });

 $('#remove').on('click', function(e){
 if(states['normal']){
 e.preventDefault();
 removeColumn(currentGame);
 }
 });

 $('#playNext').on('click', function(e){
 if(states['normal']){
 if(!$(this).hasClass('unclickable')){
 e.preventDefault();
 $('#timer').slideUp(300, function(){
 currentGame.playNext();
 $('#replay').addClass('unclickable');
 $('#playNext').addClass('unclickable');

 });


 }
 }
 });
 $('.controlButton').on('click',function(){
 $('.controlButton').removeClass('active');
 $(this).addClass('active');

 })
 $('#columns3').on('click', function(){changeColumnTo(3); columnsAudios[0].play();});
 $('#columns4').on('click', function(){changeColumnTo(4); columnsAudios[1].play();});
 $('#columns5').on('click', function(){changeColumnTo(5); columnsAudios[2].play();});
 $('#columns6').on('click', function(){changeColumnTo(6); columnsAudios[3].play();});
 */

$('#gameStartButton').on('click',function(e){
    e.preventDefault();
    $(this).off();
    numberOfPlayers = $("input[type='radio'][name='numberOfPlayers']:checked").val();
    //	$('#gameStartWrapper').fadeOut(300, function(){$('#tutorial1').fadeIn();
//});

    currentGame = new game();
    numberOfPlayers = $("input[type='radio'][name='numberOfPlayers']:checked").val();
    for(var i=0; i<numberOfPlayers; i++){
        var name = 'Player '+(i+1);
        var color = playerColor[i]
        var tempPlayer = new player(name, color);
        currentGame.players.push(tempPlayer);
        $('#scoreBoard').append("<h1 id='score"+(i+1)+"' class='scoreDigit'>0</h1>");

    }
    currentGame.sequencesRemain = numberOfPlayers*sequencesPerPlayer;
    currentGame.nextBonusLevel = 4 + Math.floor(Math.random()*2);
    inti(numberOfGrids);
    gameStart();


});
/*
 $('#hint').on('click', function(e){
 e.preventDefault();
 $('#hints>p').slideDown();
 if(!$( "#hints>p" ).is( ":hidden")){
 $('#hint').html('HIDE HINT');
 }
 else $('#hint').html('SHOW HINT');

 window.setTimeout(function(){$('#hints>p').slideUp();	}, 2000);
 })

 $('.skipTutorial').on('click', function(e){
 e.preventDefault();
 $('.tutorials').fadeOut().remove();
 currentGame = new game();
 for(var i=0; i<numberOfPlayers; i++){
 var name = 'Player '+(i+1);
 var color = playerColor[i]
 var tempPlayer = new player(name, color);
 currentGame.players.push(tempPlayer);
 $('#scoreBoard').append("<p id='scoreText"+(i+1)+"'>Player "+(i+1)+"<span id='score"+(i+1)+"' class='scoreDigit'>0</span></p>");

 }
 currentGame.sequencesRemain = numberOfPlayers*sequencesPerPlayer;
 currentGame.nextBonusLevel = 5 + Math.floor(Math.random()*2);
 inti(numberOfGrids);
 gameStart();

 })

 $('#tutorialNext1').on('click', function(e){
 e.preventDefault();
 $('#tutorial1').fadeOut().remove();
 $('#tutorial2').fadeIn();
 $('#tutorialPanel2').fadeIn();
 $('#tutorial2 .panelGrid').on('click', function(){
 var audio = document.getElementById('tutorialAudio2');
 audio.play();})

 })

 $('#tutorialNext2').on('click', function(e){
 e.preventDefault();
 $('#tutorial2').fadeOut().remove();
 $('#tutorial3').fadeIn();
 $('#panel31').on('click', function(){
 var audio = document.getElementById('tutorialAudio31');
 audio.play();});
 $('#panel32').on('click', function(){
 var audio = document.getElementById('tutorialAudio32');
 audio.play();})
 })

 $('#tutorialNext3').on('click', function(e){
 e.preventDefault();
 $('#tutorial3').fadeOut().remove();
 $('#tutorial4').fadeIn();
 $('#panel41').on('click', function(){
 var audio = document.getElementById('tutorialAudio41');
 audio.play();});
 $('#panel42').on('click', function(){
 var audio = document.getElementById('tutorialAudio42');
 audio.play();});
 $('#panel43').on('click', function(){
 var audio = document.getElementById('tutorialAudio43');
 audio.play();});
 })

 $('#tutorialNext4').on('click', function(e){
 e.preventDefault();
 $('#tutorial4').fadeOut().remove();
 $('#tutorial5').fadeIn();
 })

 $('#tutorialNext5').on('click', function(e){
 e.preventDefault();
 $('#tutorial5').fadeOut().remove();
 $('#tutorial6').fadeIn();
 })

 $('#tutorialNext6').on('click', function(e){
 e.preventDefault();
 $('#tutorial6').fadeOut().remove();
 $('#tutorial7').fadeIn();
 })

 $('#tutorialNext7').on('click', function(e){
 e.preventDefault();
 $('#tutorial7').fadeOut().remove();
 $('#tutorial8').fadeIn();
 })

 $('#tutorialNext8').on('click', function(e){
 e.preventDefault();
 $('#tutorial8').fadeOut().remove();
 $('#tutorial9').fadeIn();
 })

 $('#gameRestart').on('click', function(e){
 e.preventDefault();
 location.reload();
 })
 */