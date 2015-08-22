namespace SportPredictionsSystem.Data.Models
{
    using SportPredictionsSystem.Data.Contracts;

    public class FootballPrediction : Prediction
    {
        public int Id { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public string Prediction { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
