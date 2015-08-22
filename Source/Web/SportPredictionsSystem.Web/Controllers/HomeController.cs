namespace SportPredictionsSystem.Web.Controllers
{
    using System.Web.Mvc;

    using SportPredictionsSystem.Data;

    public class HomeController : Controller
    {
        private ISportPredictionsSystemData data;

        public HomeController(ISportPredictionsSystemData data)
        {
            this.data = data;
        }

        public ActionResult Index()
        {
            //var a = this.data.FootballPredictions.All();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}