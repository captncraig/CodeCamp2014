
/** Where's lunch? The ultimate answer to the hardest question */

namespace csharp WheresLunchServer
namespace go lunch

/** Represents a single vote. Each user may only vote once*/
struct Vote{
	/** Name of voter. Must be unique. */
	1: string Name,
	2: string Restaurant,
}


service LunchService{
	/** Place a vote */
	void PlaceVote(1: Vote vote)
	list<string> GetSuggestions()
	
	string MakeDecision()
}

