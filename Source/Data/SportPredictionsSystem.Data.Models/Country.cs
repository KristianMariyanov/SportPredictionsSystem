namespace SportPredictionsSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using SportPredictionsSystem.Common.Constants;
    using SportPredictionsSystem.Data.Contracts;

    public class Country : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        // TODO: [Required]
        [MaxLength(ValidationConstants.CountryNameMaxLength)]
        public string NameBg { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CountryNameMaxLength)]
        public string NameEn { get; set; }
    }
}
