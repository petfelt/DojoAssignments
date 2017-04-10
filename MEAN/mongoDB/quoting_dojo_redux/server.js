// Require the Express Module
var express = require('express');
// Create an Express App
var app = express();
// Require body-parser (to receive post data from clients)
var bodyParser = require('body-parser');
// Integrate body-parser with our App
app.use(bodyParser.urlencoded({ extended: true }));
// Require path
var path = require('path');
// Setting our Static Folder Directory
app.use(express.static(path.join(__dirname, './static')));
// Setting our Views Folder Directory
app.set('views', path.join(__dirname, './views'));
// Setting our View Engine set to EJS
app.set('view engine', 'ejs');

// Add mongoose:
var mongoose = require('mongoose');
var assert = require('assert');
// This is how we connect to the mongodb database using mongoose -- "quotes" is the name of
//   our db in mongodb -- this should match the name of the db you are going to use for your project.
mongoose.connect('mongodb://localhost/quotes');
mongoose.Promise = global.Promise;


// Schema creation & init:
var QuoteSchema = new mongoose.Schema({
    name: {type: String, required: true, minlength: 1, maxlength: 500},
    quote: {type: String, required: true, minlength: 1, maxlength: 500},
}, {timestamps: true})

mongoose.model('Quotes', QuoteSchema);
var Quote = mongoose.model('Quotes');

// GET and POST routes:
app.get('/', function(request, response){
  response.render('index', {title: "QuotingDojo"});
});

app.post('/addaquote', function(req, res){
    var newQuote = new Quote({name: req.body.name, quote: req.body.quote});
    newQuote.save(function(err){
        if(err){
            console.log("Couldn't add quote; send errors.");
            var data = {title: 'You have errors!', errors: newQuote.errors};
            res.render('index', data);
        } else {
            res.redirect('/quotes');
        }
    })
})

app.get('/quotes', function(req, res){
    Quote.find({}, function(err, quotes){
        if(err){
            console.log("failed to retrieve data");
        } else {
            var data = {title: 'Quotes From QuotingDojo', quotes: quotes};
            res.render('quotes', data);
        }
    })
})



// Do this at the end, or at least after get post routes.
app.listen(8000, function(){
  console.log("Listening on 8000");
});
