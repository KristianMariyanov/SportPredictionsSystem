namespace SportPredictionsSystem.Web.Areas.Administration_Users.ViewModels.Users
{
    using SportPredictionsSystem.Common.Mapping;
    using SportPredictionsSystem.Data.Models;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string CreatedOn { get; set; }
    }
}