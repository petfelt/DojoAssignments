var daysUntilMyBirthday = 60;

function whileYouWait() {

if(daysUntilMyBirthday >= 30) {
  console.log(daysUntilMyBirthday,"days until my birthday. Such a long time... :(");
} else if (daysUntilMyBirthday === 0) {
  console.log("♪ღ♪*•.¸¸¸.•*¨¨*•.¸¸¸.•*•♪ღ♪¸.•*¨¨*•.¸¸¸.•*•♪ღ♪•*");
  console.log("♪ღ♪░H░A░P░P░Y░ B░I░R░T░H░D░A░Y░░♪ღ♪");
  console.log("*•♪ღ♪*•.¸¸¸.•*¨¨*•.¸¸¸.•*•♪¸.•*¨¨*•.¸¸¸.•*•♪ღ♪•«");
} else if (daysUntilMyBirthday < 5) {
  console.log(daysUntilMyBirthday,"DAYS UNTIL MY BIRTHDAY!! OH MY GOODNESS GRACIOUS ME!!");
} else {
    console.log(daysUntilMyBirthday,"days until my birthday! How exciting!");
}
}

whileYouWait();
