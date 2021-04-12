using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.WebApi.Models
{
    public class CreateCustomerModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string DescriptionAr { get; set; }
        [Required]
        [MaxLength(100)]
        public string DescriptionEn { get; set; }
    }
}
