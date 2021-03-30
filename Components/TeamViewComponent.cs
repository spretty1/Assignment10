using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment10.Models;

namespace Assignment10.Components
{
    public class TeamViewComponent: ViewComponent
    {
        //brings in the context model and sets it 
        private BowlingLeagueContext context;
        public TeamViewComponent (BowlingLeagueContext ctx)
        {
            context = ctx; 
        }
        public IViewComponentResult Invoke()
        {
            //lets the program know what team is currently selected which allows that button to be lit up as well as the title dynamically added
            ViewBag.SelectedCategory = RouteData?.Values["team"];
            //ensures that a team is only displayed once on the navigation between teams 
            return View(context.Teams
                .Distinct()
                .OrderBy(x => x)
                );
        }
    }
}
