﻿namespace SportPredictionsSystem.Web
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);

            RegisterStyles(bundles);
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/styles/bootstrap.css",
                    "~/Content/styles/site.css",
                    "~/Content/styles/override.css"));

            bundles.Add(new StyleBundle("~/Content/administration-css").Include(
                    "~/Content/styles/administration/bootstrap.css",
                    "~/Content/styles/administration/metisMenu.css",
                    "~/Content/styles/administration/sb-admin-2.css",
                    "~/Content/styles/administration/timeline.css"));
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/administration-layout").Include(
                        "~/Scripts/administration/metisMenu.js",
                        "~/Scripts/administration/sb-admin-2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
        }
    }
}
