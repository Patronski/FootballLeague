using FootballLeague.Data.Models;
using FootballLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FootballLeague.Controllers
{
    public class TeamsController : Controller
    {
        // GET: Teams
        [Route("/")]
        public ActionResult Index()
        {
            var teams = new List<EditTeam>();
            using (FootballLeagueContext db = new FootballLeagueContext())
            {
                teams = db.Teams
                    .Select(x => new EditTeam
                    {
                        Id = x.Id,
                        Name = x.Name
                    })
                    .ToList();
            }

            return View(teams);
        }

        [HttpPost]
        public async Task<ActionResult> Create(string teamName)
        {
            using (FootballLeagueContext db = new FootballLeagueContext())
            {
                if (!db.Teams.Any(x => x.Name == teamName)
                    || string.IsNullOrWhiteSpace(teamName))
                {
                    db.Teams.Add(new Team
                    {
                        Name = teamName,
                        Points = 0
                    });

                    await db.SaveChangesAsync();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            using (FootballLeagueContext db = new FootballLeagueContext())
            {

                var team = db.Teams.Single(x => x.Id == id);

                db.Teams.Remove(team);

                await db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}