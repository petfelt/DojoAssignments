var addQuarters;

function slotGame(quarters,limit) {
  ogQuarters = quarters;
  if(limit === undefined) {
    limit = 0;
  }
  while(quarters > 0) {
    if(limit !== 0) {
      if(quarters >= 40) {
        if(Math.floor(Math.random()*100)+1 === 1) {
          addQuarters = Math.trunc(Math.random()*50)+51;
          quarters += addQuarters;
          if(ogQuarters+limit <= quarters){
            console.log("You won! You got",addQuarters,"more quarters! You now have",quarters,"quarters! You feel like you've won enough quarters, so you stop playing.");
            return quarters;
          } else {
            console.log("You won! You got",addQuarters,"more quarters! You now have",quarters,"quarters!");
          }
        }
      } else {
        quarters++;
        console.log("You've hit your lower limit of",quarters,"quarters and decided to stop playing.");
        return quarters;
      }
    } else {
      if(Math.floor(Math.random()*100)+1 === 1) {
          addQuarters = Math.trunc(Math.random()*50)+51;
          quarters += addQuarters;
          console.log("You won! You got",addQuarters,"more quarters! You now have",quarters,"quarters! You won some quarters and have no limit, so you want to stop playing.");
          return quarters;
      }
    }
    quarters--;
  }
  return quarters;
}

console.log("Game 1 (200 quarters, play until 240 quarters or 40 quarters):");
console.log("Game 1: You ended up with "+slotGame(200,40)+" quarters.");
console.log("");
console.log("Game 2 (200 quarters, no limit, play until win):");
console.log("Game 2, no limit: You ended up with "+slotGame(200)+" quarters.");
