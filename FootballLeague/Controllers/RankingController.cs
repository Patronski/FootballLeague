using FootballLeague.Data.Models;
using FootballLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootballLeague.Controllers
{
    public class RankingController : Controller
    {
        // GET: Home
        [Route("/")]
        public ActionResult Index()
        {
            var teams = new List<Team>();
            using (FootballLeagueContext db = new FootballLeagueContext())
            {
                teams = db.Teams.OrderByDescending(x => x.Points).ToList();
            }

            return View(teams);
        }
    }
}