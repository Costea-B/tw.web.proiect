using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace WebApplication1.App_Start
{
     public static class BundelConfig
     {
          public static void RegisterBundles(BundleCollection bundles)
          {

               // Bundle-ul CSS
               bundles.Add(new StyleBundle("~/bundles/css").Include(
                         "~/Templaid/css/bootstrap.min.css", new CssRewriteUrlTransform()));

               // CSS-ul aplicației
               bundles.Add(new StyleBundle("~/bundles/app/css").Include("~/Templaid/css/icons.min.css", "~/Templaid/css/app.min.css")
                    .Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));

               //Vndor js
               bundles.Add(new ScriptBundle("~/vendor/js").Include(
                   "~/Templaid/js/vendor.min.js"
                   ));

               // App js
               bundles.Add(new ScriptBundle("~/app/js").Include(
                  "~/Templaid/js/app.min.js"
                  ));

               //Index js

               bundles.Add(new ScriptBundle("~/index/js").Include(
                    "~/Templaid/libs/apexcharts/apexcharts.min.js",
                    "~/Templaid/libs/peity/jquery.peity.min.js",
                    "~/ Templaid/libs/jquery-sparkline/jquery.sparkline.min.js",
                    "~/Templaid/js/pages/dashboard-1.init.js"
                    ));

               //Deshbord2 js
               bundles.Add(new ScriptBundle("~/dashbord/js").Include(
                    "~/Templaid/libs/jquery-knob/jquery.knob.min.js",
                    "~/Templaid/libs/jquery-sparkline/jquery.sparkline.min.js",
                    "~/ Templaid/libs/jquery-vectormap/jquery-jvectormap-1.2.2.min.js",
                    "~/ Templaid/libs/jquery-vectormap/jquery-jvectormap-world-mill-en.js",
                    "~/ Templaid/libs/peity/jquery.peity.min.js",
                    "~/Templaid/js/pages/dashboard-2.init.js"
                    ));

               //Calendar js
               bundles.Add(new ScriptBundle("~/calendar/js").Include(
                    "~/Templaid/libs/moment/moment.min.js",
                    "~/Templaid/libs/jquery-ui/jquery-ui.min.js",
                    "~/ Templaid/libs/fullcalendar/fullcalendar.min.js",
                    "~/ Templaid/js/pages/calendar.init.js"
                    ));

               //Companies js
               bundles.Add(new ScriptBundle("~/companies/js").Include(
                    "~/Templaid/libs/jquery-sparkline/jquery.sparkline.min.js",
                    "~/Templaid/libs/custombox/custombox.min.js",
                    "~/ Templaid/js/pages/companies.js"
                    ));
          }
     }
}