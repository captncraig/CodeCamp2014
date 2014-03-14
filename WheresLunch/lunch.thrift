namespace csharp WheresLunchServer
namespace go lunch

/** Struct represents a single vote*/
struct Vote{
	1: string Name,
	2: string Place,
}

/** Means they already voted */
exception AlreadyVotedException{
}

service LunchService{
	string MakeDecision()
	list<string> GetSuggestions()
	void PlaceVote(1: Vote v) throws (1: AlreadyVotedException a)
}