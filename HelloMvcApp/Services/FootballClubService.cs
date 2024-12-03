using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WOD.Domain.Models;
using System.Net.Http.Headers;
using WOD.WebUI.Data;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WOD.WebUI.Services
{
    public class FootballClubService
    {
        private readonly Dictionary<string,string> rusFootballClubNames = new Dictionary<string, string> 
        {
            {"Liverpool","Ливерпуль" },
            {"Arsenal" , "Арсенал" },
            {"Chelsea" , "Челси" },
            {"Brighton & Hove Albion" , "Брайтон" },
            {"Manchester City" , "Манчестер Сити" },
            {"Nottingham Forest" , "Ноттингем Форест" },
            {"Tottenham Hotspur" , "Тоттенхэм" },
            {"Brentford" , "Брентфорд" },
            {"Manchester United" , "Манчестер Юнайтед" },
            {"Fulham" , "Фулхэм" },
            {"Newcastle United" , "Ньюкасл" },
            {"Aston Villa" , "Астон Вилла" },
            {"AFC Bournemouth" , "Борнмут" },
            {"West Ham United" , "Вест Хэм" },
            {"Everton" , "Эвертон" },
            {"Leicester City" , "Лестер Сити" },
            {"Crystal Palace" , "Кристал Пэлас" },
            {"Wolverhampton Wanderers" , "Вулверхэмптон" },
            {"Ipswich Town" , "Ипсвич Таун" },
            {"Southampton" , "Саутгемптон" }
        };

        private readonly PostgresContext _context;

        private static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("https://soccer365.ru"),
        };

        [HttpGet]
        static async Task<string> GetAsync(HttpClient httpClient)
        {
            using HttpResponseMessage response = await httpClient.GetAsync("competitions/12");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return jsonResponse;
        }
        public FootballClubService(PostgresContext context)
        {
            _context = context;
        }

        public async void GetData()
        {
            string htmlPage = GetAsync(sharedClient).Result;

            string[] splitedPage = htmlPage.Split("<td class=\"al_c\">");

            for (int i = 0; i < 160;)
            {
                FootballClub footballClub = DefineFootballClub(splitedPage[i]);

                int[] footballClubStats = new int[8];

                for (int j = 1; j <= 8; j++, i++)
                {
                    string rawValue = splitedPage[i+1];

                    string[] result;

                    if (j == 8) //Последний столбец Points отличается от других присутствием тегов <b> & </b>, поэтому его нужно обрабатывать отдельно
                    {
                        result = rawValue.Split("</b>");

                        string pureValue = result[0].Substring(9);

                        footballClubStats[7] = Int32.Parse(pureValue);
                    }
                    else
                    {
                        result = rawValue.Split("</td>");

                        string pureValue = result[0];

                        footballClubStats[j - 1] = Int32.Parse(pureValue);
                    }
                }
                footballClub.Games = (byte)footballClubStats[0];
                footballClub.Wins = (byte)footballClubStats[1];
                footballClub.Ties = (byte)footballClubStats[2];
                footballClub.Losses = (byte)footballClubStats[3];
                footballClub.GoalsFor = (byte)footballClubStats[4];
                footballClub.GoalsAgainst = (byte)footballClubStats[5];
                footballClub.GoalsDifference = (sbyte)footballClubStats[6];
                footballClub.Points = (byte)footballClubStats[7];

                _context.Update(footballClub);
                await _context.SaveChangesAsync();
            }
        }

        public FootballClub DefineFootballClub(string htmlPagePart)
        {
            var footballClubsList = _context.FootballClubs.ToList();

            string footballClub = htmlPagePart.Substring(htmlPagePart.Length - 50);

            for(int i = 0; i < footballClubsList.Count; i++)
            {
                if (footballClub.Contains(rusFootballClubNames[footballClubsList[i].Name]))
                    return footballClubsList[i];                  
            }
            throw new ArgumentOutOfRangeException(nameof(footballClub), "Football Club is not found.");

        }
    }
}
 