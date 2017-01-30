printRange(2,10,2);
printRange(-4,5,3);
printRange(5,3);
printRange(-5);
printRange(20,15);

function printRange(start, end, skip) {
  if(skip===undefined){
    skip = 1;
  }
  if(end===undefined){
    if(start > 0) {
      end = start;
      start = 0;
    } else {
      end = 0;
    }
  } else {
    if(start>end) { // If the end exists but it is smaller than the start...
      var temp = start;
      start = end;
      end = temp; // Swap em.
    }
  }
  while(start<end) {
    console.log(start);
    start = start + skip;
  }
}
