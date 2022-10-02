using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaytRSS.Helper;
using BaytRSS.Models;

namespace BaytRSS.Controllers
{
    public class CareersController : Controller
    {
        public static List<Career> careers;
        public CareersController()
        {
            if(careers == null)
                careers = Career.RetrieveAllCareers("https://www.rotanacareers.com/", "live-bookmarks/all-rss.xml");
        }
        // GET: Careers
        public ActionResult Index()
        {
            var sortedCareers = careers.OrderBy(car => car.Title);
            return View(sortedCareers);
        }

        public ActionResult CarrerById(string id)
        {
            var career = careers.FirstOrDefault(car => car.Id.ToString() == id);
            return View(career);
        }
    }
}