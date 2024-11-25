using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WOD.Domain.Models;
using System.Net.Http.Headers;
using WOD.WebUI.Data;
using Azure.Core;

namespace WOD.WebUI.Services
{
    public class FootballClubService
    {
        private readonly PostgresContext _context;

		HttpClient _client = new HttpClient();
		HttpRequestMessage _request = new HttpRequestMessage
	    {
		    Method = HttpMethod.Get,
		    RequestUri = new Uri("https://english-premiere-league1.p.rapidapi.com/player/bio?playerId=173896"),
		    Headers =
	        {
		        { "x-rapidapi-key", "d1dc426067msh02c7e14408510b2p1e36d0jsn0d5fc41a792e" },
		        { "x-rapidapi-host", "english-premiere-league1.p.rapidapi.com" },
	        },
	    };
	    public FootballClubService(PostgresContext context)
        {
            _context = context;
        }
    
        [HttpGet]
        public async void GetData()
        {
			using var response = await _client.SendAsync(_request);
			response.EnsureSuccessStatusCode();
			var body = await response.Content.ReadAsStringAsync();
			Console.WriteLine(body);
		}
    }
}
 