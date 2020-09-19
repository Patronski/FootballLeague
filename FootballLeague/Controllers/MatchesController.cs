using FootballLeague.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace FootballLeague.Controllers
{
    public class MatchesController : Controller
    {
        // GET: Matches
        [Route("/")]
        public ActionResult Index()
        {
            var matches = new List<Data.Models.Match>();
            using (FootballLeagueContext db = new FootballLeagueContext())
            {
                matches = db.Matches.ToList();
            }

            return View();
        }
    }
}