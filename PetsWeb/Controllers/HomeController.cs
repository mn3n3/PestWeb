using Pets_Web.Helpers;
using Pets_Web.Persistence;
using Pets_Web.Repositories;
using Pets_Web.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Pets_Web.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        [AllowAnonymous]
        public ActionResult SetCulture(string culture)
        {
            // Validate input

            culture = CultureHelper.GetImplementedCulture(culture);
            //  RouteData.Values["culture"] = culture;  // set culture
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }

            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            string UserNo = "";
            string PosNo = "";
            SearchViewModel search = new SearchViewModel
            {
                FromDate = DateTime.Parse("01/01/2019"),
                ToDate = DateTime.Now.AddDays(1)
            };


            string ResaultMsg = "تمت العملية بنجاح";
            try
            {
                using (WebClient httpClient = new WebClient())
                {
                    string Url = "http://falconssoft.net/RestService/FSAppServiceDLL.dll/GetCashRepH?compno=736&compyear=2019&POSNO=" + PosNo + "&FromDate=" + search.FromDate.ToString("dd/MM/yyyy") + "&ToDate=" + search.ToDate.ToString("dd/MM/yyyy") + "&userno=" + UserNo + "&SHIFTNO=''";

                    var jsonData = httpClient.DownloadString(Url);
                    if (jsonData == null)
                    {
                        ORDER_HEADERViewModel ObjNull = new ORDER_HEADERViewModel();
                        ObjNull.ResalutCode = 1;
                        ObjNull.ResaultMsg = "لا يوجد بيانات ";
                        return Json(ObjNull, JsonRequestBehavior.AllowGet);

                    }
                    var data = JsonConvert.DeserializeObject<IEnumerable<ORDER_HEADERViewModel>>(jsonData);
                    var OrderHeaderTest = data;






                    float Sales = data.Where(m => m.ORDER_KIND == 0).Sum(m => m.AMOUNT_DUE);
                    float Return = data.Where(m => m.ORDER_KIND == 1).Sum(m => m.AMOUNT_DUE);
                    float NetSales = Sales + Return;



                    float SalesDiscount = data.Where(m => m.ORDER_KIND == 0).Sum(m => m.ALL_DISCOUNT);
                    float ReturnDiscount = data.Where(m => m.ORDER_KIND == 1).Sum(m => m.ALL_DISCOUNT);

                    float NetDiscount = data.Sum(m => m.TOTAL_DISCOUNT);



                    float SalesService = data.Where(m => m.ORDER_KIND == 0).Sum(m => m.TOTAL_SERVICES);
                    float ReturnService = data.Where(m => m.ORDER_KIND == 1).Sum(m => m.TOTAL_SERVICES);
                    float NetServcie = data.Where(m => m.ORDER_KIND == 1).Sum(m => m.NetDiscount);



                    float CashValue = data.Sum(m => m.CashValue);
                    float CreditValue = data.Sum(m => m.COUPON_VALUE);
                    float GiftCardValue = data.Sum(m => m.GIFT_VALUE);
                    float PointValue = data.Sum(m => m.POINT_VALUE);
                    float ChequeValue = data.Sum(m => m.CHEQUE_VALUE);




                    float TotalPayMethod = CashValue + CreditValue + GiftCardValue + PointValue + ChequeValue;
                    ORDER_HEADERViewModel Obj = new ORDER_HEADERViewModel();
                    Obj.Sales = Sales;
                    Obj.Return = Return;
                    Obj.NetSales = NetSales;

                    Obj.SalesDiscount = SalesDiscount;
                    Obj.ReturnDiscount = ReturnDiscount;

                    Obj.SalesService = SalesService;
                    Obj.ReturnService = ReturnService;

                    Obj.CashValue = CashValue;
                    Obj.CreditValue = CreditValue;
                    Obj.GiftCardValue = GiftCardValue;
                    Obj.PointValue = PointValue;
                    Obj.ChequeValue = ChequeValue;

                    Obj.TotalPayMethod = TotalPayMethod;
                    float Visa = 0;
                    float Master = 0;
                    try
                    {
                        string UrlPayMethod = "http://falconssoft.net/RestService/FSAppServiceDLL.dll/GetCashRepP?compno=736&compyear=2019&POSNO=" + PosNo + "&FromDate=" + search.FromDate.ToString("dd/MM/yyyy") + "&ToDate=" + search.ToDate.ToString("dd/MM/yyyy") + "&userno=" + UserNo + "&SHIFTNO=''";

                        var jsonDataPayMethod = httpClient.DownloadString(UrlPayMethod);
                        var datajsonDataPayMethod = JsonConvert.DeserializeObject<IEnumerable<PAY_METHODViewModel>>(jsonDataPayMethod);
                        var PayMethod = datajsonDataPayMethod;
                        Visa = PayMethod.Where(m => m.PAY_TYPE == "Visa").Sum(m => m.PAY_VALUE);
                        Master = PayMethod.Where(m => m.PAY_TYPE == "Master").Sum(m => m.PAY_VALUE);

                    }
                    catch (Exception ex)
                    {
                        Visa = 0;
                        Master = 0;
                        Obj.ResalutCode = 1;
                        Obj.ResaultMsg = "No Data In PayMethod " + ex.Message;

                    }

                    Obj.VisaValue = Visa;
                    Obj.MasterValue = Master;

                    return View(Obj);
                }

            }
            catch (Exception ex)
            {//ErrorCode
                ORDER_HEADERViewModel Obj = new ORDER_HEADERViewModel();
                //  var s = jsonData.;
                Obj.ResaultMsg = "No Data Found";
                Obj.ResalutCode = 2;
                return View(Obj);

            }


        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SalesTotal()
        {
            ViewBag.Message = "Your contact page.";
            ORDER_HEADERViewModel Obj = new ORDER_HEADERViewModel();
            Obj.FromDate = DateTime.Parse("01/01/2019");
            Obj.ToDate = DateTime.Parse("31/12/2019");




            Obj.User = new List<UserViewModel>();
            Obj.Pos = new List<PosViewModel>();

            try
            {
                using (WebClient httpClient = new WebClient() { Encoding = Encoding.UTF8 })
                {
                    var jsonData = httpClient.DownloadString("http://falconssoft.net/RestService/FSAppServiceDLL.dll/GetBranches?compno=736&compyear=2019");
                    var data = JsonConvert.DeserializeObject<IEnumerable<PosViewModel>>(jsonData);
                    Obj.Pos = data;
                }


            }
            catch
            {
                Obj.Pos = new List<PosViewModel>();
            }



            try
            {
                using (WebClient httpClient = new WebClient() { Encoding = Encoding.UTF8 })
                {
                    var jsonData = httpClient.DownloadString("http://falconssoft.net/RestService/FSAppServiceDLL.dll/Getusers?compno=736&compyear=2019");
                    var data = JsonConvert.DeserializeObject<IEnumerable<UserViewModel>>(jsonData);
                    Obj.User = data;
                }


            }
            catch
            {
                Obj.User = new List<UserViewModel>();
            }





            Obj.PosNo = 0;
            Obj.UserNo = 0;
            return View(Obj);
        }

        public ActionResult GetOrderHeader()
        {
            IEnumerable<ORDER_HEADERViewModel> OrderHeader = null;

            using (WebClient httpClient = new WebClient())
            {
                var jsonData = httpClient.DownloadString("http://falconssoft.net/RestService/FSAppServiceDLL.dll/GetCashRepH?compno=736&compyear=2019&POSNO=1&FromDate=01/01/2019&ToDate=31/12/2019&userno=''&SHIFTNO=''");
                var data = JsonConvert.DeserializeObject<IEnumerable<ORDER_HEADERViewModel>>(jsonData);
                var OrderHeaderTest = data;

                float Sales = data.Where(m => m.ORDER_KIND == 0).Sum(m => m.AMOUNT_DUE);
                float Return = data.Where(m => m.ORDER_KIND == 1).Sum(m => m.AMOUNT_DUE);
                float NetSales = Sales + Return;



                float SalesDiscount = data.Where(m => m.ORDER_KIND == 0).Sum(m => m.ALL_DISCOUNT);
                float ReturnDiscount = data.Where(m => m.ORDER_KIND == 1).Sum(m => m.ALL_DISCOUNT);




                float SalesService = data.Where(m => m.ORDER_KIND == 0).Sum(m => m.TOTAL_SERVICES);
                float ReturnService = data.Where(m => m.ORDER_KIND == 1).Sum(m => m.TOTAL_SERVICES);

                float CashValue = data.Sum(m => m.CashValue);
                float CreditValue = data.Sum(m => m.CreditValue);
                float GiftCardValue = data.Sum(m => m.GIFT_VALUE);
                float PointValue = data.Sum(m => m.POINT_VALUE);
                float ChequeValue = data.Sum(m => m.CHEQUE_VALUE);



                ORDER_HEADERViewModel Obj = new ORDER_HEADERViewModel();
                Obj.Sales = Sales;
                Obj.Return = Return;
                Obj.NetSales = NetSales;

                Obj.SalesDiscount = SalesDiscount;
                Obj.ReturnDiscount = ReturnDiscount;

                Obj.SalesService = SalesService;
                Obj.ReturnService = ReturnService;

                Obj.CashValue = CashValue;
                Obj.CreditValue = CreditValue;
                Obj.GiftCardValue = GiftCardValue;
                Obj.PointValue = PointValue;
                Obj.ChequeValue = ChequeValue;



                //   float VisaValue = data.Sum(m => m.v);


                return View("PhotoAlbum", Obj);
            }

        }
        [HttpPost]
        public JsonResult GetSalesTotal(SearchViewModel search)
        {
            string UserNo = search.USER_NO.ToString();
            string PosNo = search.BRANCHNO.ToString();
            if (UserNo == "0")
            {
                UserNo = "";
            }
            if (PosNo == "0")
            {
                PosNo = "";
            }
            string ResaultMsg = "تمت العملية بنجاح";
            try
            {
                using (WebClient httpClient = new WebClient())
                {
                    string Url = "http://falconssoft.net/RestService/FSAppServiceDLL.dll/GetCashRepH?compno=736&compyear=2019&POSNO=" + PosNo + "&FromDate=" + search.FromDate.ToString("dd/MM/yyyy") + "&ToDate=" + search.ToDate.ToString("dd/MM/yyyy") + "&userno=" + UserNo + "&SHIFTNO=''";

                    var jsonData = httpClient.DownloadString(Url);
                    if (jsonData == null)
                    {
                        ORDER_HEADERViewModel ObjNull = new ORDER_HEADERViewModel();
                        ObjNull.ResalutCode = 1;
                        ObjNull.ResaultMsg = "لا يوجد بيانات ";
                        return Json(ObjNull, JsonRequestBehavior.AllowGet);

                    }
                    var data = JsonConvert.DeserializeObject<IEnumerable<ORDER_HEADERViewModel>>(jsonData);
                    var OrderHeaderTest = data;






                    float Sales = data.Where(m => m.ORDER_KIND == 0).Sum(m => m.AMOUNT_DUE);
                    float Return = data.Where(m => m.ORDER_KIND == 1).Sum(m => m.AMOUNT_DUE);
                    float NetSales = Sales + Return;



                    float SalesDiscount = data.Where(m => m.ORDER_KIND == 0).Sum(m => m.ALL_DISCOUNT);
                    float ReturnDiscount = data.Where(m => m.ORDER_KIND == 1).Sum(m => m.ALL_DISCOUNT);

                    float NetDiscount = data.Sum(m => m.TOTAL_DISCOUNT);



                    float SalesService = data.Where(m => m.ORDER_KIND == 0).Sum(m => m.TOTAL_SERVICES);
                    float ReturnService = data.Where(m => m.ORDER_KIND == 1).Sum(m => m.TOTAL_SERVICES);
                    float NetServcie = data.Where(m => m.ORDER_KIND == 1).Sum(m => m.NetDiscount);



                    float CashValue = data.Sum(m => m.CashValue);
                    float CreditValue = data.Sum(m => m.COUPON_VALUE);
                    float GiftCardValue = data.Sum(m => m.GIFT_VALUE);
                    float PointValue = data.Sum(m => m.POINT_VALUE);
                    float ChequeValue = data.Sum(m => m.CHEQUE_VALUE);




                    float TotalPayMethod = CashValue + CreditValue + GiftCardValue + PointValue + ChequeValue;
                    ORDER_HEADERViewModel Obj = new ORDER_HEADERViewModel();
                    Obj.Sales = Sales;
                    Obj.Return = Return;
                    Obj.NetSales = NetSales;

                    Obj.SalesDiscount = SalesDiscount;
                    Obj.ReturnDiscount = ReturnDiscount;

                    Obj.SalesService = SalesService;
                    Obj.ReturnService = ReturnService;

                    Obj.CashValue = CashValue;
                    Obj.CreditValue = CreditValue;
                    Obj.GiftCardValue = GiftCardValue;
                    Obj.PointValue = PointValue;
                    Obj.ChequeValue = ChequeValue;

                    Obj.TotalPayMethod = TotalPayMethod;
                    float Visa = 0;
                    float Master = 0;
                    try
                    {
                        string UrlPayMethod = "http://falconssoft.net/RestService/FSAppServiceDLL.dll/GetCashRepP?compno=736&compyear=2019&POSNO=" + PosNo + "&FromDate=" + search.FromDate.ToString("dd/MM/yyyy") + "&ToDate=" + search.ToDate.ToString("dd/MM/yyyy") + "&userno=" + UserNo + "&SHIFTNO=''";

                        var jsonDataPayMethod = httpClient.DownloadString(UrlPayMethod);
                        var datajsonDataPayMethod = JsonConvert.DeserializeObject<IEnumerable<PAY_METHODViewModel>>(jsonDataPayMethod);
                        var PayMethod = datajsonDataPayMethod;
                        Visa = PayMethod.Where(m => m.PAY_TYPE == "Visa").Sum(m => m.PAY_VALUE);
                        Master = PayMethod.Where(m => m.PAY_TYPE == "Master").Sum(m => m.PAY_VALUE);

                    }
                    catch (Exception ex)
                    {
                        Visa = 0;
                        Master = 0;
                        Obj.ResalutCode = 1;
                        Obj.ResaultMsg = "No Data In PayMethod " + ex.Message;

                    }

                    Obj.VisaValue = Visa;
                    Obj.MasterValue = Master;
                    //   float VisaValue = data.Sum(m => m.v);


                    //  return View("PhotoAlbum", Obj);
                    return Json(Obj, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {//ErrorCode
                ORDER_HEADERViewModel Obj = new ORDER_HEADERViewModel();
                //  var s = jsonData.;
                Obj.ResaultMsg = "No Data Found";
                Obj.ResalutCode = 2;
                return Json(Obj, JsonRequestBehavior.AllowGet);
            }






        }

    }
}