using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopeeSDK
{
   public class TimeStamp
    {
       public static long GetTimestamp()
       {
           System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
           return (int)(DateTime.Now - startTime).TotalSeconds;
       }
    }
}
