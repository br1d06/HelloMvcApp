﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOD.Domain.Models;
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
		if (footballClub1Goals > footballClub2Goals)
			MatchResult = Result.FootballClub1Win;
		else if (footballClub2Goals > footballClub1Goals)
			MatchResult = Result.FootballClub2Win;
		else
			MatchResult = Result.Draw;
	}
}

