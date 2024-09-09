using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOD.Domain.Models
{
    public class ClubLogo   
    {
        public string Link { get;  private set; }

        public string AlternativeName { get; private set; }

        public ClubLogo(string link, string alternativeName) 
        { 
            Link = link;
            AlternativeName = alternativeName;
        }

    }
}

