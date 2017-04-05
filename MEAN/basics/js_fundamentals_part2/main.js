// First written version:
function sumInt(x, y){
  if(typeof(x) == "number" && typeof(y) == "number"){
    if(x < y){
      var i = 0;
      while(x <= y){
        i = i+x;
        x = x+1;
      }
      return(i);
    }
  }
  return "Either x > y || x and/or y is not a number.";
}
console.log("Total sum for 6-10: " +sumInt(6,10));

function minArray(arr){
  if(typeof(arr == "array")){
    var min = 10000000;
    for(var i = 0; i < arr.length; i++){
      if(arr[i] < min){
        min = arr[i];
      }
    }
    return(min);
  }
}
console.log("Min of array: " +minArray([100001,5,6,10,3,-2,0,-121]));

function avgArray(arr){
  if(typeof(arr=="array")){
    var avg = 0;
    for(var i = 0; i < arr.length; i++){
      avg = avg+ arr[i];
    }
    return (avg/arr.length);
  }
}
console.log("avg of array: " +avgArray([100001,5,6,10,3,-2,0,-121]));

// third written version:
var sumI = function sumInteger(x, y){
  if(typeof(x) == "number" && typeof(y) == "number"){
    if(x < y){
      var i = 0;
      while(x <= y){
        i = i+x;
        x = x+1;
      }
      return(i);
    }
  }
  return "Either x > y || x and/or y is not a number.";
}
console.log("Total sum for 6-10: " +sumI(6,10));

var minA = function minArr(arr){
  if(typeof(arr == "array")){
    var min = 10000000;
    for(var i = 0; i < arr.length; i++){
      if(arr[i] < min){
        min = arr[i];
      }
    }
    return(min);
  }
}
console.log("Min of array: " +minA([100001,5,6,10,3,-2,0,-121]));

var avgA = function avgArr(arr){
  if(typeof(arr=="array")){
    var avg = 0;
    for(var i = 0; i < arr.length; i++){
      avg = avg+ arr[i];
    }
    return (avg/arr.length);
  }
}
console.log("avg of array: " +avgA([100001,5,6,10,3,-2,0,-121]));

var myObject = {
  sumFunc: sumI,
  minFunc: minA,
  avgFunc: avgA
}
console.log(myObject.sumFunc(6,10), myObject.minFunc([100001,5,6,10,3,-2,0,-121]), myObject.avgFunc([100001,5,6,10,3,-2,0,-121]));



// Human object:
var person = {
  name: "Peter",
  distance_traveled: 0,
  say_name: function(){console.log(person.name);},
  say_something: function(saying){console.log(person.name+' says "'+saying+'"');},
  walk: function(distance){
    console.log(person.name+' is walking');
    person.distance_traveled+=3;
  },
  run: function(distance){
    console.log(person.name+' is running');
    person.distance_traveled+=10;
  },
  crawl: function(distance){
    console.log(person.name+' is crawling');
    person.distance_traveled+=1;
  },
  total_distance: function(){
    console.log(person.name+' has traveled '+person.distance_traveled+' total units.');
  }
}

person.say_something("I am cool");
person.walk();
person.run();
person.crawl();
person.total_distance();
