using System.Web.Mvc;

namespace SportPredictionsSystem.Web.Areas.Administration_Predictions
{
    public class Administration_PredictionsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration_Predictions";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administration_Predictions_default",
                "Administration_Predictions/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}