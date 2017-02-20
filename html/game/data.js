var audioList = [
"2_air.mp3", //0
"5_animal.mp3", //1
"0_earth.mp3", //2

"1_rising.mp3", //3
"4_inside.mp3",//4
"7_lowering.mp3", //5

"6_fire.mp3",//6
"3_machine.mp3",//7 
"8_water.mp3",//8

"9_big.mp3",//9
"10_cold.mp3",//10
"11_small.mp3",//11

"12_fast.mp3",//12
"13_process.mp3",//13
"14_slow.mp3",//14

"15_people.mp3",//15
"16_outside.mp3",//16
"17_time.mp3"//17
];  //list of audio files;

var altList = [
"atmosphere, gases, wind", //0
"natural, plant, creature", //1
"land, territory, rock", //2
 
"ascending, up, increasing", //3
"interior, core, within",//4
"descend, down, decreasing", //5
 
"energy, heat",//6
"artificial, mechanical, technology",//7 
"water, river, flowing",//8
 
"huge, monumental",//9
"ice, snow, freezing",//10
"tiny, minuscule, detail",//11
 
"quick, speedy",//12
"becoming, develop, change",//13
"gradual, sluggish",//14
 
"person, human",//15
"external, exterior",//16
"era, period"//17
]; //list of descriptions for each square


var gridRadius = 60;
var gridMargin = 8;
var gridLeftMargin = 10;
var gridTopMargin = 10;
var intialNumberOfGrids = 9;
var maxNumberOfGrids = 18;
var sequencesPerPlayer = 10;

//settings. 

var testAudeme = {	list:[0,1,2,3,4,5],
	answer:"Test",
	fixedOrder:true,
	hint:"transportation"
	//difficulty:1
}

var openingDuration = 1100; //duration of the opening animation

var playerColor = [
{	"name":"red",
	"hex":"#ea0000"
}, 

{	"name":"blue",
	"hex":"#42a5f5"
}, 

{	"name":"green",
	"hex":"#AEEA00"
}
] 
var playerColorHex = ["#ea0000", "#42a5f5", "#AEEA00"]//colors of three player