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
        public ActionResult Index()
        {
            var teams = new List<Team>();
            using(FootballLeagueContext db = new FootballLeagueContext())
            {
                teams = db.Teams.ToList();
            }

            return View(teams);
        }
    }
}