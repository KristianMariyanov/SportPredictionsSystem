namespace SportPredictionsSystem.Web.Areas.Administration_Predictions.InputModels.FootballPredictions
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using SportPredictionsSystem.Common.Constants;
    using SportPredictionsSystem.Common.Mapping;
    using SportPredictionsSystem.Data.Models;

    public class EditFootballPredictionInputModel : BaseFootballPredictionInputModel, IMapFrom<FootballPrediction>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Резултат")]
        [StringLength(
           ValidationConstants.PredictionMaxLenght,
           MinimumLength = ValidationConstants.PredictionMinLenght,
           ErrorMessage = "Резултата трябва да е между {2} и {1} символа дълга!")]
        public string Result { get; set; }

        [Display(Name = "Печалба?")]
        public bool Win { get; set; }
    }
}