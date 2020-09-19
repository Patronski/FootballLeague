using FootballLeague.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballLeague.Models
{
    public class MatchManager : IMatchManager
    {
        private Random random = new Random(DateTime.Now.Millisecond);

        public Match PlayMatch(Match unplayedMatch)
        {
            unplayedMatch.LeftTeamGoals = random.Next(0, 3);
            unplayedMatch.RightTeamGoals = random.Next(0, 3);

            return unplayedMatch;
        }

        public int GetLeftTeamPoints(Match playedMatch)
        {
            if(playedMatch.LeftTeamGoals > playedMatch.RightTeamGoals)
            {
                return 3;
            }
            else if (playedMatch.LeftTeamGoals < playedMatch.RightTeamGoals)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int GetRightTeamPoints(Match playedMatch)
        {
            if (playedMatch.RightTeamGoals > playedMatch.LeftTeamGoals)
            {
                return 3;
            }
            else if (playedMatch.RightTeamGoals < playedMatch.LeftTeamGoals)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}