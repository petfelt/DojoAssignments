// Ninja Object:
function VehicleConstructor(name, wheels, passengers, speed){
  this.name = name;
  this.wheels = wheels;
  this.passengers = passengers;
  this.speed = speed;
  var distance_travelled = 0;

  var updateDistanceTravelled = function(){
    distance_travelled += speed;
  }

  this.move = function(){
    updateDistanceTravelled();
    this.makeNoise();
  }

  this.checkMiles = function(){
    console.log(this.name+" Total Distance Travelled: "+distance_travelled);
  }

  this.makeNoise = function(){
    console.log("HOOOOONNKKK!");
  }

  this.identify = function(){
    console.log("I am a "+this.name+". I have "+this.wheels+" wheels and I currently have "+this.passengers+" passengers. I move at "+this.speed+" MPH.");
  }

}


var Bike = new VehicleConstructor("Bike", 2, 2, 12);
Bike.makeNoise = function() {
  console.log("ring ring!");
}
Bike.identify();
Bike.makeNoise();

var Sedan = new VehicleConstructor("Sedan", 4, 5, 42);
Sedan.makeNoise = function() {
  console.log("Honk Honk!");
}
Sedan.identify();
Sedan.makeNoise();

var Bus = new VehicleConstructor("Bus", 4, 17, 25);
Bus.identify();
Bus.makeNoise();
Bus.pickUp = function(num) {
  this.passengers += num;
  console.log(num+" passengers have been added to the total passenger count for this "+this.name+".");
}
Bus.pickUp(5);
Bus.identify();


Bus.move();
Bus.move();
Bus.move();
Sedan.move();
Sedan.move();
Sedan.move();
Bike.move();
Bike.move();
Bike.move();
Bus.checkMiles();
Sedan.checkMiles();
Bike.checkMiles();
