using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using ShopeeSDK;
using ShopeeSDK.Request;

namespace Shopee
{
    class Program
    {
        private static int partner_id = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PartnerId"]);
        private static int shopid = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ShopID"]);
        static void Main(string[] args)
        {
            //获取商店信息
            //ShopInfoRequest request = new ShopInfoRequest
            //{
            //    Partner_id = partner_id,
            //    Shopid = shopid
            //};
            


            GetItemsListRequest request = new GetItemsListRequest
            {
                Pagination_Offset = 0,
                Pagination_Entries_Per_Page = 100,
                Partner_ID= partner_id,
                ShopID = shopid

            };
            var response = WebUtils.DoExecute(request);
            if (response!=null&&!string.IsNullOrEmpty(response.error))
            {
                
            }
        }
        private static long GetTimestamp(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
    }
}
