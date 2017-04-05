$(document).ready(function() {
  $(".btn-lg").click(function(){
    if($(this).attr("name")=="blue"){
      $(this).css({"background":"rgb(96,0,0)"});
      $(this).attr({"name":"red"});
    } else {
      $(this).css({"background":"rgb(38,81,117)"});
      $(this).attr({"name":"blue"});
    }

  });

  $(".btn-lg").hover(
  function() {
    $( this ).css({"background":"rgb(0,96,67)"});
  }, function() {
    if($(this).attr("name")=="blue"){
      $(this).css({"background":"rgb(38,81,117)"});
    } else {
      $(this).css({"background":"rgb(96,0,0)"});
    }
  }
);



});
