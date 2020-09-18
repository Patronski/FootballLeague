using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace FootballLeague.Data.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }

        public IEnumerable<Match> Matches { get; set; } = new List<Match>();
    }
}