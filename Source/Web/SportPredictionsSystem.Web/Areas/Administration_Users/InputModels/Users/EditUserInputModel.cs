namespace SportPredictionsSystem.Web.Areas.Administration_Users.InputModels.Users
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using SportPredictionsSystem.Common.Mapping;
    using SportPredictionsSystem.Data.Models;

    public class EditUserInputModel : IMapTo<User>, IMapFrom<User>
    {
        [ReadOnly(true)]
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Display(Name = "Потребителско име")]
        [ReadOnly(true)]
        public string UserName { get; set; }

        [Display(Name = "Имена")]
        public string DisplayName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Държава")]
        public int? CountryId { get; set; }

        [Display(Name = "Има ли плащане")]
        public bool HasPayment { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Регистриран на")]
        public string CreatedOn { get; set; }
    }
}