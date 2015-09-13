namespace SportPredictionsSystem.Web.Models
{
    using Postal;

    public class NewFootballPredictionEmail : Email
    {
        public string To { get; set; }

        public string UserName { get; set; }

        public string Prediction { get; set; }
    }
}