namespace SportPredictionsSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using SportPredictionsSystem.Common.Constants;
    using SportPredictionsSystem.Data.Contracts;

    public class FootballPrediction : Prediction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.FootballTeamMinLenght)]
        [MaxLength(ValidationConstants.FootballTeamMaxLenght)]
        public string HomeTeam { get; set; }

        [Required]
        [MinLength(ValidationConstants.FootballTeamMinLenght)]
        [MaxLength(ValidationConstants.FootballTeamMaxLenght)]
        public string AwayTeam { get; set; }

        [Required]
        [MinLength(ValidationConstants.PredictionMinLenght)]
        [MaxLength(ValidationConstants.PredictionMaxLenght)]
        public string Prediction { get; set; }
    }
}
