namespace SportPredictionsSystem.Web
{
    using System.Data.Entity;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using SportPredictionsSystem.Common.Mapping;
    using SportPredictionsSystem.Data;
    using SportPredictionsSystem.Data.Migrations;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SportPredictionsSystemDbContext, Configuration>());

            var autoMapperConfig = new AutoMapperConfig(
                new[]
                {
                    Assembly.GetExecutingAssembly()
                });
            autoMapperConfig.Execute();
        }
    }
}
