using WOD.Domain.Models;

namespace WOD.WebUI.Services
{
    public class FootballClubService
    {
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
 