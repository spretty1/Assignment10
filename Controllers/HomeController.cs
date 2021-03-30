using Assignment10.Models;
using Assignment10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx; 
        }

        //brings in the needed team id and team and page num for pagination and to know what to return in the view
        public IActionResult Index(long? teamid, string team, int pageNum = 0)
        { //establishes that only 5 items should be per page
            int pageSize = 5;
             

            return View(new IndexViewModel
            {   //looks to see if the user picked a team and filters it if they have
                Bowlers = context.Bowlers
                .Where(t => t.TeamId == teamid || teamid == null)
                //orders alphabetically
                .OrderBy(t => t.BowlerFirstName)
                //ensures the proper info is displayed per page
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList(),

                PageNumberingInfo = new PageNumberingInfo
                {   //sets the num of items per page, the page they are on, and total num of items
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = (teamid == null ? context.Bowlers.Count() :
                        context.Bowlers.Where(x => x.TeamId == teamid).Count())
                },
                //what team is being called/ if one is 
                BowlingTeam = team
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
