using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PetsWeb.ViewModels
{
    public class ORDER_HEADERViewModel
    {
        public int ORDER_TYPE { get; set; }
        public int ORDER_KIND { get; set; }
        public string VOUCHER_DATE { get; set; }
        public int POINT_OF_SALE_NUMBER { get; set; }
        public int STORE_NUMBER { get; set; }
        public string VOUCHER_NUMBER { get; set; }
        public int VOUCHER_SERIAL { get; set; }
        public float TOTAL { get; set; }
        public float TOTAL_DISCOUNT { get; set; }
        public float TOTAL_LINE_DISCOUNT { get; set; }
        public float ALL_DISCOUNT { get; set; }
        public float TOTAL_SERVICES { get; set; }
        public float TOTAL_TAX { get; set; }
        public float TOTAL_SERVICES_TAX { get; set; }
        public float SUB_TOTAL { get; set; }
        public float AMOUNT_DUE { get; set; }
        public float DELIVERY_CHARGE { get; set; }
        public int TABLE_NUMBER { get; set; }
        public int SECTION_NUMBER { get; set; }
        public float CASH_VALUE { get; set; }
        public float CARDS_VALUE { get; set; }
        public float CHEQUE_VALUE { get; set; }

        public float COUPON_VALUE { get; set; }
        public float GIFT_VALUE { get; set; }
        public float POINT_VALUE { get; set; }
        public string USER_NAME { get; set; }
        public int USER_NO { get; set; }
        public string SHIFT_NAME { get; set; }
        public int SHIFT_NUMBER { get; set; }
        public string WAITER { get; set; }

        public int SEATS_NUMBER { get; set; }
        public string TIME { get; set; }
        public string INDATE { get; set; }

        [DefaultValue("01/01/2019")]
        [Display(Name = "FromDate", ResourceType = typeof(Resources.Resource))]
        public DateTime FromDate { get; set; }

        [DefaultValue("31/12/2019")]
        [DisplayName("To Date")]
        [Display(Name = "ToDate", ResourceType = typeof(Resources.Resource))]
        public DateTime ToDate { get; set; }



        [Display(Name = "Sales", ResourceType = typeof(Resources.Resource))]
        public float Sales { get; set; }

        [Display(Name = "Return", ResourceType = typeof(Resources.Resource))]
        public float Return { get; set; }

        [Display(Name = "NetSales", ResourceType = typeof(Resources.Resource))]
        public float NetSales { get; set; }




        [Display(Name = "CashValue", ResourceType = typeof(Resources.Resource))]
        public float CashValue { get; set; }


        [Display(Name = "VisaValue", ResourceType = typeof(Resources.Resource))]
        public float VisaValue { get; set; }


        [Display(Name = "MasterValue", ResourceType = typeof(Resources.Resource))]
        public float MasterValue { get; set; }


        [Display(Name = "CreditValue", ResourceType = typeof(Resources.Resource))]
        public float CreditValue { get; set; }


        [Display(Name = "GiftCardValue", ResourceType = typeof(Resources.Resource))]
        public float GiftCardValue { get; set; }


        [Display(Name = "PointValue", ResourceType = typeof(Resources.Resource))]
        public float PointValue { get; set; }


        [Display(Name = "ChequeValue", ResourceType = typeof(Resources.Resource))]
        public float ChequeValue { get; set; }


        [Display(Name = "TotalPayMethod", ResourceType = typeof(Resources.Resource))]
        public float TotalPayMethod { get; set; }


        [Display(Name = "SalesDiscount", ResourceType = typeof(Resources.Resource))]
        public float SalesDiscount { get; set; }

        [Display(Name = "ReturnDiscount", ResourceType = typeof(Resources.Resource))]
        public float ReturnDiscount { get; set; }

        [Display(Name = "NetDiscount", ResourceType = typeof(Resources.Resource))]
        public float NetDiscount { get; set; }

        [Display(Name = "SalesService", ResourceType = typeof(Resources.Resource))]
        public float SalesService { get; set; }

        [Display(Name = "ReturnService", ResourceType = typeof(Resources.Resource))]
        public float ReturnService { get; set; }

        [Display(Name = "NetServcie", ResourceType = typeof(Resources.Resource))]
        public float NetServcie { get; set; }

        public string ResaultMsg { get; set; }
        public int ResalutCode { get; set; }

        [Display(Name = "UserNo", ResourceType = typeof(Resources.Resource))]
        public int UserNo { get; set; }

        [Display(Name = "PosNo", ResourceType = typeof(Resources.Resource))]
        public int PosNo { get; set; }
        public IEnumerable<UserViewModel> User { get; set; }
        public IEnumerable<PosViewModel> Pos { get; set; }







    }
}