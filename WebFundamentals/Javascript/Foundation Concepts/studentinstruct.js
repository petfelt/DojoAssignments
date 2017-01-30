var students = [
     {first_name:  'Michael', last_name : 'Jordan'},
     {first_name : 'John', last_name : 'Rosales'},
     {first_name : 'Mark', last_name : 'Guillen'},
     {first_name : 'KB', last_name : 'Tonel'}
]

var users = {
 'Students': [
     {first_name:  'Michael', last_name : 'Jordan'},
     {first_name : 'John', last_name : 'Rosales'},
     {first_name : 'Mark', last_name : 'Guillen'},
     {first_name : 'KB', last_name : 'Tonel'}
  ],
 'Instructors': [
     {first_name : 'Michael', last_name : 'Choi'},
     {first_name : 'Martin', last_name : 'Puryear'}
  ]
 }


function partOne(){
  for(var key in users) {
    for(var i=0; i < users[key].length;i++) {
      console.log("" + users[key][i].first_name, users[key][i].last_name);
    }
  }
}


 function partTwo () {
   for(var key in users) {
    console.log(key);
    for(var i=0; i < users[key].length;i++) {
      console.log(i+1 + " - " + users[key][i].first_name + " " + users[key][i].last_name + " - " + users[key][i].first_name.length + users[key][i].last_name.length);
    }
  }
}

console.log("Part One: ");
partOne();
console.log("");
console.log("Part Two: ");
partTwo();
