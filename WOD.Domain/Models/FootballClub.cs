using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WOD.Domain.Models;
public class FootballClub
{
    public int Id { get; set; }
    public string FullName { get; private set; }

    public string Logo { get; private set; }   
        
    public byte Games {get; private set; }

    public byte Wins { get; private set ; }

    public byte Loses { get; private set; }

    public byte Draws { get; private set; }

    public byte GoalsScored { get; private set; }

    public byte GoalsMissed { get; private set; }   
        
    public byte TablePosition { get; private set; }

    public int Points() => Wins * 3 + Draws;

    public int GoalsDifference() => GoalsScored - GoalsMissed;

    public FootballClub(string fullName, string logo)
    {           
        FullName = fullName;
        Logo = logo;
    }       

    public FootballClub() { }
}