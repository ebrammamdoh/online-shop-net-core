using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.WebApi.Models
{
    public class OrderItemModel
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
