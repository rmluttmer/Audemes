//this file contains audeme riddle sequences used in the game
//mapping:
//"air"------->0
//"animal"------->1
//"earth"------->2
 
//"rising"------->3
//"inside"------->4
//"lowering"------->5
 
//"fire"------->6
//"machine"------->7 
//"water"------->8
 
//"big"------->9
//"cold"------->10
//"small"------->11
 
//"fast"------->12
//"process"------->13
//"slow"------->14
 
//"people"------->15
//"outside"------->16
//"time"------->17

//------------------------------------------------------------
//------------------------------------------------------------
//-------------------- level 1 riddles -----------------------
//------------------------------------------------------------
//------------------------------------------------------------
var sequenceList1 = [
{	list:[7,3,0], //the riddle sequence;
	answer:"AIRPLANE", //answer of this riddle
	fixedOrder:false,//whether this sequence has a fixed order
	hint:"transportation" //hint to this riddle
	//difficulty:1
},

{	list:[0,1],
	answer:"BIRD",
	fixedOrder:false,
	hint:"chrip chrip"
	//difficulty:1
},

{	list:[8,7],
	answer:"BOAT",
	fixedOrder:false,
	hint:"transportation"
	//difficulty:1
},

{	list:[6,8,4,7],
	answer:"GASOLINE",
	//difficulty:2
	fixedOrder:true,
	hint:"fuel"

},

{	list:[8,5,2],
	answer:"GROUND WATER",
	fixedOrder:false,
	hint:"well"
	//difficulty:2
},

{	list:[6,8,4,2],
	answer:"MAGMA",
	fixedOrder:true,
	hint:"geology"
//difficulty:2
},

{	list:[8,4,1],
	answer:"BLOOD",
	fixedOrder:true,
	hint:"biology"
	//difficulty:2
},

{	list:[7,5,8],
	answer:"SUBMARINE",
	fixedOrder:false,
	hint:"transportation"
	//difficulty:2
},

{	list:[6,8,4,1],
	answer:"MAMMAL",
	fixedOrder:true,
	hint:"animal type"
	//difficulty:2
},

{	list:[3,3,3,2],
	answer:"PLANET",
	fixedOrder:false,
	hint:"orbit"
	//difficulty:3
},

{	list:[5,2,6],
	answer:"GEOTHERMAL",
	fixedOrder:false,
	hint:"energy source"
	//difficulty:3
},

{	list:[8,1],
	answer:"FISH",
	fixedOrder:false,
	hint:"animal type"
	//difficulty:1
},

{	list:[8,6,0],
	answer:"STEAM",
	fixedOrder:true,
	animal:"vapor"
	//difficulty:2
},

{	list:[6,0,3,7],
	answer:"HOT AIR BALOON",
	fixedOrder:false,
	hint:"transportation"
	//difficulty:3
},

{	list:[0,4,1],
	answer:"OXYGEN",
	fixedOrder:true,
	hint:"breathe",
		//difficulty:2
},

{	list:[8,5,5],
	answer:"WATERFALL",
	fixedOrder:false,
	hint:"geological feature"
	//difficulty:2
},

{	list:[2,8,5],
	answer:"MUDSLIDE",
	fixedOrder:false,
	hint:"disaster"
	//difficulty:3
},

{	list:[6,7],
	answer:"FIRE ENGINE",
	fixedOrder:false,
	hint:"vehicle"
	//difficulty:2
},

{	list:[6,0],
	answer:"SMOKE",
	fixedOrder:false,
	hint:"cloud"
	//difficulty:1
},

{	list:[6,8,2,3],
	answer:"VOLCANO",
	fixedOrder:false,
	//difficulty:3
	hint:"Vesuvius"
},

{	list:[1,4,2],
	answer:"MOLE",
	fixedOrder:true,
	hint:"tunnels"
	//difficulty:2
},

{	list:[2,1,1],
	answer:"ZOO/ECOSYSTEM",
	fixedOrder:true,
	hint:"interconnected"
	//difficulty:3
},

{	list:[6,1,3,0],
	answer:"DRAGON",
	fixedOrder:false,
	hint:"mythological"
	//difficulty:3
},

{	list:[8,3,5,6],
	answer:"WAVE ENERGY",
	fixedOrder:true,
	hint:"energy source"
	//difficulty:3
},

{	list:[8,5,6],
	answer:"HYDROELECTRICITY",
	fixedOrder:false,
	hint:"energy source"
	//difficulty:3
},

{	list:[8,5,6,7],
	answer:"TURBINE",
	fixedOrder:false,
	hint:"generator"
	//difficulty:3
},

{	list:[7,5,3,2],
	answer:"SHOVEL",
	fixedOrder:true,
	hint:"tool"
	//difficulty:3
},

{	list:[0,6],
	answer:"WIND ENERGY",
	fixedOrder:false,
	hint:"energy source"
	//difficulty:3
},

{	list:[0,6,7],
	answer:"WINDMILL",
	fixedOrder:false,
	hint:"generator"
	//difficulty:3
},

{	list:[0,6,7,1],
	answer:"WIND FARM",
	fixedOrder:false,
	hint:"energy field"
	//difficulty:3
},

{	list:[8,1,6],
	answer:"ELECTRIC EEL",
	fixedOrder:true,
	hint:"shocking"
	//difficulty:3
},

{	list:[6,0,7,4],
	answer:"FURNACE",
	fixedOrder:false,
	hint:"home"
	//difficulty:3
},

{	list:[7,5,4,2],
	answer:"OIL WELL",
	fixedOrder:true,
	hint:"drill"
	//difficulty:3
},

{	list:[6,8,3],
	answer:"GEYSER",
	fixedOrder:false,
	hint:"geological feature"
	//difficulty:3
},

{	list:[0,4,1,3],
	answer:"BELCH",
	fixedOrder:true,
	hint:"biological process"
	//difficulty:3
},

{	list:[0,4,2],
	answer:"NATURAL GAS",
	fixedOrder:true,
	hint:"energy source"
},

{	list:[6,6,8],
	answer:"BOIL",
	fixedOrder:false,
	hint:"tea time"
},

{	list:[3,5,2,1],
	answer:"BUNNY",
	fixedOrder:true,
	hint:"what's up doc?"
},

{	list:[3,5,2,1],
	answer:"BUNNY",
	fixedOrder:true,
	hint:"what's up doc?"
},

{	list:[3,5,8,2,1],
	answer:"FROG",
	fixedOrder:true,
	hint:"ribbit"
},

{	list:[3,5,3,5,8],
	answer:"TIDE",
	fixedOrder:true,
	hint:"ebb and flow"
},

{	list:[5,3,5,0,7],
	answer:"HELICOPTER",
	fixedOrder:true,
	hint:"hovering"
},

{	list:[5,3,5,3,7],
	answer:"SPRING",
	fixedOrder:true,
	hint:"boing boing"
},

{	list:[5,4,2],
	answer:"CAVE/MINE",
	fixedOrder:true,
	hint:"spelunk"
},


{	list:[5,4,2,0,1],
	answer:"BAT",
	fixedOrder:true,
	hint:"sonar"
},

{	list:[8,5,6,7],
	answer:"FIRE TRUCK",
	fixedOrder:true,
	hint:"extinguish"
},

{	list:[4,7,6,0,5],
	answer:"EXHAUST FUMES",
	fixedOrder:true,
	hint:"cough cough"
},

{	list:[2,4,1,5,8],
	answer:"DIGESTION",
	fixedOrder:true,
	hint:"chew/swallow"
},

{	list:[3,3,2],
	answer:"MOUNTAIN",
	fixedOrder:true,
	hint:"geological feature"
},

{	list:[3,3,0,7],
	answer:"ROCKET",
	fixedOrder:true,
	hint:"blast off"
},

{	list:[0,4,6],
	answer:"OXYGEN",
	fixedOrder:true,
	hint:"breathe",
		//difficulty:2
},

{	list:[0,1,4,7],
	answer:"PARROT/PARAKEET",
	fixedOrder:true,
	hint:"pet",
},

{	list:[2,1,4,7],
	answer:"ZOO ANIMAL",
	fixedOrder:true,
	hint:"attraction",
},

{	list:[4,4,4,3],
	answer:"ELEMENT",
	fixedOrder:true,
	hint:"Periodic Table",
},

{	list:[8,2],
	answer:"BEACH/SHORE",
	fixedOrder:true,
	hint:"sandy",
}
]

//------------------------------------------------------------
//------------------------------------------------------------
//-------------------- level 2 riddles -----------------------
//------------------------------------------------------------
//------------------------------------------------------------

var sequenceList2 = [
{	list:[9,10,8,2],
	answer:"GLACIER",
	fixedOrder:true,
	hint:"geological feature"
	//difficulty:3
},

{	list:[11,11,7],
	answer:"MICROCHIP",
	fixedOrder:false,
	hint:"technology"
},

{	list:[3,3,9,10,2],
	answer:"ICE/GAS GIANT",
	fixedOrder:true,
	hint:"planet type"
},

{	list:[9,1,10,2],
	answer:"POLAR BEAR",
	fixedOrder:true,
	hint:"growl"
},

{	list:[10,4,7],
	answer:"REFRIGERATOR/FREEZER",
	fixedOrder:false,
	hint:"appliance"
},

{	list:[11,1,4,2],
	answer:"MOLE",
	fixedOrder:true,
	hint:"tunnels"
},

{	list:[11,11,1,0],
	answer:"INSECT",
	fixedOrder:false,
	hint:"buzz"
},

{	list:[9,9,9,8],
	answer:"OCEAN",
	fixedOrder:true,
	hint:"body of water"
},

{	list:[2,5,9,9,8],
	answer:"OCEAN FLOOR",
	fixedOrder:true,
	hint:"the deep"
},

{	list:[9,9,8],
	answer:"SEA",
	fixedOrder:true,
	hint:"body of water"
},

{	list:[9,9,9,2],
	answer:"CONTINENT",
	fixedOrder:true,
	hint:"land mass"
},

{	list:[9,9,2],
	answer:"COUNTRY",
	fixedOrder:true,
	hint:"on the map"
},

{	list:[1,10,8,4],
	answer:"COLD BLOODED ANIMAL",
	fixedOrder:true,
	hint:"animal type"
},

{	list:[8,11,2,8],
	answer:"ISLAND",
	fixedOrder:true,
	hint:"body of land"
},

{	list:[11,2,9,9,8],
	answer:"ISLAND",
	fixedOrder:true,
	hint:"body of land"
},

{	list:[10,10,11,8],
	answer:"ICE CUBE",
	fixedOrder:true,
	hint:"clink in the drink"
},

{	list:[10,10],
	answer:"FROZEN/ICE",
	fixedOrder:true,
	hint:"brrrrrrr"
},

{	list:[9,8],
	answer:"LAKE",
	fixedOrder:true,
	hint:"body of water"
},

{	list:[10,0,7],
	answer:"AIR CONDITIONING",
	fixedOrder:false,
	hint:"appliance"
},

{	list:[11,6,0,7],
	answer:"BLOW DRYER",
	fixedOrder:false,
	hint:"hot hair"
},

{	list:[11,6,8,4,7],
	answer:"THERMOS",
	fixedOrder:true,
	hint:"keeps warm"
},

{	list:[11,7,6,6,8],
	answer:"TEA KETTLE",
	fixedOrder:true,
	hint:"hot pot"
},

{	list:[11,6,7],
	answer:"MICROWAVE OVEN",
	fixedOrder:false,
	hint:"small appliance"
},


{	list:[9,9,1,2],
	answer:"ELEPHANT",
	fixedOrder:true,
	hint:"tusk"
},

{	list:[9,9,1,8],
	answer:"WHALE",
	fixedOrder:true,
	hint:"Moby"
},

{	list:[9,9,8,1],
	answer:"WHALE",
	fixedOrder:true,
	hint:"Moby"
},

{	list:[9,9,0,3,5],
	answer:"HURRICANE",
	fixedOrder:true,
	hint:"storm"
},

{	list:[9,9,10,0],
	answer:"POLAR VORTEX",
	fixedOrder:true,
	hint:"storm"
},


{	list:[11,8,7],
	answer:"SQUIRT GUN",
	fixedOrder:false,
	hint:"toy"
},


{	list:[9,9,6,2],
	answer:"FOREST FIRE",
	fixedOrder:true,
	hint:"natural disaster"
},

{	list:[9,9,8,2],
	answer:"FLOOD",
	fixedOrder:true,
	hint:"natural disaster"
},

{	list:[9,9,9,10,2],
	answer:"ANTARTCICA",
	fixedOrder:true,
	hint:"land mass"
},

{	list:[11,8,7],
	answer:"FAUCET/HOSE/PUMP",
	fixedOrder:false,
	hint:"dispenser"
},


{	list:[11,10,8,0,5],
	answer:"SNOWFLAKE/HAIL",
	fixedOrder:false,
	hint:"weather"
},

{	list:[11,10,6],
	answer:"DEGREE(TEMPREATURE)",
	fixedOrder:false,
	hint:"weather measurement"
},

{	list:[11,10,6,7],
	answer:"THEROMOMETER",
	fixedOrder:false,
	hint:"weather measurement"
},

{	list:[11,6,7],
	answer:"CANDLE",
	fixedOrder:false,
	hint:"wax"
},

{	list:[11,0,8,5],
	answer:"RAINDROP",
	fixedOrder:false,
	hint:"weather"
},


{	list:[11,6,7],
	answer:"LIGHTBLUB",
	fixedOrder:false,
	hint:"electric"
},

{	list:[11,6,7,4,1],
	answer:"PACEMAKER",
	fixedOrder:true,
	hint:"close to the heart"
},


{	list:[9,9,9,0],
	answer:"ATMOSPHERE",
	fixedOrder:true,
	hint:"sky/air"
},

{	list:[9,9,0,3,5],
	answer:"WIND",
	fixedOrder:true,
	hint:"whoosh"
},

{	list:[11,0,3,5],
	answer:"BREATHING",
	fixedOrder:true,
	hint:"in/out"
},

{	list:[9,3,2,9],
	answer:"TREE",
	fixedOrder:true,
	hint:"plant"
},


{	list:[11,2],
	answer:"STONE",
	fixedOrder:true,
	hint:"hard as a..."
},


{	list:[11,11,2],
	answer:"SAND/DUST",
	fixedOrder:true,
	hint:"particles"
},


{	list:[11,11,11,2],
	answer:"ATOM",
	fixedOrder:true,
	hint:"tiny bit of matter"
},


{	list:[11,11,11,11,2],
	answer:"SUBATOMIC PARTICLE",
	fixedOrder:true,
	hint:"tiny bit of matter"
},

{	list:[9,2,5],
	answer:"AVALANCHE/MUDSLIDE",
	fixedOrder:false,
	hint:"disaster"
},

{	list:[3,3,9,9,2],
	answer:"JUPITER",
	fixedOrder:true,
	hint:"planet"
},

{	list:[2,9,3,5],
	answer:"EARTHQUAKE",
	fixedOrder:true,
	hint:"disaster"
},

{	list:[9,0,8,5],
	answer:"SHIP",
	fixedOrder:false,
	hint:"transportation"
},

{	list:[9,0,10,8,5],
	answer:"BLIZZARD",
	fixedOrder:false,
	hint:"severe weather"
},

{	list:[11,7,3,0],
	answer:"DRONE",
	fixedOrder:false,
	hint:"surveillance"
}
]

//------------------------------------------------------------
//------------------------------------------------------------
//-------------------- level 3 riddles -----------------------
//------------------------------------------------------------
//------------------------------------------------------------

var sequenceList3 = [
{	list:[1,2,13,5],
	answer:"DECOMPOSITION",
	fixedOrder:false,
	hint:"biological process"
},

{	list:[12,12,2,1],
	answer:"CHEETAH",
	fixedOrder:true,
	hint:"big cat"
},

{	list:[2,6,13,0],
	answer:"COMBUSTION",
	fixedOrder:true,
	hint:"up in smoke"
},

{	list:[8,10,10,13],
	answer:"FREEZE",
	fixedOrder:true,
	hint:"solidify"
},

{	list:[10,6,13,8],
	answer:"MELT",
	fixedOrder:true,
	hint:"ice in the sun"
	
},

{	list:[12,7,3,0],
	answer:"JET",
	fixedOrder:false,
	hint:"zoom"
},

{	list:[4,7,6,13],
	answer:"INTERNAL COMBUSTION ENGINE",
	fixedOrder:false,
	hint:"vroom"
},

{	list:[13,14,3,12],
	answer:"ACCELERATION",
	fixedOrder:true,
	hint:"speed"
},

{	list:[13,12,5,14],
	answer:"DECELERATION",
	fixedOrder:true,
	hint:"braking"
},

{	list:[1,13,1],
	answer:"METAMORPHASIS",
	fixedOrder:true,
	hint:"change"
},

{	list:[12,8,2],
	answer:"RIVER RAPIDS",
	fixedOrder:false,
	hint:"geological feature"
},

{	list:[12,2,7],
	answer:"CAR",
	fixedOrder:false,
	hint:"transportation"
},

{	list:[9,14,10,10,8],
	answer:"ICEBURG/GLACIER",
	fixedOrder:true,
	hint:"geological feature"
},

{	list:[12,8,7],
	answer:"SPEEDBOAT",
	fixedOrder:true,
	hint:"zoom splash"
},

{	list:[12,8,7,6],
	answer:"FIRE HOSE",
	fixedOrder:false,
	hint:"hydrant"
},

{	list:[8,13,0],
	answer:"EVAPORATION",
	fixedOrder:true,
	hint:"drying"
},

{	list:[0,13,8],
	answer:"CONDENSATION",
	fixedOrder:true,
	hint:"reverse of evaporing"
},

{	list:[8,6,13,0],
	answer:"BOILING",
	fixedOrder:false,
	hint:"bubble bubble"
},

{	list:[9,9,12,2,7],
	answer:"TRAIN",
	fixedOrder:true,
	hint:"transportation"
},

{	list:[12,12,2,7],
	answer:"SPORTS CAR",
	fixedOrder:true,
	hint:"zoom zoom"
},

{	list:[12,5],
	answer:"FALL",
	fixedOrder:false,
	hint:"movement"
},

{	list:[12,5,6,2],
	answer:"METEOR",
	fixedOrder:true,
	hint:"shower body"
},

{	list:[9,9,0,12,12],
	answer:"HURRICANE/TORNADO",
	fixedOrder:true,
	hint:"severe weather"
},

{	list:[1,13,11,9],
	answer:"GROWING",
	fixedOrder:true,
	hint:"maturing"
}
]

//------------------------------------------------------------
//------------------------------------------------------------
//-------------------- level 4 riddles -----------------------
//------------------------------------------------------------
//------------------------------------------------------------

var sequenceList4 = [

{	list:[17,7],
	answer:"TIME MACHINE",
	fixedOrder:false,
	hint:"sci-fi"
},

{	list:[9,9,15],
	answer:"GIANT",
	fixedOrder:true,
	hint:"Hagrid"
},

{	list:[0,7,15],
	answer:"PILOT",
	fixedOrder:true,
	hint:"occupation"
},

{	list:[14,17,1,9,13],
	answer:"EVOLUTION",
	fixedOrder:true,
	hint:"Darwin"
},

{	list:[9,16,2,1],
	answer:"TREE",
	fixedOrder:false,
	hint:"timber"
},

{	list:[9,9,2,7,15],
	answer:"CITY",
	fixedOrder:true,
	hint:"place"
},

{	list:[11,17],
	answer:"MINUTE",
	fixedOrder:false,
	hint:"wait a..."
},

{	list:[11,11,17],
	answer:"SECOND",
	fixedOrder:false,
	hint:"tick-tock"
},

{	list:[3,5,17],
	answer:"DAY",
	fixedOrder:true,
	hint:"seize the..."
},

{	list:[9,17],
	answer:"MONTH",
	fixedOrder:false,
	hint:"what's your sign?"
},

{	list:[9,9,17],
	answer:"MONTH",
	fixedOrder:false,
	hint:"calendar"
},

{	list:[9,9,9,17],
	answer:"CENTURY",
	fixedOrder:false,
	hint:"100"
},

{	list:[9,2,16,9,2],
	answer:"PLANETS",
	fixedOrder:true,
	hint:"astronomy"
},

{	list:[9,9,6,16,2],
	answer:"SUN/STAR",
	fixedOrder:true,
	hint:"astronomical body"
},

{	list:[15,5,2],
	answer:"DEATH",
	fixedOrder:false,
	hint:"biological event"
},

{	list:[9,15,13,7],
	answer:"CIVILIZATION",
	fixedOrder:true,
	hint:"human work"
},

{	list:[17,15,3],
	answer:"GROWING UP",
	fixedOrder:false,
	hint:"developing"
},

{	list:[17,13,2,9,11],
	answer:"EROSION",
	fixedOrder:true,
	hint:"geological feature"
},

{	list:[0,13,2,9,11],
	answer:"WIND EROSION",
	fixedOrder:true,
	hint:"geological feature"
},

{	list:[8,13,2,9,11],
	answer:"WATER EROSION",
	fixedOrder:true,
	hint:"geological feature"
},


{	list:[10,4,15],
	answer:"COLD/FLU",
	fixedOrder:true,
	hint:"achoo!"
},

{	list:[6,4,15],
	answer:"FEVER",
	fixedOrder:true,
	hint:"illness"
},

{	list:[5,0,4,15],
	answer:"FART",
	fixedOrder:true,
	hint:"biological process"
},

{	list:[11,17,7,15],
	answer:"WRIST WATCH",
	fixedOrder:false,
	hint:"technology"
},

{	list:[17,7,3],
	answer:"ALARM CLOCK",
	fixedOrder:false,
	hint:"dawn and yawn"
},

{	list:[12,17,16,15],
	answer:"FOOT RACE",
	fixedOrder:true,
	hint:"event"
},

{	list:[12,16,2,7,17],
	answer:"CAR RACE",
	fixedOrder:true,
	hint:"event"
},

{	list:[9,9,17,13,16],
	answer:"SEASON",
	fixedOrder:true,
	hint:"tis the..."
},

{	list:[14,14,17,4,15],
	answer:"BORED",
	fixedOrder:true,
	hint:"...to tears"
},

{	list:[12,12,17,4,15],
	answer:"FUN",
	fixedOrder:true,
	hint:"time flies, when..."
},

{	list:[12,15,17,16],
	answer:"SPORTS",
	fixedOrder:true,
	hint:"compete"
},

{	list:[12,15,17,10,16],
	answer:"WINTER SPORTS",
	fixedOrder:true,
	hint:"compete"
},

{	list:[17,13,4,15],
	answer:"MATURING",
	fixedOrder:true,
	hint:"developing"
},

{	list:[15,13,4,7],
	answer:"COMPUTER",
	fixedOrder:true,
	hint:"lap or desk"
},

{	list:[15,13,4,7],
	answer:"PSYCHOLOGY",
	fixedOrder:true,
	hint:"think/feel"
},

{	list:[12,13,4,15],
	answer:"SMART",
	fixedOrder:true,
	hint:"adjective"
},


{	list:[3,13,4,15],
	answer:"HAPPY/OPTIMISM",
	fixedOrder:true,
	hint:"looking up"
},

{	list:[5,13,4,15],
	answer:"SAD/PESSIMISM",
	fixedOrder:true,
	hint:"feeling down"
},

{	list:[12,12,13,4,15],
	answer:"GENIUS",
	fixedOrder:true,
	hint:"gifted"
},

{	list:[6,13,4,15],
	answer:"ANGER",
	fixedOrder:true,
	hint:"emotion"
},

{	list:[13,4,15,6,15],
	answer:"LOVE",
	fixedOrder:true,
	hint:"kisses"
},

{	list:[11,8,13,4,15],
	answer:"CRYING",
	fixedOrder:true,
	hint:"emotion response"
},

{	list:[17,5,5],
	answer:"ANCIENT HISTORY",
	fixedOrder:false,
	hint:"good ol'days"
},

{	list:[17,5,5,9,1],
	answer:"DINOSAUR",
	fixedOrder:false,
	hint:"Jurassic"
},

{	list:[17,5],
	answer:"PAST/HISTORY",
	fixedOrder:false,
	hint:"time period"
},

{	list:[17,3],
	answer:"FUTURE",
	fixedOrder:false,
	hint:"time period"
},

{	list:[12,7,16,2],
	answer:"SPACESHIP",
	fixedOrder:true,
	hint:"Star Wars"
},

{	list:[16,9,9,9,0],
	answer:"OUTER SPACE",
	fixedOrder:true,
	hint:"astronomy"
},

{	list:[16,9,9,0,15],
	answer:"AUSTRONAUT",
	fixedOrder:true,
	hint:"occupation"
},

{	list:[2,1,15],
	answer:"FARMER",
	fixedOrder:false,
	hint:"Old McDonald"
},

{	list:[9,2,15],
	answer:"GEOLOGIST",
	fixedOrder:false,
	hint:"occupation"
},

{	list:[11,11,11,2,15],
	answer:"CHEMIST",
	fixedOrder:true,
	hint:"occupation"
},

{	list:[8,7,15],
	answer:"SAILOR",
	fixedOrder:false,
	hint:"occupation"
},

{	list:[12,12,2,7,15],
	answer:"RACE CAR DRIVER",
	fixedOrder:true,
	hint:"occupation"
},

{	list:[9,12,2,7,15],
	answer:"TRUCK DRIVER/TRAIN CONDUCTOR",
	fixedOrder:true,
	hint:"occupation"
},

{	list:[17,5,15],
	answer:"HISTORIAN",
	fixedOrder:false,
	hint:"occupation"
},

{	list:[2,16,9,2],
	answer:"ASTEROID/MOON",
	fixedOrder:true,
	hint:"astronomy"
},

{	list:[6,15],
	answer:"FIREMAN",
	fixedOrder:false,
	hint:"occupation"
},

{	list:[15,4,12,2,7],
	answer:"DRIVER",
	fixedOrder:true,
	hint:"occupation"
}

]