using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage="请输入名字")]
        public string Name { get; set; }
        [Required(ErrorMessage = "请输入第一个地址")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "请输入城市名")]
        public string City { get; set; }
        [Required(ErrorMessage = "请输入州名")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "请输入国名")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
