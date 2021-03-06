﻿namespace SportPredictionsSystem.Web.Areas.Administration_Users.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using SportPredictionsSystem.Common.Mapping;
    using SportPredictionsSystem.Data.Models;

    public class UserViewModel : IMapFrom<User>
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }

        [Display(Name = "Имена")]
        public string DisplayName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Държава")]
        public string CountryName { get; set; }

        [Display(Name = "Има ли плащане")]
        public bool HasPayment { get; set; }

        [Display(Name = "Регистриран на")]
        public string CreatedOn { get; set; }
    }
}