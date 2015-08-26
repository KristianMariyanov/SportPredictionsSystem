namespace SportPredictionsSystem.Web.Areas.Administration_Predictions.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper;

    using SportPredictionsSystem.Data;
    using SportPredictionsSystem.Data.Models;
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
            return this.View(this.Data.FootballPredictions.All().ToList());
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
            return this.View(new CreateFootballPredictionInputModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateFootballPredictionInputModel inputModel)
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

            var footballPrediction = this.Data.FootballPredictions.GetById(id);
            if (footballPrediction == null)
            {
                return this.HttpNotFound();
            }

            return this.View(footballPrediction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HomeTeam,AwayTeam,Prediction,MatchTime,Odd,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] FootballPrediction footballPrediction)
        {
            if (this.ModelState.IsValid)
            {
                this.Data.FootballPredictions.Update(footballPrediction);
                this.Data.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(footballPrediction);
        }

        public ActionResult Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
