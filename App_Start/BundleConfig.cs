using System.Web.Optimization;
using System.Web.UI;

namespace MainApp.Web.App_Start
{
     public static class BundleConfig
     {
          public static void RegisterBundles(BundleCollection bundles)
          {

               bundles.Add(new StyleBundle("~/bundles/template-css")
    .Include("~/Content/Styles/bootstrap.min.css", new CssRewriteUrlTransform())
    .Include("~/Content/Styles/style.css", new CssRewriteUrlTransform())
    .Include("~/Content/Scripts/lib/lightbox/css/lightbox.min.css", new CssRewriteUrlTransform())
    .Include("~/Content/Scripts/lib/owlcarousel/assets/owl.carousel.min.css", new CssRewriteUrlTransform()));


               bundles.Add(new ScriptBundle("~/bundles/template-js").Include(
     "~/Content/Scripts/lib/bootstrap/bootstrap.bundle.min.js",
     "~/Content/Scripts/lib/easing/easing.min.js",
     "~/Content/Scripts/lib/waypoints/waypoints.min.js",
     "~/Content/Scripts/lib/owlcarousel/owl.carousel.min.js",
     "~/Content/Scripts/lib/lightbox/lightbox.min.js",
     "~/Content/Scripts/main.js"));
               BundleTable.EnableOptimizations = true;

          }
     }
}

    