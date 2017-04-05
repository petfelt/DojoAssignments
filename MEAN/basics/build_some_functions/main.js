var myVar;
function runningLogger() {
  console.log("I am running!");
}
function multiplyByTen(param) {
  if(typeof(param) == "number"){
    return (param*10);
  }
}
function stringReturnOne(){
  return "I am the first string!";
}
function stringReturnTwo(){
  return "Woo hoo! I am a different string, golly gee willikers, mister!";
}
function caller(myparam) {
  if(typeof(myparam) == "function") {
    myparam();
  }
}
caller(stringReturnOne);
function myDoubleConsoleLog(param1, param2){
  if(typeof(param1) == "function" && typeof(param2) == "function"){
    console.log(param1(), param2());
  }
}
myDoubleConsoleLog(stringReturnOne, stringReturnTwo);

function caller2(thisparam){
  console.log('starting');
  var x = setTimeout(function(){
    if (typeof(thisparam)=='function'){
      thisparam(stringReturnOne, stringReturnTwo);
    }
  }, 2000);
  console.log('ending');
  return "interesting";
}

console.log("5 multiplied by 10: "+multiplyByTen(5));
console.log(caller2(myDoubleConsoleLog));
