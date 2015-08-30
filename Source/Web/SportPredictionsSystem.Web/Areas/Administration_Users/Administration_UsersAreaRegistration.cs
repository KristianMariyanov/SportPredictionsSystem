namespace SportPredictionsSystem.Web.Areas.Administration_Users
{
    using System.Web.Mvc;

    public class Administration_UsersAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Administration_Users";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administration_Users_default",
                "Administration_Users/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}