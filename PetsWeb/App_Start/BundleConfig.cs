using System.Web.Optimization;

namespace Pets_Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //var lessBundle = new Bundle("~/My/Less").IncludeDirectory("~/My", "*.less");
            //lessBundle.Transforms.Add(new LessTransform());
            //lessBundle.Transforms.Add(new CssMinify());
            //bundles.Add(lessBundle);
            BundleTable.EnableOptimizations = true;


            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                 "~/Scripts/app/job.js"


                ));
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                     "~/Scripts/jquery-{version}.js",



                  "~/Scripts/jquery.min.js",

                              "~/Scripts/bootstrap.min.js",


                               "~/Scripts/metisMenu.min.js",
                                "~/Scripts/raphael.min.js",

                                "~/Scripts/sb-admin-2.js",

                                 "~/Scripts/bootbox.js",
                                  "~/Scripts/respond.js",

                                      "~/Scripts/jquery.js",

                                  "~/Scripts/datatables/jquery.datatables.js",
                                  "~/Scripts/datatables/datatables.bootstrap.js",
                                        "~/Scripts/toastr.js",

                                          "~/Scripts/typeahead.bundle.js",
                                          "~/Scripts/toastr.js",
                                          "~/Scripts/bootstrap-datepicker.min.js",

                                          "~/Scripts/jquery-1.11.3.min.js",
                                           "~/Scripts/bootstrap-datepicker.js",


                                                  "~/Scripts/jquery-1.12.4.js",
                                                    "~/Scripts/jquery.dataTables.min.js",
                                                      "~/Scripts/buttons.print.min.js",
                                                       "~/Scripts/dataTables.buttons.min.js",
                                                        "~/Scripts/jszip.min.js",
                                                          "~/Scripts/pdfmake.min.js",
                                                           "~/Scripts/vfs_fonts.js",
                                                            "~/Scripts/buttons.html5.min.js",

                                                             "~/Scripts/moment.js",
                                                              "~/Scripts/moment-with-locales.js",
                                                              "~/Scripts/animate.js",
                                                               "~/Scripts/bootstrap-timepicker.min.js",
                                                                 "~/Scripts/Chart.js",
                                                                     //"~/Scripts/bootstrap-multiselect.js"
                                                                     "~/Scripts/jquery.quicksearch.js",
                                                                   "~/Scripts/jquery.multi-select.js",

                                                                       "~/Scripts/jquery.timepicker.min.js",

                                                                         "~/Scripts/bootstrap-clockpicker.min.js",
                                                                         "~/Scripts/jquery-clockpicker.min.js"
















                            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));



            bundles.Add(new StyleBundle("~/Content/AllMyCss").Include(

              "~/Content/css",
             "~/Content/bootstrap.min.css",
                "~/Content/font-awesome/css/font-awesome.min.css",
                  "~/Content/metisMenu.css",
                     "~/Content/morris.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/typeahead.css",

                       "~/Content/fonts/font-awesome",

                         "~/Content/font-awesome/fonts",
                          "~/Content/toastr.css",


                             "~/Content/sb-admin-2.css",

                              "~/Content/bootstrap-datepicker.css",
                               "~/Content/jquery.dataTables.min.css",
                                "~/Content/buttons.dataTables.min.css",
                                   "~/Content/timepicker.less.css",
                                //"~/Content/bootstrap-multiselect.css",
                                "~/Content/multi-select.css",
                                 "~/Content/multi-select.dev.css",
                                  "~/Content/multi-select.dist.css",

                                    "~/Content/jquery.timepicker.min.css",
                                     "~/Content/bootstrap-clockpicker.min.css",

                                 "~/Content/site.css"





                      ));


            bundles.Add(new StyleBundle("~/Content/AllMyCss-rtl").Include(
                "~/Content/css",
                "~/Content/site-rtl.css",

       "~/Content/bootstrap-rtl.min.css",
          "~/Content/font-awesome/css/font-awesome.min.css",
            "~/Content/metisMenu.css",
               "~/Content/morris.css",
                "~/Content/datatables/css/datatables.bootstrap-rtl.css",
                "~/Content/typeahead.css",

                  "~/Content/fonts/font-awesome",
                       "~/Content/font-awesome/fonts",
                    "~/Content/toastr-rtl.css",
                     "~/Content/toastr.css",

                         "~/Content/sb-admin-rtl.css",

                              "~/Content/bootstrap-datepicker-rtl.css",
                                    "~/Content/jquery.dataTables.min.css",
                                "~/Content/buttons.dataTables.min.css",
                                  "~/Content/timepicker.less.css",
                                     //"~/Content/bootstrap-multiselect.css",
                                     "~/Content/multi-select.css",
                                 "~/Content/multi-select.dev.css",
                                  "~/Content/multi-select.dist.css",
                                       "~/Content/jquery.timepicker.min.css",
                                           "~/Content/bootstrap-clockpicker.min.css",
                                    "~/Content/site.css"



        ));

        }
    }
}
