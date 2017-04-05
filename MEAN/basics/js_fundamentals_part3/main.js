// Ninja Object:
function ninjaController(myName, myCohort){
  return {
    name: myName,
    cohort: myCohort,
    belt_level: "yellow",
    say_name: function(){console.log("I am "+this.name+".");},
    say_cohort: function(){console.log("I am in the cohort that started on "+this.cohort+".");},
    say_something: function(saying){console.log('The ninja '+this.name+' says "'+saying+'"');},
    level_up: function(){
      if(this.belt_level == "yellow"){
        this.belt_level = "red";
      } else if (this.belt_level == "red"){
        this.belt_level = "green";
      } else if (this.belt_level == "green"){
        this.belt_level = "black";
      } else if (this.belt_level == "black"){
        this.belt_level = "Black";
      }
      if(this.belt_level == "Black"){
        console.log(this.name+" has achieved the highest belt rank, a black belt. Congratulations!");
      } else{
        console.log(this.name+"Has gotten a "+this.belt_level+" belt! Good job!");
      }
    },
  }
}

// Person object:
function personController(myName){
  return {
    name: myName,
    distance_traveled: 0,
    say_name: function(){console.log("I am "+this.name+".");},
    say_something: function(saying){console.log(this.name+' says "'+saying+'"');},
    walk: function(){
      console.log(this.name+' is walking.');
      this.distance_traveled+=3;
    },
    run: function(){
      console.log(this.name+' is running.');
      this.distance_traveled+=10;
    },
    crawl: function(){
      console.log(this.name+' is crawling.');
      this.distance_traveled+=1;
    },
    total_distance: function(){
      console.log(this.name+' has traveled '+this.distance_traveled+' total units.');
    }
  }
}

var Tim = personController("Tim");
Tim.say_name();
Tim.say_something("I am the best hue man ever! Definitely a real fleshbag I am!");
Tim.run();
Tim.walk();
Tim.total_distance();

var Billy = ninjaController("Billy","January 3rd, 2017");
Billy.say_name();
Billy.say_cohort();
Billy.level_up();
Billy.level_up();
Billy.level_up();
Billy.level_up();
Billy.level_up();
