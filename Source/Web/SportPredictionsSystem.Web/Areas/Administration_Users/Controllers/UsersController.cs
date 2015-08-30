using System.Web.Mvc;

namespace SportPredictionsSystem.Web.Areas.Administration_Users.Controllers
{
    using AutoMapper.QueryableExtensions;

    using SportPredictionsSystem.Data;
    using SportPredictionsSystem.Web.Controllers;

    public class UsersController : BaseController
    {
        public UsersController(ISportPredictionsSystemData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            var users = this.Data.Users.All().ProjectTo<UserViewModel>();
            return View();
        }
    }
}