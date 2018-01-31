var express = require("express");
var path = require("path");

var app = express()
var bodyParser = require("body-parser");

var PORT = 8000

app.use(bodyParser.json());
app.use(express.static(path.join(__dirname, "./friends-angular/dist")));
app.use(express.static(path.join(__dirname, "./node_modules")));

require("./server/config/mongoose.js")

require("./server/config/routes.js")(app)

app.listen(PORT, function(){
  console.log('listening on port 8000')
})
