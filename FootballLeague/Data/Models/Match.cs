using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballLeague.Data.Models
{
    public class Match
    {
        public int Id { get; set; }

        public Team LeftTeam { get; set; }

        public Team RightTeam { get; set; }

        public Tuple<int, int> Result { get; set; }

        public DateTime DateTime { get; set; }
    }
}