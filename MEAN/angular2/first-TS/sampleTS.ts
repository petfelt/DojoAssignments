// TypeScript:
var myNum:number = 5;
var myString:string = "Hello Universe";
var anythingOne:any = "Hey";
anythingOne = 25;
var anythingTwo:any = "Hey";
anythingTwo = [1, 2, 3, 4];
var anythingThree:any = "Hey";
anythingThree = { x: 1, y: 2 };
// There are two ways of declaring an array type
var arrayNumbersOne:number[] = [1, 2, 3, 4, 5, 6];
var arrayNumbersTwo:Array<number> = [1, 2, 3, 4, 5, 6];
var myObj:object = { x: 5, y: 10 };
// function constructor
// let myNode = (function () {
//     function MyNode(val) {
//         this.val = 0;
//         this.val = val;
//     }
//     MyNode.prototype.doSomething = function () {
//         this._priv = 10;
//     };
//     return MyNode;
// }());
class MyNode {
  public val: number;
  private _priv: number;
  constructor(val){
    this.val = val;
  }
  public publicFun(){
    console.log("PUBLIC!")
    this.privateFun();
  }
  private privateFun(){
    console.log("PRIVATE!");
  }


}
let myNodeInstance:MyNode = new MyNode(1);
console.log(myNodeInstance.val);
console.log(myNodeInstance.publicFun());
// This function will return nothing.
function myFunction():void {
    console.log("Hello World");
}
