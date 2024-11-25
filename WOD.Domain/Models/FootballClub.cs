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
    public string Name { get; private set; }

    public string Logo { get; private set; }   
        
    public byte Games {get; private set; }

    public byte Wins { get; private set ; }

    public byte Losses { get; private set; }

    public byte Ties { get; private set; }

    public byte GoalsFor { get; private set; }

    public byte GoalsAgainst { get; private set; }   
        
    public byte Rank { get; private set; }

    public byte Points {  get; private set; }

    public byte GoalsDifference {  get; private set; }

    public FootballClub(string fullName, string logo)
    {           
        Name = fullName;
        Logo = logo;
    }       

    public FootballClub() { }
}