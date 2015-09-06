using System.Web.Mvc;

namespace SportPredictionsSystem.Web.Areas.Administration_Users.Controllers
{
    using System.Linq;
    using System.Net;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using SportPredictionsSystem.Data;
    using SportPredictionsSystem.Data.Models;
    using SportPredictionsSystem.Web.Areas.Administration_Predictions.InputModels.FootballPredictions;
    using SportPredictionsSystem.Web.Areas.Administration_Predictions.ViewModels.FootballPredictions;
    using SportPredictionsSystem.Web.Areas.Administration_Users.InputModels.Users;
    using SportPredictionsSystem.Web.Areas.Administration_Users.ViewModels.Users;
    using SportPredictionsSystem.Web.Controllers;

    public class UsersController : BaseController
    {
        public UsersController(ISportPredictionsSystemData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View(this.Data.Users.All().Project().To<UserViewModel>().ToList());
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = this.Data.Users.All().Project().To<EditUserInputModel>().FirstOrDefault();

            if (user == null)
            {
                return this.HttpNotFound();
            }

            this.ViewBag.Countries = this.Data.Countries.All().Select(x => new SelectListItem { Text = x.NameEn, Value = x.Id.ToString() });

            return this.View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditUserInputModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.Data.Users.GetById(inputModel.Id);
                var entityForUpdate = Mapper.Map(inputModel, entity);
                this.Data.Users.Update(entityForUpdate);
                this.Data.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(inputModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var footballPrediction = this.Data.FootballPredictions
                .All()
                .Where(fp => fp.Id == id)
                .Project()
                .To<FootballPredictionViewModel>()
                .FirstOrDefault();

            if (footballPrediction == null)
            {
                return this.HttpNotFound();
            }

            return this.View(footballPrediction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var footballPrediction = this.Data.FootballPredictions.GetById(id);
            this.Data.FootballPredictions.Delete(footballPrediction);
            this.Data.SaveChanges();
            return this.RedirectToAction("Index");
        }
    }
}