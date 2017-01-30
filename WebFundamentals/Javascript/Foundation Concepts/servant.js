
function forAFewBillion () {
  var money = 0.01;
  var days = 1;
  while(days <= 30) {
    money = money*2;
    days++;
  }
  console.log("The reward was $"+money,"after",days-1,"days.");
  money = 0.01;
  days = 1;
  while(money <= 10000) {
    money = money*2;
    days++;
  }
  console.log("It would take",days-1,"days for the servant to make $10,000+.");
  money = 0.01;
  days = 1;
  while(money <= 1000000000) {
    money = money*2;
    days++;
  }
  console.log("It would take",days-1,"days for the servant to make 1 billion+.");
  money = 0.01;
  days = 1;
  while(money < Infinity) {
    money = money*2;
    days++;
  }
  console.log("It would take",days-1,"days for the servant to make JavaScript Ininity+.");
}

forAFewBillion();
