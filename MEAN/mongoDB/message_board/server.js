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
// This is how we connect to the mongodb database using mongoose -- "quotes" is the name of
//   our db in mongodb -- this should match the name of the db you are going to use for your project.
mongoose.connect('mongodb://localhost/message_board');
mongoose.Promise = global.Promise;


// Schema creation & init:
var Schema = mongoose.Schema;

var PostSchema = new mongoose.Schema({
    text: {type: String, required: true, minlength: 1, maxlength: 500},
    name: {type: String, required: true, minlength: 4, maxlength: 500},
    comments: [{type: Schema.Types.ObjectId, ref: 'Comment'}]
}, {timestamps: true})

var CommentSchema = new mongoose.Schema({
    text: {type: String, required: true, minlength: 1, maxlength: 500},
    name: {type: String, required: true, minlength: 4, maxlength: 500},
    _post: {type: Schema.Types.ObjectId, ref: 'Post'}
}, {timestamps: true})

mongoose.model('Post', PostSchema);
var Post = mongoose.model('Post');
mongoose.model('Comment', CommentSchema);
var Comment = mongoose.model('Comment');

// GET and POST routes:
app.get('/', function(request, response){
  Post.find({}, function(err, posts){
        if(err) {
            console.log("Unable to retrieve the posts.");
        }
    })
    .populate("comments")
    .exec(function(err, posts){
        data = {posts: posts};
        response.render('index', data);
    })
});

app.post('/addpost', function(req, res){
    var post = new Post(req.body);
    post.save(function(err){
        if(err){
            console.log("Unable to save this post.");
        }
        res.redirect('/');
    })
})

app.post('/addcomment/:id', function(req, res){
    Post.findOne({_id: req.params.id}, function(err, post){
        var comment = new Comment(req.body);
        comment._post = post._id;

        comment.save(function(err){
            post.comments.push(comment);
            post.save(function(err){
                if(err){
                    console.log("Unable to save this comment.");
                }
                res.redirect('/');
            })
        })
    })
})

// Do this at the end, or at least after get post routes.
app.listen(8000, function(){
  console.log("Listening on 8000");
});
