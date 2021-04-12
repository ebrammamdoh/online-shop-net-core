using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Infrastructure.Constants
{
    public static class ConstantRoles
    {
        public const string Admin = "admin";
        public const string Customer = "customer";
    }
    public static class Taxes
    {
        public const decimal PercentageTax = 14;
        public const string TaxCode = "01";
    }
    public static class Discount
    {
        public const decimal DiscountValue = 20;
        public const string DiscountCode = "01";
    }
}
