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
mongoose.connect('mongodb://localhost/mongoose_dashboard');
mongoose.Promise = global.Promise;


// Schema creation & init:
var DragonSchema = new mongoose.Schema({
    name: {type: String, required: true, minlength: 1, maxlength: 500},
    age: {type: Number, required: true, minlength: 1, maxlength: 1500},
}, {timestamps: true})

mongoose.model('Dragons', DragonSchema);
var Dragons = mongoose.model('Dragons');

// GET and POST routes:
app.get('/', function(request, response){
  Dragons.find({}, function(err, dragons){
        if(err){
            console.log("Unable to retrieve data.")
        } else {
             response.render('index', {dragons: dragons});
        }
    })
});

app.get('/dragons/new', function(req, res){
    res.render('addDragon');
})

app.post('/dragons', function(req, res){
    var newDragon = new Dragons({name: req.body.name, age: req.body.age});
    newDragon.save(function(err){
        if(err){
            console.log("Could not save!");
            console.log(newDragon.errors);
        } else {
            res.redirect('/');
        }
    })
})

app.get('/dragons/:id', function(req, res){
    Dragons.find({_id:req.params.id}, function(err, dragon){
        if(err){
            console.log("Could not find the dragon you were looking for.");
            res.redirect('/');
        } else {
            res.render('viewDragon', {dragon: dragon});
        }
    })
})

app.post('/dragons/:id', function(req, res){
    Dragons.findOne({_id: req.params.id}, function(err, dragon){
        if(err){
            console.log("Could not find the dragon you were looking for.");
            res.redirect('/');
        } else {
            dragon.name = req.body.name;
            dragon.age = req.body.age;
            dragon.save(function(err){
                if(err){
                    console.log("Couldn't update the record.")
                } else {
                    res.redirect('/dragons/' + (encodeURIComponent(req.params.id.toString())));
                }
            })
        }
    })
})

app.get('/dragons/edit/:id', function(req, res){
   Dragons.find({_id:req.params.id}, function(err, dragon){
        if(err){
            console.log("Could not find the dragon you were looking for.");
            res.redirect('/');
        } else {
            res.render('editDragon', {dragon: dragon});
        }
    })
})

app.post('/dragons/destroy/:id', function(req, res){
    Dragons.remove({_id: req.params.id}, function(err){
        if(err){
            console.log("Could not remove the dragon you wished to remove.");
            res.redirect('/');
        } else {
            res.redirect('/');
        }
    })
})


// Do this at the end, or at least after get post routes.
app.listen(8000, function(){
  console.log("Listening on 8000");
});
