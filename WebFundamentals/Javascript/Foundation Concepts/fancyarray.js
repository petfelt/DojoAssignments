fancyArray([1,2,3]);
fancyArray("apple pear banana", 0);
fancyArray([5,6,1,2,"hello","apple jam"], "--( ͡° ͜ʖ ͡°)-->");


function fancyArray(arr, symbol) {
  if(symbol === undefined) {
    symbol = "->";
  }
  if(Array.isArray(arr)) {
    for(var i = 0; i < arr.length; i++) {
      console.log(""+i,symbol,arr[i]);
    }
  } else {
    console.log("You didn't pass an array into the function! Here's what you gave us:",arr);
  }
}
