// Require and use modules:

var express = require("express");
var path = require("path");
var app = express();
var bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({extended: true}));


// this is the line that tells our server to use the "/static" folder for static content
app.use(express.static(__dirname + "/static"));
// two underscores before dirname
// try printing out __dirname using console.log to see what it is and why we use it
// This sets the location where express will look for the ejs views
app.set('views', __dirname + '/views');
// Now lets set the view engine itself so that express knows that we are using ejs as opposed to another templating engine like jade
app.set('view engine', 'ejs');


// GET and POST routes:
app.get('/', function(request, response){
  response.render('index', {title: "Survey Form"});
});

// route to process new user form data:
app.post('/result', function (req, res){
    console.log("POST DATA \n\n", req.body);
    //code to add user to db goes here!
    // redirect the user back to the root route.
    res.render('result', {title: "Survey Form", myData: req.body});
});

// app.get('/result', function(request, response){
//   console.log("POST DATA \n\n", req.postData);
//   response.render('result', {title: "Survey Form"});
// })


// Do this at the end, or at least after get post routes.
app.listen(8000, function(){
  console.log("Listening on 8000");
});
