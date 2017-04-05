// Vehicle Object Constructor:
function VehicleConstructor(name, wheels, passengers, speed){
  this.name = name;
  this.wheels = wheels;
  this.passengers = passengers;
  this.speed = speed;
  this.distance_travelled = 0;

  // Generate a random VIN.
  var vin_calculator = function(){
    /* A VIN must be 17 characters long, with this format:
       (Where N = number and L = letter)
       NLLLLNNLLLLNNNNNN
       Therefore, we must generate it in a way that may look inefficient,
       but it works quite well.  */
    var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    var returnMe = (Math.floor(Math.random() * 9 + 1))+"";
    for(var i=0; i < 4; i++){
      returnMe += letters.charAt(Math.floor(Math.random() * letters.length));
    }
    returnMe += (Math.floor(Math.random() * 9 + 1))+""+(Math.floor(Math.random() * 9 + 1));
    for(var i=0; i < 4; i++){
      returnMe += letters.charAt(Math.floor(Math.random() * letters.length));
    }
    for(var i=0; i < 6; i++){
      returnMe += (Math.floor(Math.random() * 9 + 1));
    }
    return returnMe;
  }
  this.vin = vin_calculator();


}

// Prototype additions to VehicleConstructor:
// Creating an instance method
VehicleConstructor.prototype.checkVIN = function(){
  console.log("I am a "+this.name+" and my VIN is "+this.vin+".");
  return this; // have this method return its own object
}
// Creating an instance method
VehicleConstructor.prototype.updateDistanceTravelled = function(){
  this.distance_travelled += this.speed;
  return this; // have this method return its own object
}
// Creating an instance method
VehicleConstructor.prototype.move = function(){
  this.updateDistanceTravelled();
  this.makeNoise();
  return this; // have this method return its own object
}
// Creating an instance method
VehicleConstructor.prototype.checkMiles = function(){
  console.log(this.name+" Total Distance Travelled: "+this.distance_travelled);
  return this; // have this method return its own object
}
// Creating an instance method
VehicleConstructor.prototype.makeNoise = function(){
  console.log("HOOOOONNKKK!");
  return this; // have this method return its own object
}
// Creating an instance method
VehicleConstructor.prototype.identify = function(){
  console.log("I am a "+this.name+". I have "+this.wheels+" wheels and I currently have "+this.passengers+" passengers. I move at "+this.speed+" MPH.");
  return this; // have this method return its own object
}

// Creating instance objects:
var Bike = new VehicleConstructor("Bike", 2, 2, 12);
var Sedan = new VehicleConstructor("Sedan", 4, 5, 42);
var Bus = new VehicleConstructor("Bus", 4, 17, 25);

// Updating / adding functions for specific instances, as requested:
Bike.makeNoise = function() {
  console.log("ring ring!");
  return this;
}
Sedan.makeNoise = function() {
  console.log("Honk Honk!");
  return this;
}
Bus.pickUp = function(num) {
  this.passengers += num;
  console.log(num+" passengers have been added to the total passenger count for this "+this.name+".");
  return this;
}

// Do all the methods! Because they all return themselves, we can chain the methods.
console.log("\n\n"); // Gaps to make it pretty.
Bike.identify().makeNoise().move().move().move().checkMiles().checkVIN();
console.log("\n\n");
Sedan.identify().makeNoise().move().move().move().checkMiles().checkVIN();
console.log("\n\n");
Bus.identify().makeNoise().pickUp(5).identify().move().move().move().checkMiles().checkVIN();
console.log("\n"); // stop gapping.
