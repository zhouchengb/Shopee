using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopeeSDK.Response
{
   public class GetItemsListResponse:BaseResponse
    {
       public List<Item> items { get; set; }
       public string more { get; set; }
    }

    public class Item
    {
        public int item_id { get; set;}
        public int shopid { get; set; }
        public int update_time { get; set; }
        public string status { get; set; }
    }
}
