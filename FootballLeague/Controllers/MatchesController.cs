using FootballLeague.Data.Models;
using FootballLeague.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Match = FootballLeague.Data.Models.Match;

namespace FootballLeague.Controllers
{
    public class MatchesController : BaseController
    {
        private FootballLeagueContext db = new FootballLeagueContext();

        private IMatchManager matchManager = new MatchManager();

        [Route()]
        public ActionResult Index()
        {
            var matches = new List<Match>();
            using (FootballLeagueContext db = new FootballLeagueContext())
            {
                matches = db.Matches
                    .Include(x => x.LeftTeam)
                    .Include(x => x.RightTeam)
                    .OrderByDescending(x => x.Id)
                    .ToList();
            }

            return View(matches);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var teamNames = db.Teams
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Name
                })
                .ToList();

            return View(teamNames);
        }

        [HttpPost]
        public async Task<ActionResult> FinishCreate(string teamNameLeft, string teamNameRight)
        {
            if (teamNameLeft == teamNameRight)
            {
                TempData["Error"] = $"Choose different teams!";
                return RedirectToAction("Create");
            }

            var teamLeft = db.Teams.Single(x => x.Name == teamNameLeft);
            var teamRight = db.Teams.Single(x => x.Name == teamNameRight);

            var match = new Match()
            {
                LeftTeam = teamLeft,
                RightTeam = teamRight,
                DateTime = DateTime.Now
            };

            var playedMatch = matchManager.PlayMatch(match);

            db.Matches.Add(playedMatch);

            playedMatch.LeftTeam.Points += matchManager.GetLeftTeamPoints(playedMatch);
            playedMatch.RightTeam.Points += matchManager.GetRightTeamPoints(playedMatch);

            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}