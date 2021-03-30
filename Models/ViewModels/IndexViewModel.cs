using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Models.ViewModels
{
    public class IndexViewModel
    {
        //allows the program to have a bowling team associated with the list of bowler objects and to pass the page numbering info from one file to another
        public List<Bowler> Bowlers { get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public string BowlingTeam { get; set; }
    }
}
