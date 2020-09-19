using FootballLeague.Data.Models;

namespace FootballLeague.Models
{
    public interface IMatchManager
    {
        Match PlayMatch(Match unplayedMatch);

        int GetLeftTeamPoints(Match playedMatch);

        int GetRightTeamPoints(Match playedMatch);
    }
}