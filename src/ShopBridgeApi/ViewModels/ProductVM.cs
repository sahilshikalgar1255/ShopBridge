using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeApi.ViewModels
{
    public class ProductVM
    {
        public int product_id { get; set; }
        
        public string product_name { get; set; }
        public string product_desc { get; set; }
     
        public double price { get; set; }
        public int create_user { get; set; }
        public int modify_user { get; set; }
        public DateTime create_ts { get; set; }
        public DateTime modify_ts { get; set; }
    }
}
