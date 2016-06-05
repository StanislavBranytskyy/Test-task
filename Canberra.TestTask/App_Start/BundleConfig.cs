using System.Web.Optimization;

namespace Canberra.TestTask
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            var angularBundle = new ScriptBundle("~/bundles/app");
            angularBundle.Include("~/Scripts/Dependencies/angular.min.js");
            angularBundle.Include("~/Scripts/App/app.js");
            angularBundle.Include("~/Scripts/App/directives/pagination.js");
            angularBundle.Include("~/Scripts/App/controllers/employeesController.js");

            bundles.Add(angularBundle);

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Css/bootstrap.css",
                      "~/Content/Css/site.css"));
        }
    }
}
