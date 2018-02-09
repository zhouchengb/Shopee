using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShopeeSDK.Response;

namespace ShopeeSDK.Request
{
    public class GetItemDetailRequest : IRequest<GetItemDetailResponse>
    {
        public int Item_ID { get; set; }
        public int Partner_ID { get; set; }
        public int ShopID { get; set; }
        public string ApiName
        {
            get { return "https://partner.uat.shopeemobile.com/api/v1/item/get"; }
        }

        public long Timestamp
        {
            get { return TimeStamp.GetTimestamp(); }
        }

        public void pareParam(IDictionary<string, object> paramters)
        {
            paramters.Add("item_id", this.Item_ID);
            paramters.Add("partner_id", this.Partner_ID);
            paramters.Add("shopid", this.ShopID);
            paramters.Add("timestamp", this.Timestamp);
        }
    }
}
