namespace SportPredictionsSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using SportPredictionsSystem.Data;
    using SportPredictionsSystem.Web.ViewModels;

    public class HomeController : BaseController
    {

        public HomeController(ISportPredictionsSystemData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var prediction = this.Data.FootballPredictions
                .All()
                .OrderByDescending(x => x.DayOfPrediction)
                .Take(30)
                .ProjectTo<FootballPredictionViewModel>()
                .ToList();

            return this.View(prediction);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}