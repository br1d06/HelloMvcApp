using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WOD.Domain.Models;
[Keyless]
public class Match
{
	FootballClub FootballClub1 { get; set; }
	FootballClub FootballClub2 { get; set; }
	byte FootballClub1Goals { get; set; }
	byte FootballClub2Goals { get; set; }
	enum Result
	{
		FootballClub1Win,
		FootballClub2Win,
		Draw
	}
	Result MatchResult { get; set; }

	public Match(FootballClub footballClub1, FootballClub footballClub2,byte footballClub1Goals,byte footballClub2Goals) 
	{ 
		FootballClub1 = footballClub1;
		FootballClub2 = footballClub2;
		FootballClub1Goals = footballClub1Goals;
		FootballClub2Goals = footballClub2Goals;
		if (footballClub1Goals == footballClub2Goals)
			MatchResult = Result.Draw;
        MatchResult = footballClub1Goals > footballClub2Goals ? Result.FootballClub1Win : Result.FootballClub2Win;
    }
	public Match() { }
}

