var originalArray = [1, "apple", -3, "orange", 0.5]

var newArray = copyNumOnly(originalArray);
// newArray is [1, -3, 0.5]

function copyNumOnly (arr) {
  var returnArray = [];
  for(var i = 0; i < arr.length; i++) {
    if(typeof arr[i] === "number") {
      returnArray.push(arr[i]);
    }
  }
  return returnArray;
}

function numbersOnly (arr) {
  for(var i = 0; i < arr.length; i++) {
    if(typeof arr[i] !== "number") {
      arr[i] = arr[arr.length-1];
      arr.pop();
    }
  }
}

console.log("Copy Array: "+newArray);
numbersOnly(originalArray);
console.log("Same Array: "+originalArray);
