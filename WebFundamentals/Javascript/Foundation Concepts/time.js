var HOUR = 8;
var MINUTE = 50;
var PERIOD = "AM";


if(MINUTE < 30) {
  if(PERIOD == "AM") {
    console.log("It's just after",HOUR,"in the morning.");
  } else {
    console.log("It's just after",HOUR,"in the evening.");
  }
} else {
  if(PERIOD == "AM") {
    console.log("It's almost",HOUR+1,"in the morning.");
  } else {
    console.log("It's almost",HOUR+1,"in the evening.");
  }
}
