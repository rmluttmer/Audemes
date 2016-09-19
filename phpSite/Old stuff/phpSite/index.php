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
<table width="648" border="0" cellspacing="10" cellpadding="10">
<tr><td>
<center><h1>Audemes</h1></center>
</td></tr>
<tr><td>
<p></p><p></p><p></p><p></p>
</td></tr>
<!--------------------------------------->
<tr><td>
<?php
$wave_file1 = 'audeme (1).aif'; //This is the example one.
//Generate/Get wave file name without .wav extension format.

echo "<embed src=\"$wave_file1\" autostart=false width=0 height=0 id=\"sound1\" enablejavascript=\"true\">";
?>
<form>
<input type="button" value="Play Audeme 1" onClick="EvalSound('sound1')">
</form>
</td></tr>
<!--------------------------------------->
<tr><td>
	<?php
		$wave_file2 = 'audeme (2).aif';
		echo "<embed src=\"$wave_file2\" autostart=false width=0 height=0 id=\"sound2\" enablejavascript=\"true\">";
	?>

	<form>
		<input type="button" value="Play Audeme 2" onClick="EvalSound('sound2')">
	</form>
</td></tr>
<!--------------------------------------->
<tr><td>
	<?php
		$wave_file3 = 'audeme (3).aif';
		echo "<embed src=\"$wave_file3\" autostart=false width=0 height=0 id=\"sound3\" enablejavascript=\"true\">";
	?>
	<form>
		<input type="button" value="Play Audeme 3" onClick="EvalSound('sound3')">
	</form>
</td></tr>
<!--------------------------------------->
<tr><td>
	<?php
	
		$wave_file4 = 'audeme (4).aif';
		echo "<embed src=\"$wave_file4\" autostart=false width=0 height=0 id=\"sound4\" enablejavascript=\"true\">";
	?>
	<form>
		<input type="button" value="Play Audeme 4" onClick="EvalSound('sound4')">
	</form>
</td></tr>
<!--------------------------------------->
<tr><td>
	<?php
		$wave_file5 = 'Music-Music-Serial_1.aif'; 
		echo "<embed src=\"$wave_file5\" autostart=false width=0 height=0 id=\"sound5\" enablejavascript=\"true\">";
	?>
	<form>
		<input type="button" value="Play Audeme 5" onClick="EvalSound('sound5')">
	</form>
</td></tr>
<!--------------------------------------->
<tr><td>
<p></p>
</td></tr>
</table>
</div>
</body>
</html> 

