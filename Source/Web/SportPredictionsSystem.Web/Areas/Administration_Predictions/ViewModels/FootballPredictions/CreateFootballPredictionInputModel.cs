namespace SportPredictionsSystem.Web.Areas.Administration_Predictions.ViewModels.FootballPredictions
{
    using System;

    using SportPredictionsSystem.Common.Mapping;
    using SportPredictionsSystem.Data.Models;

    public class CreateFootballPredictionInputModel : IMapTo<FootballPrediction>
    {
        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public string Prediction { get; set; }

        public decimal Odd { get; set; }

        public DateTime MatchTime { get; set; }
    }
}