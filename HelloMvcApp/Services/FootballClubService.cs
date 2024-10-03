using WOD.Domain.Models;

namespace WOD.WebUI.Services
{
	public class FootballClubService
	{
		public List<FootballClub> FootballClubs = new List<FootballClub>()
		{
			new FootballClub("Arsenal","https://media.api-sports.io/football/teams/42.png"),
			new FootballClub("Aston Villa","https://media.api-sports.io/football/teams/66.png"),
			new FootballClub("Burnley","https://media.api-sports.io/football/teams/44.png"),
			new FootballClub("Bournemouth", "https://media.api-sports.io/football/teams/35.png"),
			new FootballClub("Brentford", "https://media.api-sports.io/football/teams/55.png"),
			new FootballClub("Brighton","https://media.api-sports.io/football/teams/51.png	"),
			new FootballClub("Chelsea", "https://media.api-sports.io/football/teams/49.png"),
			new FootballClub("Crystal Palace", "https://media.api-sports.io/football/teams/52.png"),
			new FootballClub("Everton", "https://media.api-sports.io/football/teams/45.png"),
			new FootballClub("Fulham", "https://media.api-sports.io/football/teams/36.png"),
			new FootballClub("Liverpool", "https://media.api-sports.io/football/teams/40.png"),
			new FootballClub("Luton Town", "https://i.pinimg.com/originals/ac/2b/f5/ac2bf526e0bb93f8712d63c7ad088c32.png"),
			new FootballClub("Manchester City", "https://media.api-sports.io/football/teams/50.png"),
			new FootballClub("Manchester United", "https://media.api-sports.io/football/teams/33.png"),
			new FootballClub("Newcastle United", "https://media.api-sports.io/football/teams/34.png"),
			new FootballClub("Nottingham Forest", "https://media.api-sports.io/football/teams/65.png"),
			new FootballClub("Tottenham Hotspur", "https://media.api-sports.io/football/teams/47.png"),
			new FootballClub("Sheffield United", "https://media.api-sports.io/football/teams/62.png"),
			new FootballClub("West Ham United", "https://media.api-sports.io/football/teams/48.png"),
			new FootballClub("Wolverhampton Wanderers", "https://media.api-sports.io/football/teams/39.png")
		};

		public  List<FootballClub> GetFootballClubs() 
		{			
			return FootballClubs;	
		}
	public static Dictionary<string,int> GetTable(List<FootballClub> footballClubs)
        {
            Dictionary<string, int> table = new Dictionary<string, int>();

            for (int i = 0; i < footballClubs.Count; i++)
            {
                if(table.ContainsKey(footballClubs[i].FullName))
                    continue;

                table.Add(footballClubs[i].FullName, footballClubs[i].Points);
            }
			return table.ToDictionary(x => x.Key, x => x.Value);
		}
    }
}
 