using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShopeeSDK.Response;

namespace ShopeeSDK.Request
{
    public abstract class RequestBase<T> : IRequest<T> where T : BaseResponse
    {
        public abstract string ApiName { get; }
        public abstract long Timestamp { get; }
        public abstract void pareParam(IDictionary<string, object> paramters);
    }
}
