using FootballLeague.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballLeague.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Ranking()
        {
            var teams = new List<Team>();
            using (FootballLeagueContext db = new FootballLeagueContext())
            {
                teams = db.Teams.OrderByDescending(x => x.Points).ToList();
            }

            return View(teams);
        }

        public ActionResult Teams()
        {
            var teams = new List<string>();
            using (FootballLeagueContext db = new FootballLeagueContext())
            {
                teams = db.Teams.Select(x => x.Name).ToList();
            }

            return View(teams);
        }

        public ActionResult Matches()
        {
            var matches = new List<Match>();
            using (FootballLeagueContext db = new FootballLeagueContext())
            {
                matches = db.Matches.ToList();
            }

            return View(matches);
        }
    }
}