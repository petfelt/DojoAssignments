var x = [3,5,"Dojo", "rocks", "Michael", "Sensei"];
for(var i = 0; i < x.length; i++){
  console.log(x[i]);
}
x.push(100);
x.push(["hello", "world", "JavaScript is Fun"]);
console.log(x);
var temp = 0;
for(var i = 1; i < 501; i++){
  temp = temp + i;
}
console.log("Final sum: " + temp);
var arr = [1, 5, 90, 25, -3, 0];
console.log("New array:");
var temp2 = 0;
for(var i = 0; i < arr.length; i++){
  console.log(arr[i]);
  if(arr[i] < temp){
    temp = arr[i];
  }
  temp2 = temp2 + arr[i];
}
temp2 = temp2/ (arr.length);
console.log("Min: "+ temp);
console.log("Avg: "+ temp2);

var newNinja = {
 name: 'Jessica',
 profession: 'coder',
 favorite_language: 'JavaScript', //like that's even a question!
 dojo: 'Dallas'
}
for(var j in newNinja){
  console.log("Key: "+j+"     Value: "+newNinja[j]);
}
