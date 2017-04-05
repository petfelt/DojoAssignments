var _ = {
   map: function(arr, callback) {
     //code here;
     for(var i = 0; i < arr.length; i++) {
       arr[i] = callback(arr[i]);
     }
     return arr;
   },
   reduce: function(arr, callback, startIdx) {
     // code here;
     startIdx = arr[startIdx];
     for(var i = startIdx; i < arr.length; i++) {
        startIdx = callback(arr[i], startIdx);
      }
      return startIdx;
   },
   find: function(arr, callback) {
     // code here;
     for(var i = 0; i < arr.length; i++) {
       if(callback(arr[i])){
         return arr[i];
       }
     }
   },
   filter: function(arr, callback) {
     // code here;
     var filter_list = [];
     for(var i = 0; i < arr.length; i++) {
       if(callback(arr[i])){
         filter_list.push(arr[i]);
       }
     }
     return filter_list;
   },
   reject: function(arr, callback) {
     // code here;
     var reject_list = [];
     for(var i = 0; i < arr.length; i++) {
       if(!callback(arr[i])){
         reject_list.push(arr[i]);
       }
     }
     return reject_list;
   }
 }
// you just created a library with 5 methods!

// Tests of above library:
var map = _.map([1, 2, 3], function(num){ return num * 3; });
console.log("\nMap:");
console.log(map);
var reduce = _.reduce([1, 2, 3], function(memo, num){ return memo + num; }, 0);
console.log("\nReduce:");
console.log(reduce);
var find = _.find([1, 2, 3, 4, 5, 6], function(num){ return num % 2 == 0; });
console.log("\nFind:");
console.log(find);
var filter = _.filter([1, 2, 3, 4, 5, 6], function(num){ return num % 2 == 0; });
console.log("\nFilter:");
console.log(filter);
var reject = _.reject([1, 2, 3, 4, 5, 6], function(num){ return num % 2 == 0; });
console.log("\nReject:");
console.log(reject);
