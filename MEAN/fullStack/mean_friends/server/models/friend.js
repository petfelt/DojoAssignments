var mongoose = require("mongoose")

var FriendSchema =  new mongoose.Schema({
  name: String,
  age: Number,
}, {timestamps: true})

mongoose.model("Friend", FriendSchema)
