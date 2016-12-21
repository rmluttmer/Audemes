<html>
<head>
<script>
function EvalSound(soundobj) {
  var thissound=document.getElementById(soundobj);
  thissound.Play();
}
</script>

</head>
<body>

	
<div align="center">
<table width="660" border="1" cellspacing="0" cellpadding="15" rules="cols">
<tr><td colspan="2";>
<center><h1>Audemes</h1></center>
</td></tr>

	<tr align ="center"><td> 
		<b>Audeme </b></br> <i>(Push to Play)</i> </td><td><b>Concepts</b>
	</td></tr>
<!--------------------------------------->

	<tr><td width=220>
		<?php
		$wave_file1 = 'Music-Music-Serial_1.aif'; //This is the example one.
		//Generate/Get wave file name without .wav extension format.

		echo "<embed src=\"$wave_file1\" autostart=false width=0 height=0 id=\"sound1\" enablejavascript=\"true\">";
		?>

			<input type="button" value="Music-Music-Serial 1" onClick="EvalSound('sound1')">
	</td>
	<td>
			a.	Future to past </br>
			b.	New wave trendy to old-fashioned</br>
			c.	Dance ongoing social customs
	</td>
	</tr>
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file2 = 'Music-Music-Serial_2.aif'; //This is the example one.
		echo "<embed src=\"$wave_file2\" autostart=false width=0 height=0 id=\"sound2\" enablejavascript=\"true\">";
		?>

			<input type="button" value="Music-Music-Serial 2" onClick="EvalSound('sound2')">

	</td>
	<td><p>
			a.	Swinging - into the air </br>
			b.	Angelic movement</br>
			c.	Action into calm
		</p>	
	</td>
	</tr>

<!--------------------------------------->

<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file3 = 'Music-Music-Serial_3.aif'; //This is the example one.
		echo "<embed src=\"$wave_file3\" autostart=false width=0 height=0 id=\"sound3\" enablejavascript=\"true\">";
		?>

			<input type="button" value="Music-Music-Serial 3" onClick="EvalSound('sound3')" size="100";>

	</td>
	<td>
			a.	Majestic-hipster young guy </br>
			b.	Prince Harry  (young, hip Prince of England)</br>
			c.	Groovy Cool Establishment
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file4 = 'Music-Music-Serial_4.aif'; //This is the example one.
		echo "<embed src=\"$wave_file4\" autostart=false width=0 height=0 id=\"sound4\" enablejavascript=\"true\">";
		?>

			<input type="button" value="Music-Music-Serial 4" onClick="EvalSound('sound4')" size="100";>

	</td>
	<td>
			a.	Calming the Rush</br>
			b.	Great excitement then relaxing </br>
			c.	Blizzard into Spring
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file5 = 'Music-Music-Serial_5.aif'; //This is the example one.
		echo "<embed src=\"$wave_file5\" autostart=false width=0 height=0 id=\"sound5\" enablejavascript=\"true\">";
		?>

			<input type="button" value="Music-Music-Serial 5" onClick="EvalSound('sound5')" size="100";>

	</td>
	<td>

			a.	Grandpa and young grandson</br>
			b.	Mice running away from Elephant</br>
			c.	Escape from the South
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file6 = 'Music-SFX-Serial_1.aif'; //This is the example one.
		echo "<embed src=\"$wave_file6\" autostart=false width=0 height=0 id=\"sound6\" enablejavascript=\"true\">";
		?>

			<input type="button" value="Music-SFX-Serial 1" onClick="EvalSound('sound6')" size="100";>

	</td>
	<td>

			a.	Partying till the morning</br>
			b.	Urbanizing the village</br>
			c.	Neighbors complain about loud music		
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file7 = 'Music-SFX-Serial_2.aif'; //This is the example one.
		echo "<embed src=\"$wave_file7\" autostart=false width=0 height=0 id=\"sound7\" enablejavascript=\"true\">";
		?>

			<input type="button" value="Music-SFX-Serial 2" onClick="EvalSound('sound7')" size="100";>

	</td>
	<td>
			a.	Designing Architecture</br>
			b.	Bringing order to something</br>
			c.	Home building
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file8 = 'Music-SFX-Serial_3.aif'; //This is the example one.
		echo "<embed src=\"$wave_file8\" autostart=false width=0 height=0 id=\"sound8\" enablejavascript=\"true\">";
		?>

			<input type="button" value="Music-SFX-Serial 3" onClick="EvalSound('sound8')" size="100";>

	</td>
	<td>
			a.	Earthquake </br>
			b.	Trip to the carnival</br>
			c.	Calm before the storm

	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file9 = 'Music-SFX-Serial_4.aif'; //This is the example one.
		echo "<embed src=\"$wave_file9\" autostart=false width=0 height=0 id=\"sound9\" enablejavascript=\"true\">";
		?>

			<input type="button" value="Music-SFX-Serial 4" onClick="EvalSound('sound9')" size="100";>

	</td>
	<td>

			a.	Trip Overseas</br>
			b.	End of the Adventure</br>
			c.	Disappearing Act
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file10 = 'Music-SFX-Serial_5.aif'; //This is the example one.
		echo "<embed src=\"$wave_file10\" autostart=false width=0 height=0 id=\"sound10\" enablejavascript=\"true\">";
		?>

			<input type="button" value="Music-SFX-Serial 5" onClick="EvalSound('sound10')" size="100";>

	</td>
	<td>
			a.	Titanic</br>
			b.	Government waste</br>
			c.	Kid playing in the bathtub
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file11 = 'SFX-Music-Serial_1.aif'; //This is the example one.
		echo "<embed src=\"$wave_file11\" autostart=false width=0 height=0 id=\"sound11\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-Music-Serial 1" onClick="EvalSound('sound11')" size="100";>

	</td>
	<td>
			a.	Birds flocking in the air</br>
			b.	Hitchcock</br>
			c.	Mother calms her complaining children

	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file12 = 'SFX-Music-Serial_2.aif'; //This is the example one.
		echo "<embed src=\"$wave_file12\" autostart=false width=0 height=0 id=\"sound12\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-Music-Serial 2" onClick="EvalSound('sound12')" size="100";>

	</td>
	<td>
			a.	Flying car</br>
			b.	Hybrid car</br>
			c.	Going on a date
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file13 = 'SFX-Music-Serial_3.aif'; //This is the example one.
		echo "<embed src=\"$wave_file13\" autostart=false width=0 height=0 id=\"sound13\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-Music-Serial 3" onClick="EvalSound('sound13')" size="100";>

	</td>
	<td>
			a.	Chicago Fire</br>
			b.	Resolving an Emergency</br>
			c.	Post-Disaster Relief
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file14 = 'SFX-Music-Serial_4.aif'; //This is the example one.
		echo "<embed src=\"$wave_file14\" autostart=false width=0 height=0 id=\"sound14\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-Music-Serial 4" onClick="EvalSound('sound14')" size="100";>

	</td>
	<td>
			a.	Downfall of the American auto industry</br>
			b.	Leaving in sorrow</br>
			c.	Running into Trouble
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file15 = 'SFX-Music-Serial_5.aif'; //This is the example one.
		echo "<embed src=\"$wave_file15\" autostart=false width=0 height=0 id=\"sound15\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-Music-Serial 5" onClick="EvalSound('sound15')" size="100";>

	</td>
	<td>
			a.	Chinese sense of time</br>
			b.	Ancient Asian wisdom</br>
			c.	Tea time
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file16 = 'SFX-Music-Parallel_1.aif'; //This is the example one.
		echo "<embed src=\"$wave_file16\" autostart=false width=0 height=0 id=\"sound16\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-Music-Parallel 1" onClick="EvalSound('sound16')" size="100";>

	</td>
	<td>
			a.	Beach Party</br>
			b.	Happy Islands</br>
			c.	Summer refreshments
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file17 = 'SFX-Music-Parallel_2.aif'; //This is the example one.
		echo "<embed src=\"$wave_file17\" autostart=false width=0 height=0 id=\"sound17\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-Music-Parallel 2" onClick="EvalSound('sound17')" size="100";>

	</td>
	<td>
			a.	Middle Eastern turmoil</br>
			b.	Difficult to understand the Middle East</br>
			c.	North African military Raid
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file18 = 'SFX-Music-Parallel_3.aif'; //This is the example one.
		echo "<embed src=\"$wave_file18\" autostart=false width=0 height=0 id=\"sound18\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-Music-Parallel 3" onClick="EvalSound('sound18')" size="100";>

	</td>
	<td>
			a.	Economic cycles </br>
			b.	Africa’s impoverished economy</br>
			c.	Street music
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file19 = 'SFX-Music-Parallel_4.aif'; //This is the example one.
		echo "<embed src=\"$wave_file19\" autostart=false width=0 height=0 id=\"sound19\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-Music-Parallel 4" onClick="EvalSound('sound19')" size="100";>

	</td>
	<td>
			a.	Immigrants crossing the ocean</br>
			b.	Slave trade</br>
			c.	Seaside village
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file20 = 'SFX-Music-Parallel_5.aif'; //This is the example one.
		echo "<embed src=\"$wave_file20\" autostart=false width=0 height=0 id=\"sound20\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-Music-Parallel 5" onClick="EvalSound('sound20')" size="100";>

	</td>
	<td>
			a.	Daily anxiety</br>
			b.	Racing for nothing</br>
			c.	Accelerating pace of life
	</td>
	</tr>

<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file21 = 'Music-Music-Parallel_1.aif'; //This is the example one.
		echo "<embed src=\"$wave_file21\" autostart=false width=0 height=0 id=\"sound21\" enablejavascript=\"true\">";
		?>

			X<input type="button" value="Music-Music-Parallel 1" onClick="EvalSound('sound21')" size="100";>

	</td>
	<td>
			a.	Everyday Life</br>
			b.	Stubborn argument</br>
			c.	Bus ride
	</td>
	</tr>
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file22 = 'Music-Music-Parallel_2.aif'; //This is the example one.
		echo "<embed src=\"$wave_file22\" autostart=false width=0 height=0 id=\"sound22\" enablejavascript=\"true\">";
		?>

			<input type="button" value="Music-Music-Parallel 2" onClick="EvalSound('sound22')" size="100";>

	</td>
	<td>
			a.	Secret admirer</br>
			b.	Scary walk</br>
			c.	Searching for clues
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file23 = 'Music-Music-Parallel_3.aif'; //This is the example one.
		echo "<embed src=\"$wave_file23\" autostart=false width=0 height=0 id=\"sound23\" enablejavascript=\"true\">";
		?>

			X<input type="button" value="Music-Music-Parallel 3" onClick="EvalSound('sound23')" size="100";>

	</td>
	<td>
			a.	Nervous calculation</br>
			b.	Hurrying to finish </br>
			c.	Busy bees
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file24 = 'Music-Music-Parallel_4.aif'; //This is the example one.
		echo "<embed src=\"$wave_file24\" autostart=false width=0 height=0 id=\"sound24\" enablejavascript=\"true\">";
		?>

			<input type="button" value="Music-Music-Parallel 4" onClick="EvalSound('sound24')" size="100";>

	</td>
	<td>
			a.	Rainstorm</br>
			b.	Cleaning up a mess</br>
			c.	Frustrating discussion
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file25 = 'Music-Music-Parallel_5.aif'; //This is the example one.
		echo "<embed src=\"$wave_file25\" autostart=false width=0 height=0 id=\"sound25\" enablejavascript=\"true\">";
		?>

			<input type="button" value="Music-Music-Parallel 5" onClick="EvalSound('sound25')" size="100";>

	</td>
	<td>
			a.	Falling into depression</br>
			b.	Walking with chained feet</br>
			c.	Malfunctioning machinery
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file26 = 'SFX-SFX-Parallel_1.aif'; //This is the example one.
		echo "<embed src=\"$wave_file26\" autostart=false width=0 height=0 id=\"sound26\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-SFX-Parallel 1" onClick="EvalSound('sound26')" size="100";>

	</td>
	<td>
			a.	Burning the barn</br>
			b.	Crazy farm</br>
			c.  Vandals at the zoo
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file27 = 'SFX-SFX-Parallel_2.aif'; //This is the example one.
		echo "<embed src=\"$wave_file27\" autostart=false width=0 height=0 id=\"sound27\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-SFX-Parallel 2" onClick="EvalSound('sound27')" size="100";>

	</td>
	<td>
			a.	Chat by the fire place</br>
			b.	Lost in the forest</br>
			c.	Play fighting with sticks
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file28 = 'SFX-SFX-Parallel_3.aif'; //This is the example one.
		echo "<embed src=\"$wave_file28\" autostart=false width=0 height=0 id=\"sound28\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-SFX-Parallel 3" onClick="EvalSound('sound28')" size="100";>

	</td>
	<td>
			a.	Great expectations</br>
			b.	Victory</br>
			c.	Raising a champion
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file29 = 'SFX-SFX-Parallel_4.aif'; //This is the example one.
		echo "<embed src=\"$wave_file29\" autostart=false width=0 height=0 id=\"sound29\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-SFX-Parallel 4" onClick="EvalSound('sound29')" size="100";>

	</td>
	<td>
			a.	Rusty movement</br>
			b.	Opening the dark gate</br>
			c.	19th-century technology
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file30 = 'SFX-SFX-Parallel_5.aif'; //This is the example one.
		echo "<embed src=\"$wave_file30\" autostart=false width=0 height=0 id=\"sound30\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-SFX-Parallel 5" onClick="EvalSound('sound30')" size="100";>

	</td>
	<td>
			a.	Transformation</br>
			b.	Eternal bliss</br>
			c.	Immortality
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file31 = 'SFX-SFX-Serial_1.aif'; //This is the example one.
		echo "<embed src=\"$wave_file31\" autostart=false width=0 height=0 id=\"sound31\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-SFX-Serial 1" onClick="EvalSound('sound31')" size="100";>

	</td>
	<td>
			a.	Taking a pill</br>
			b.	Swallowing sand</br>
			c.	Thirsty mirage
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file32 = 'SFX-SFX-Serial_2.aif'; //This is the example one.
		echo "<embed src=\"$wave_file32\" autostart=false width=0 height=0 id=\"sound32\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-SFX-Serial 2" onClick="EvalSound('sound32')" size="100";>

	</td>
	<td>
			a.	Sending kisses</br>
			b.	Wind lover</br>
			c.	Pardon me while I kiss the sky
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file33 = 'SFX-SFX-Serial_3.aif'; //This is the example one.
		echo "<embed src=\"$wave_file33\" autostart=false width=0 height=0 id=\"sound33\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-SFX-Serial 3" onClick="EvalSound('sound33')" size="100";>

	</td>
	<td>
			a.	Missing the target</br>
			b.	Pennies in the water</br>
			c.	Plink plunk, sink sunk
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file34 = 'SFX-SFX-Serial_4.aif'; //This is the example one.
		echo "<embed src=\"$wave_file34\" autostart=false width=0 height=0 id=\"sound34\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-SFX-Serial 4" onClick="EvalSound('sound34')" size="100";>

	</td>
	<td>
			a.	Announcing the fight</br>
			b.	Pots overheating</br>
			c.	Empty mailboxes after email
	</td>
	</tr>

<!--------------------------------------->
<!--------------------------------------->
	<tr><td width=200>
		<?php
		$wave_file35 = 'SFX-SFX-Serial_5.aif'; //This is the example one.
		echo "<embed src=\"$wave_file35\" autostart=false width=0 height=0 id=\"sound35\" enablejavascript=\"true\">";
		?>

			<input type="button" value="SFX-SFX-Serial 5" onClick="EvalSound('sound35')" size="100";>

	</td>
	<td>
			a.	Washing the sins</br>
			b.	Burning a hole in the sky</br>
			c.	A cooling rain
	</td>
	</tr>

<!--------------------------------------->

<tr><td>
<p></p>
			</td></tr>
		</table>
	</div>
</body>
</html> 

