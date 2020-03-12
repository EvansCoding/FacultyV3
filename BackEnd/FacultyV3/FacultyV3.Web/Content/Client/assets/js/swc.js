$(document).ready(function() {
    var id = "#dialog";

    //Get the screen height and width
    var maskHeight = $(document).height();
    var maskWidth = $(document).width();

    //Set heigth and width to mask to fill up the whole screen
    $("#mask").css({ width: "100%", height: "100vh" });
    //$("body").css({ overflow: "hidden" });
    jQuery("html, body").animate({ scrollTop: 0 }, 800);
    //transition effect
    $("#mask").fadeIn(300);
    $("#mask").fadeTo("slow", 0.4);

    //Get the window height and width
    var winH = $(window).height();
    var winW = $(window).width();

    //Set the popup window to center
    $(id).css("top", "20%");
    $(id).css("left", "0");

    //transition effect
    $(id).fadeIn(1000);

    //if close button is clicked
    $(".window .close").click(function(e) {
        //Cancel the link behavior
        e.preventDefault();
        $("body").removeAttr("style");
        $("#mask").hide();
        $(".window").hide();
    });

    //if mask is clicked
    $("#mask").click(function() {
        $(this).hide();
        $(".window").hide();
        $("body").removeAttr("style");
    });

    $(".window").click(function() {
        $("#mask").hide();
        $(this).hide();
        $("body").removeAttr("style");
    });
});