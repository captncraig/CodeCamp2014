
var thrift = require('thrift');

var voteCounts = {};

var votingService = require('./gen-nodejs/VotingService'),
    ttypes = require('./gen-nodejs/vote_types');
	
	var handler = {
		GetPossibleVotes: function(result){
			console.log('getPossible');
			result(null,["c#","java","go","python","ruby"]);
		},
		PlaceVote: function(vote,result){
			console.log('vote for ' + vote);
			if(!voteCounts[vote])voteCounts[vote] = 0
			voteCounts[vote]++
			result(null);
		},
		GetVoteCounts: function(result){
			result(null,voteCounts)
		},
		
	}
	
var server_http = thrift.createHttpServer(votingService,handler, {protocol: thrift.TJSONProtocol});
console.log("starting server on 9090");
server_http.listen(9090);
console.log("server started");