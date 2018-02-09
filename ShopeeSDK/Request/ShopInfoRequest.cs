using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShopeeSDK.Response;

namespace ShopeeSDK.Request
{
    public class ShopInfoRequest : IRequest<ShopInfoReponse>
   {
       public int Partner_id { get; set; }
       public int Shopid { get; set; }

        public long Timestamp
        {
            get { return TimeStamp.GetTimestamp(); }
        }


        public String ApiName
        {
            get { return "https://partner.staging.shopeemobile.com/api/v1/shop/get"; }
        }

        public void pareParam(IDictionary<String, Object> paramters)
        {
            paramters.Add("partner_id", this.Partner_id);
            paramters.Add("shopid", this.Shopid);
            paramters.Add("timestamp", this.Timestamp);
        }
    }
}
