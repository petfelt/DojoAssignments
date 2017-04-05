// Ninja Object:
function VehicleConstructor(myName, myWheels, myPassengers){
  var vehicle = {};

  vehicle.name = myName;
  vehicle.wheels = myWheels;
  vehicle.passengers = myPassengers;

  vehicle.makeNoise = function(){
    console.log("HOOOOONNKKK!");
  }

  vehicle.identify = function(){
    console.log("I am a "+this.name+". I have "+this.wheels+" wheels and I currently have "+this.passengers+" passengers.");
  }

  return vehicle;
}


var Bike = VehicleConstructor("Bike", 2, 2);
Bike.makeNoise = function() {
  console.log("ring ring!");
}
Bike.identify();
Bike.makeNoise();
var Sedan = VehicleConstructor("Sedan", 4, 5);
Sedan.makeNoise = function() {
  console.log("Honk Honk!");
}
Sedan.identify();
Sedan.makeNoise();
var Bus = VehicleConstructor("Bus", 4, 17);
Bus.identify();
Bus.makeNoise();
Bus.pickUp = function(num) {
  this.passengers += num;
  console.log(num+" passengers have been added to the total passenger count for this "+this.name+".");
}
Bus.pickUp(5);
Bus.identify();
