<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Defaultsplash.aspx.cs" Inherits="Defaultsplash" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<div1>
<head runat="server">
    <title>Welcome to Audemes</title>
    <link rel="stylesheet" type="text/css" href="/css/splash.css"/>
</head>
<body>

<form runat="server">
    <asp:CheckBox runat="server" CSSclass="cookietext" ID="chkSkipIntro" Text="Never Show Splash Page" /><br />
   
    <asp:LinkButton runat="server" CSSclass="cookietext" ID="lnkSkipIntro" OnClick="skipIntro">Skip this intro </asp:LinkButton>
</form>

<h1>Audemes</h1>
<p>Welcome to the audemes site. Audemes are brief audio collages that combine sounds to represent ideas. For example, the sounds of a dog barking, a cat meowing, and rainfall can combine to create a 3 to 4 second audeme that signifies the idea "It's raining cats and dogs."  Try a science riddle by playing the audio file below.  Good luck!
</p><br/>

<div id="audiosplash">

        <p><audio id="solarenergy_riddle" controls="controls"><source src="/MP3s/riddle_samples/solarenergy_riddle.mp3" type="audio/mpeg"></audio></p>
                   	<br/> 
                   	 
    </div>

    <ul>
    <li><a href="../games/default.aspx">GAMES: To play, click here</a></li>
    <li><a href="../dictionary/Default.aspx">DICTIONARY: To search all of our audemes, click here</a></li>
    <li><a href="../DefaultSusan.aspx">ABOUT AUDEMES: To learn more about audemes, click here</a></li>
    <li><a href="../createAccount.aspx">LOCKER: To store your favorites, create an account here</a></li>
</ul>

<br />

<p>OR>>>></p>

<p>Audemes, pronounced "awe deems," are brief audio collages that combine sounds to represent ideas. For example, the sounds of a dog barking, a cat meowing, and rainfall can combine to create a 3 to 4 second audeme that signifies the idea "It's raining cats and dogs."  Try one by playing the audio file below.  Here's a hint: It's another idiomatic expression. When you think you've got it, play the next audio file to hear the answer.  Good luck!
</p><br/>

    <div id="audiosplash">

        <p><audio id="Explosive Cinder Cone Volcano" controls="controls"><source src="/MP3s/audemes/Explosive Cinder Cone Volcano.mp3" type="audio/mpeg"></audio></p>
                   	<br/> 
        <p><audio id="Explosive Cinder Cone Volcano" controls="controls"><source src="/MP3s/audemes/Explosive Cinder Cone Volcano.mp3" type="audio/mpeg"></audio></p>
                   	 
    </div>

<ul>
    <li><a href="../games/default.aspx">GAMES: To play, click here</a></li>
    <li><a href="../dictionary/Default.aspx">DICTIONARY: To search all of our audemes, click here</a></li>
    <li><a href="../DefaultSusan.aspx">ABOUT AUDEMES: To learn more about audemes, click here</a></li>
    <li><a href="../createAccount.aspx">LOCKER: To store your favorites, create an account here</a></li>
</ul>


</body>
</div1>
</html>
