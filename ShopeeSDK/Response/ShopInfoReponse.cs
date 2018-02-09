using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopeeSDK.Response
{
    public class ShopInfoReponse : BaseResponse
    {
        public int shop_id { get; set; }
        public string shop_name { get; set; }
        public string country { get; set; }
        public string shop_description { get; set;}
        public List<string> videos { get; set; }
        public List<string> images { get; set; }
    }
}
