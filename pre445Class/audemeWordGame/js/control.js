// JavaScript Document
//game control
var myScroll;
var control = new Control();

//----------------------load scroll list---------------------------
function loaded() {
	myScroll = new iScroll('scroll',{checkDOMChanges:true});
}
document.addEventListener('DOMContentLoaded', loaded, false);


//----------------------game controller---------------------------

function Control(){
	this.states = { 'normal': true, 'game':false};	
	this.currentWord = '';
	this.currentWordId = '';
	this.currentWordAudeme = '';
	this.currentMismatchList=[];
	this.currentSynonymsList=[];
	this.gameCorrectWord = 0;
	this.gameWrongWord = 0;
	this.gameOn = false;
	this.score = 0;
}


function MenuButtonClicked(button){
	if(document.getElementById('audio').readyState)	{
		AudioStop();
		}
	$('.listdrawer').trigger('click');
	control.currentWord=button.text();	
	control.currentWordId=button.attr('data-id');
	control.currentWordAudeme = button.attr('data-path');
	$('.flashcard h1').text(control.currentWord);	
	$('#audio').attr('src',button.attr('data-path'));
	$('.synonymslist>ul').html('');	
	control.gameOn = false;
	
	LoadGame();

//	db.transaction(function(tx) {
//           tx.executeSql('SELECT * FROM synonyms WHERE wid='+control.currentWordId, [], RenderSynonymsList);})
	var num = audemeData[control.currentWordId].synonyms.length<3?audemeData[control.currentWordId].synonyms.length:3;
	for (var i=0; i<num; i++){
		          $("<li>"+audemeData[control.currentWordId].synonyms[i]+"</li>").appendTo('.synonymslist>ul');

	}
}

/*function RenderWordList(tx,rs) {
	 for(var i=0; i<10;/* i < rs.rows.length; i++) {
          r = rs.rows.item(i);
          $("<li data-id ='"+r['wid']+"' data-path='"+ r['waudeme']+"'>"+r['wtext']+"</li>").appendTo('.wordlist>ul');
        }
		$('.wordlist ul li').on('click',function(){
		if(!$(this).hasClass('scrolling')){
		MenuButtonClicked($(this));
		$('.wordlist ul li').removeClass('selected');
		$(this).addClass('selected');}	
	})
		$('.wordlist ul li:nth-child(1)').trigger('click');
};
*/

function RenderSynonymsList(tx,rs) {
	var l = rs.rows.length<3?rs.row.length:3;
	 for(var i=0; i < l; i++) {
          r = rs.rows.item(i);
          $("<li>"+r['stext']+"</li>").appendTo('.synonymslist>ul');
        }
}

function LoadWordList() {
	
	/*db.transaction(function(tx) {
            tx.executeSql('SELECT * FROM word', [], RenderWordList);

        });*/
		
	for(var i=0; i<audemeData.length; i++) {
		$("<li data-id ='"+ i +"' data-path='"+ audemeData[i].audeme+"'>"+audemeData[i].word+"</li>").appendTo('.wordlist>ul');

	} 
	$('.wordlist ul li').on('click',function(){
		//if(!$(this).hasClass('scrolling')){
		MenuButtonClicked($(this));
		$('.wordlist ul li').removeClass('selected');
		$(this).addClass('selected');
		//}	
	})
		$('.wordlist ul li:nth-child(1)').trigger('click');

	
}

function LoadSubMenu(){
	$('.menutab ul li').on('click',function(e){
		e.preventDefault();
		
		switch($(this).attr('id')) {
    case 'normal':
		$('.gamezone').show();
		$('.flashcard').show();	
		$('.scrolling').animate(
					{
						left:0
					},400,function() {
    // Animation complete.
		$('.wordlist').animate(
		{width:200},260,function(){
			$('.listdrawer').css('width','10px').attr('data-status','collapse');
		}
		
		)
  });
		if(document.getElementById('audio').readyState)	{
		AudioStop();
		}
		control.states['normal'] = true;
		control.states['game'] = false;
		$('.notification').hide();
		$('.notification #starboard').css('width','0');
        break;
    case 'game':
		$('.gamezone').show();
		$('.flashcard').show();
		$('.scrolling').animate(
					{
						left:-1000
					},400,function() {
    // Animation complete.
		}
		
		);
		if(document.getElementById('audio').readyState)	{
		AudioStop();
		}
		control.states['normal'] = false;
		control.states['game'] = true;

		GameInti();

		break;
	
    default:
         
}
		$('.menutab ul li').removeClass('selected');
		$(this).addClass('selected');
	});
}
//----------------------game initiation---------------------------

function GameInti() {
	if(control.currentWord!=$('#gameword').html()){
		$('#audio').attr('src',control.currentWordAudeme);
		$('#gameword').html(control.currentWord);
		$('.gamepanel').html('');
		$('.gamepanel').attr('data-status','unused');
		control.gameCorrectWord = 0;
		control.gameWrongWord = 0;
		$('.gamepanel').removeClass('clicked');

	}
}

//----------------------game start---------------------------

function LoadGame(){
	var word = control.currentWord;
	var wordid = control.currentWordId;
	$('.gamepanels').fadeIn();
	$('#gametitle').fadeOut();
	$('.gamepanel').removeClass('clicked');
	var audemepath = control.currentWordAudeme;
	control.gameCorrectWord = 0;
	control.gameWrongWord = 0;
	control.gameOn = true;
	$('#audio').attr('src',audemepath);
	//document.getElementById('audio').play();  Stop automatic play!!!!
	$('#gameword').html(word).animate({
		left:10,
		top:70
	}).fadeIn();
	$('.score').fadeIn();
	/*db.transaction(function(tx) {
		tx.executeSql('SELECT * FROM synonyms WHERE wid='+wordid,[],LoadSynonymsDone);});		*/
	control.currentSynonymsList = [];
	for (var i=0; i<audemeData[wordid].synonyms.length; i++){
		control.currentSynonymsList[control.currentSynonymsList.length] = audemeData[wordid].synonyms[i];
	}
	control.currentMismatchList = [];
	for (var i=0; i<audemeData[wordid].mismatch.length; i++){
		control.currentMismatchList[control.currentMismatchList.length] = audemeData[wordid].mismatch[i];
	}
	var mismatch = shuffle(control.currentMismatchList);
	var synonyms = shuffle(control.currentSynonymsList);
	var textqueue = synonyms.concat(mismatch);
	var panelqueue = [1,2,3,4,5,6];
	shuffle(panelqueue);
	$('.gamepanel').html('').attr('data-status','unused');
	for (var i=0; i<(synonyms.length);i++){
		$('#panel'+ panelqueue[i]).html( textqueue[i]);
		$('#panel'+ panelqueue[i]).attr('data-status','synonyms');
		
	}
	for (var i=synonyms.length; i<panelqueue.length;i++){
		$('#panel'+ panelqueue[i]).html( textqueue[i]);
		$('#panel'+ panelqueue[i]).attr('data-status','mismatch');
    
	}
}

function addAudio(textqueueNum){
			var audio = new Audio();
			audio.src = "wordPron/" + textqueueNum  + ".mp3";
			audio.play();
			} 


/*
function LoadSynonymsDone(tx,rs) {

		control.currentSynonymsList = [];
		for(var i=0; i < rs.rows.length; i++) {
		r = rs.rows.item(i);
		control.currentSynonymsList[control.currentSynonymsList.length] = r['stext'];
		}
		tx.executeSql('SELECT * FROM mismatch WHERE wid='+r['wid'],[],LoadMismatchDone);


}

function LoadMismatchDone(tx, rs) {
		control.currentMismatchList = [];
		for(var i=0; i < rs.rows.length; i++) {
		r = rs.rows.item(i);
		control.currentMismatchList[control.currentMismatchList.length] = r['mtext'];
		}
		
		var mismatch = shuffle(control.currentMismatchList);
		var synonyms = shuffle(control.currentSynonymsList);
		var textqueue = synonyms.concat(mismatch);
		var panelqueue = [1,2,3,4,5,6];
		shuffle(panelqueue);
		$('.gamepanel').html('').attr('data-status','unused');
		for (var i=0; i<(synonyms.length);i++){
			$('#panel'+ panelqueue[i]).html( textqueue[i]);
			$('#panel'+ panelqueue[i]).attr('data-status','synonyms');
		}
		for (var i=synonyms.length; i<panelqueue.length;i++){
			$('#panel'+ panelqueue[i]).html( textqueue[i]);
			$('#panel'+ panelqueue[i]).attr('data-status','mismatch');

		}

}
*/
//----------------------function for array shuffle---------------------------


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

//----------------------load audeme audios and sound effects---------------------------


function LoadAudios(){
	$("<audio src='audios/RIGHT ANSWER CHEER.mp3' id='cheerssound'></audio>").appendTo('.page');
	$("<audio src='audios/WRONG ANSWER oops.mp3' id='oopssound'></audio>").appendTo('.page');
	$("<audio id='audio'></audio>").appendTo('.page');
	$('#audio').on('playing',function(){
		$('.audiocontrol').css('background-image','url(images/sound-icon-play.png)');
		});
	$('#audio').on('ended',function(){
		$('.audiocontrol').css('background-image','url(images/sound-icon.png)');
		});
	
}



function AudioStop(){
	document.getElementById('audio').pause();
	document.getElementById('audio').currentTime = 0;
	document.getElementById('cheerssound').pause();
	document.getElementById('cheerssound').currentTime = 0;
	document.getElementById('oopssound').pause();
	document.getElementById('oopssound').currentTime = 0;
	$('.audiocontrol').css('background-image','url(images/sound-icon.png)');
}

$(document).ready(function() {
	$('.page').addClass('landscape').addClass('unselectable');
	LoadAudios();
	/*audemedata.webdb.open();
	audemedata.webdb.createTable();
	audemedata.webdb.importTestData ();
	db = audemedata.webdb.db;
	 db.transaction(function(tx) {
				 tx.executeSql('DELETE FROM word',[]);
				 tx.executeSql('DELETE FROM synonyms',[]);
 				 tx.executeSql('DELETE FROM mismatch',[]);

				  });*/
	LoadWordList();
	LoadSubMenu();
	$('#normal').trigger('click');

    SetOrientationListener();
	$('.synonymslist>ul').on('click',function(e){
		e.preventDefault();
		document.getElementById('audio').play();
	})
	
	/*$('.audiocontrol').on('click',function(e){
		e.preventDefault;
		if(document.getElementById('audio').readyState&&document.getElementById('audio').paused){
		document.getElementById('audio').play();}
		else {AudioStop();}
	})
	*/
	$('h1').on('click',function(e){
		e.preventDefault;
		if(document.getElementById('audio').readyState&&document.getElementById('audio').paused){
		document.getElementById('audio').play();}
		else {AudioStop();}
	})

		
	$('#next').on('click',function(e){
		e.preventDefault();
		if($('.wordlist ul li.selected').text()===$('.wordlist ul li:last-child').text()){
				$('.wordlist ul li:nth-child(1)').trigger('click');
		}
		else {$('.wordlist ul li.selected').next().trigger('click');
			}
		});
	
	$('#previous').on('click',function(e){
				e.preventDefault();

		if($('.wordlist ul li.selected').text()===$('.wordlist ul li:nth-child(1)').text()){
				$('.wordlist ul li:last-child').trigger('click');
		}
		else {$('.wordlist ul li.selected').prev().trigger('click');
			}
			
		});
		
	$('.gamepanel').on('click',function(e){
		e.preventDefault();
		if (control.states['game']&&control.gameOn){
		/*if (!$(this).hasClass('clicked')){
		$(this).addClass('clicked');
		
		switch($(this).attr('data-status')){
			case 'synonyms':
				AudioStop();	
				document.getElementById('cheerssound').play();
				
				control.gameCorrectWord += 1;
				if (control.gameCorrectWord ==control.currentSynonymsList.length){
					control.gameOn = false;
					$('.notification').show();
										
				}
				break;
			case 'mismatch':
				AudioStop();
				document.getElementById('oopssound').play();
				control.gameWrongWord += 1;
				break;
			default: return false;

			
		}
		}*/
		switch($(this).attr('data-status')){
			case 'synonyms':
				AudioStop();	
				var textContent = $(this).html();
				addAudio(textContent);
				document.getElementById('cheerssound').play();
				
		
				
				if (!$(this).hasClass('clicked')){
				$(this).addClass('clicked');
				control.score+=100;
				control.gameCorrectWord += 1;
				
				
				$('.score span').html(control.score);
				if (control.gameCorrectWord ==control.currentSynonymsList.length){
					//control.gameOn = false;
					//$('.notification').show();
										
				}
				}
				break;
			case 'mismatch':
				AudioStop();
				document.getElementById('oopssound').play();
				control.gameWrongWord += 1;
				break;
			default: return false;

			
		}

		}
	 });
	 
	 $('h1').mouseenter(function(){
			$('.audiocontrol').css('background-image','url(images/sound-icon-play.png)');
			$(this).mouseleave(function(){
			if (document.getElementById('audio').paused)
			$('.audiocontrol').css('background-image','url(images/sound-icon.png)')
			})
	 });
	 
	 $('.synonymslist>ul').mouseenter(function(){
			$('.audiocontrol').css('background-image','url(images/sound-icon-play.png)');
			$(this).mouseleave(function(){
			if (document.getElementById('audio').paused)
			$('.audiocontrol').css('background-image','url(images/sound-icon.png)')
			})
	 });
	 
	 $('#gamestart').on('click',function(){
		$('#gamestart').animate({
			width: 120,
			left: 180,
			bottom: 155
			
		},300).html('Play Again');
		
		$('#gamedescript').animate({
			fontSize: '16px',
			left: 160,
			top: 200
		},300);
	 
		
		LoadGame();
		});
	$('.notification #close').on('click', function(){
		$('.notification').hide();
		$('#gamestart').trigger('click');
	});	
		
		
	$('.listdrawer').on	('click',function(){
		if(control.states['game']){
			//if($('.listdrawer').attr('data-status')=='collapse'){
				console.log('expand drawer');
				$('.wordlist').animate(
		{width:200},260);
		$('.listdrawer').animate({width:210},280).attr('data-status','expand');
			//}
			//else{
//			$('.wordlist').animate(
//		{width:0},260);
//			$('.listdrawer').animate({width:10},280).attr('data-status','collapse');
//			}
//			
		}
	})
});