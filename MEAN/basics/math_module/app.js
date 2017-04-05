// Require my math library:
var my_math = require('./mathlib.js');


// Now test it.
var add = my_math.add(15,4);
console.log("\n 15 + 4 = "+add);
var multiply = my_math.multiply(60,6);
console.log("\n 60 * 6 = "+multiply);
var square = my_math.square(12);
console.log("\n 12^2 = "+square);
var random_ = my_math.random(73,1078);
console.log("\n A random number between 73 & 1078: "+random_+"\n");
