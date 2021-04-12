using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Services.Models
{
    public class ItemsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Attributes { get; set; }
        public string Description { get; set; }
        public string UOM { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
