﻿using System;

namespace Pets_Web.ViewModels
{
    public class SearchViewModel
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int BRANCHNO { get; set; }
        public int USER_NO { get; set; }
    }
}