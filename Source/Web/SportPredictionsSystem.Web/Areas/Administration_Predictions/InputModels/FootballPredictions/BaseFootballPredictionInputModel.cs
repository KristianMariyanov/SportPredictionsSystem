namespace SportPredictionsSystem.Web.Areas.Administration_Predictions.InputModels.FootballPredictions
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using SportPredictionsSystem.Common.Constants;
    using SportPredictionsSystem.Common.Mapping;
    using SportPredictionsSystem.Data.Models;

    public class BaseFootballPredictionInputModel : IMapTo<FootballPrediction>
    {
        [Display(Name = "Отбор - домакин")]
        [Required(ErrorMessage = "Името на отбора е задължително!")]
        [StringLength(
           ValidationConstants.FootballTeamMaxLenght,
           MinimumLength = ValidationConstants.FootballTeamMinLenght,
           ErrorMessage = "Името на отбора трябва да е между {2} и {1} символа дълго!")]
        public string HomeTeam { get; set; }

        [Display(Name = "Отбор - гост")]
        [Required(ErrorMessage = "Името на отбора е задължително!")]
        [StringLength(
           ValidationConstants.FootballTeamMaxLenght,
           MinimumLength = ValidationConstants.FootballTeamMinLenght,
           ErrorMessage = "Името на отбора трябва да е между {2} и {1} символа дълго!")]
        public string AwayTeam { get; set; }

        [Display(Name = "Прогноза")]
        [Required(ErrorMessage = "Прогнозата е задължителна!")]
        [StringLength(
           ValidationConstants.PredictionMaxLenght,
           MinimumLength = ValidationConstants.PredictionMinLenght,
           ErrorMessage = "Прогнозата трябва да е между {2} и {1} символа дълга!")]
        public string Prediction { get; set; }

        [Display(Name = "Коефициент")]
        [Range(1, 1000, ErrorMessage = "Коефициента трябва да е число между {1} и {2}!")]
        public decimal Odd { get; set; }

        [Display(Name = "Начало на мача")]
        public DateTime MatchTime { get; set; }

        [Display(Name = "Дата на прогнозата")]
        public DateTime DayOfPrediction { get; set; }
    }
}