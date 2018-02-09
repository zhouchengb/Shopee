using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShopeeSDK.Response;

namespace ShopeeSDK.Request
{
    public interface IRequest<T> where T :BaseResponse
    {
        /// <summary>
        /// 获取Jd的API名称。
        /// </summary>
        /// <returns>API名称</returns>
        String ApiName
        {
            get;
        }
        long Timestamp
        {
            get;
        }
        void pareParam(IDictionary<String, Object> paramters);
    }
}
