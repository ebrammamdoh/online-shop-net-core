using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public string UserId { get; set; }
    }
}
