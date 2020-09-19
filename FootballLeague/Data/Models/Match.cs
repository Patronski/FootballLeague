using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballLeague.Data.Models
{
    public class Match
    {
        public int Id { get; set; }

        public Team LeftTeam { get; set; }

        public Team RightTeam { get; set; }

        public int? LeftTeamGoals { get; set; }

        public int? RightTeamGoals { get; set; }

        public DateTime DateTime { get; set; }
    }
}