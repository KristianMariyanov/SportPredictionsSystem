namespace SportPredictionsSystem.Web.Areas.Administration_Predictions.ViewModels.FootballPredictions
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using SportPredictionsSystem.Common.Mapping;
    using SportPredictionsSystem.Data.Models;

    public class FootballPredictionViewModel : IMapFrom<FootballPrediction>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Отбор - домакин")]
        public string HomeTeam { get; set; }

        [Display(Name = "Отбор - гост")]
        public string AwayTeam { get; set; }

        [Display(Name = "Прогноза")]
        public string Prediction { get; set; }

        [Display(Name = "Коефициент")]
        public decimal Odd { get; set; }

        [Display(Name = "Начало на мача")]
        public DateTime MatchTime { get; set; }

        [Display(Name = "Създадена на")]
        public DateTime CreatedOn { get; set; }
    }
}