using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOD.Domain.Models
{
    public class Player
    {
        public string Name { get; set; }
        public FootballClub FootballClub { get; set; }
        public byte Goals { get; set; }
        public byte Assists { get; set; }

        public Player(string name, FootballClub footballClub, byte goals=0, byte assists=0) 
        { 
            Name= name;
            FootballClub= footballClub;
        }
        public Player() { }

    }
}
