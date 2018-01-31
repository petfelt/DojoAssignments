var mongoose = require("mongoose")
var Friend = mongoose.model("Friend")

module.exports = {
	get_all_friends: function(req, res){
		Friend.find({}, function(err, data){
			if(err){
				console.log("Friend find error", err)
				res.json(err)
			} else {
				res.json(data)
			}
		})
	},
	create: function(req, res){
		console.log(req.body)
		var new_friend = new Friend(req.body)
		new_friend.save(function(err){
			if(err){
				console.log("Friend create error", err)
				res.json({added: false, error: err})
			} else {
				res.json({added: true})
			}
		})
	},
	delete: function(req, res){
		Friend.remove({_id: req.params.id}, function(err){
			if(err){
				console.log("Friend delete error", err)
			}
			res.json(true)
		})
	}
}
