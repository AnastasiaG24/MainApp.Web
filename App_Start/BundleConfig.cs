using System.Web.Optimization;

namespace MainApp.Web.App_Start
{
     public static class BundleConfig
     {
          public static void RegisterBundles(BundleCollection bundles)
          {

               bundles.Add(new StyleBundle("~/bundles/style/css")
                    .Include("~/Content/Styles/style.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/bootstrap/css")
                   .Include("~/Content/Styles/bootstrap.min.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/lightbox/css")
                    .Include("~/Content/Scripts/lib/lightbox/css/lightbox.min.css", new CssRewriteUrlTransform()));

               bundles.Add(new StyleBundle("~/bundles/owlcarousel/css")
                   .Include("~/Content/Scripts/lib/lightbox/css/owlcarousel/assets/owl.carousel.min.css", new CssRewriteUrlTransform()));

               bundles.Add(new ScriptBundle("~/bundles/easing/js")
                    .Include("~/Content/Scripts/lib/easing/easing.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/waypoints/js")
                    .Include("~/Content/Scripts/lib/waypoints/waypoints.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/owlcarousel/js")
                    .Include("~/Content/Scripts/lib/owlcarousel/owl.carousel.js"));
               bundles.Add(new ScriptBundle("~/bundles/owlcarouselmin/js")
                    .Include("~/Content/Scripts/lib/owlcarousel/owl.carousel.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/lightbox/js")
                    .Include("~/Content/Scripts/lib/lightbox/lightbox.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/main/js")
                    .Include("~/Content/Scripts/main.js"));


          }
     }
}