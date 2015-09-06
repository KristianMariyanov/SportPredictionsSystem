namespace SportPredictionsSystem.Web.ViewModels
{
    using System;

    using SportPredictionsSystem.Common.Mapping;
    using SportPredictionsSystem.Data.Models;

    public class FootballPredictionViewModel : IMapFrom<FootballPrediction>
    {
        public int Id { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public string Prediction { get; set; }

        public DateTime DayOfPrediction { get; set; }

        public decimal Odd { get; set; }

        public string Result { get; set; }

        public bool Win { get; set; }
    }
}