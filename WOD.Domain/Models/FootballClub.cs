﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace WOD.Domain.Models
{
    public class FootballClub
    {
        public int Id { get; set; }
        public string FullName { get; private set; }

        public string Logo { get; private set; }   
        
        public int Games {get; private set; }

        public int Wins { get; private set ; }

        public int Loses { get; private set; }

        public int Draws { get; private set; }

        public int GoalsScored { get; private set; }

        public int GoalsMissed { get; private set; }   
        
        public ushort TablePosition { get; private set; }

        public int Points => Wins * 3 + Draws;

        public int GoalsDifference=> GoalsScored - GoalsMissed;

        public FootballClub(string fullName, string logo)
        {           
            FullName = fullName;
            Logo = logo;                         
        }       

        public FootballClub() { }
    }
}
