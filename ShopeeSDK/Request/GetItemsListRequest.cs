using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShopeeSDK.Response;

namespace ShopeeSDK.Request
{
    public class GetItemsListRequest : IRequest<GetItemsListResponse>
    {
       public int Pagination_Offset { get; set;}
       public int Pagination_Entries_Per_Page { get; set; }
       public int? Update_Time_From { get; set; }
       public int? Update_Time_To { get; set; }
       public int Partner_ID { get; set; }
       public int ShopID { get; set; }
       public long Timestamp
       {
           get { return TimeStamp.GetTimestamp(); }
       }


       public String ApiName
       {
           get { return "https://partner.uat.shopeemobile.com/api/v1/items/get"; }
       }

       public void pareParam(IDictionary<String, Object> paramters)
       {
           paramters.Add("pagination_offset", this.Pagination_Offset);
           paramters.Add("pagination_entries_per_page", this.Pagination_Entries_Per_Page);
           if (this.Update_Time_From != null)
           {
               paramters.Add("update_time_from", this.Update_Time_From);
           }
           if (this.Update_Time_To != null)
           {
               paramters.Add("update_time_to", this.Update_Time_To);
           }
          
           paramters.Add("partner_id", this.Partner_ID);
           paramters.Add("shopid", this.ShopID);
           paramters.Add("timestamp", this.Timestamp);
       }
       
    }
}
