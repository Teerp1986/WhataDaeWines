using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhataDae__Wine_App
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal? PricePerLineItem { get; set; }
        public decimal? DiscountPerLineItem { get; set; }
        public decimal? TotalPricePerLineItem { get; set; }
        public decimal? TotalDiscountPerLineItem { get; set; }
        public decimal? TotalDiscounts { get; set; }

        public decimal? SaleTotal { get; set; }
    }
}

