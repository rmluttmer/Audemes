// JavaScript Document
//orientation detection of the page on tablet 

function SetOrientationListener(){
	rotationInterval = setInterval( function(){ //UpdateOrientation();
					$('.page').removeClass('portrait').addClass('landscape');	
	
	 }, 500 );
}

function UpdateOrientation(){
	if($('body').width() < 1024){
		$('.page').removeClass('landscape').addClass('portrait');
	}else{
		$('.page').removeClass('portrait').addClass('landscape');	
	}
}