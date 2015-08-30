namespace SportPredictionsSystem.Web.Areas.Administration_Predictions.InputModels.FootballPredictions
{
    using System.Web.Mvc;

    using SportPredictionsSystem.Common.Mapping;
    using SportPredictionsSystem.Data.Models;

    public class EditFootballPredictionInputModel : BaseFootballPredictionInputModel, IMapFrom<FootballPrediction>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
    }
}