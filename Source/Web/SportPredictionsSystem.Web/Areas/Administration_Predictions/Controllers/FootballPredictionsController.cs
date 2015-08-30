namespace SportPredictionsSystem.Web.Areas.Administration_Predictions.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using System.Web.UI.HtmlControls;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using SportPredictionsSystem.Data;
    using SportPredictionsSystem.Data.Models;
    using SportPredictionsSystem.Web.Areas.Administration_Predictions.InputModels.FootballPredictions;
    using SportPredictionsSystem.Web.Areas.Administration_Predictions.ViewModels.FootballPredictions;
    using SportPredictionsSystem.Web.Controllers;

    public class FootballPredictionsController : BaseController
    {
        public FootballPredictionsController(ISportPredictionsSystemData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View(this.Data.FootballPredictions.All().Project().To<FootballPredictionViewModel>().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var footballPrediction = this.Data.FootballPredictions.GetById(id);

            if (footballPrediction == null)
            {
                return this.HttpNotFound();
            }

            return this.View(footballPrediction);
        }

        public ActionResult Create()
        {
            return this.View(new BaseFootballPredictionInputModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BaseFootballPredictionInputModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = Mapper.Map<FootballPrediction>(inputModel);

                this.Data.FootballPredictions.Add(entity);
                this.Data.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(inputModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var footballPrediction = this.Data.FootballPredictions.All().Project().To<EditFootballPredictionInputModel>().FirstOrDefault();

            if (footballPrediction == null)
            {
                return this.HttpNotFound();
            }

            return this.View(footballPrediction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditFootballPredictionInputModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.Data.FootballPredictions.GetById(inputModel.Id);
                var entityForUpdate = Mapper.Map(inputModel, entity);
                this.Data.FootballPredictions.Update(entityForUpdate);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Data.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
