

service VotingService{
	list<string> GetPossibleVotes()
	
	void PlaceVote(1: string vote)
	
	map<string,i32> GetVoteCounts()
}