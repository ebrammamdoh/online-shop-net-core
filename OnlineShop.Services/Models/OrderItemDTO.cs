using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShop.Services.Models
{
    public class OrderItemDTO
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
