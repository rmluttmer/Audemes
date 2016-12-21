var is_safari = navigator.userAgent.search("Safari") >= 0;
var is_chrome = navigator.userAgent.search("Chrome") >= 0;

if (!is_safari && !is_chrome) {
    alert("Your web browser will not work with the audeme web site.  Please use Google Chrome or Apple Safari.");
}