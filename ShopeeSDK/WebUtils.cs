using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using ShopeeSDK.Request;
using ShopeeSDK.Response;

namespace ShopeeSDK
{
   public class WebUtils
    {
       private static string secretKey = System.Configuration.ConfigurationManager.AppSettings["SecretKey"];
       private static bool isProxy =Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IsProxy"]);
       private static string proxyserver =System.Configuration.ConfigurationManager.AppSettings["ProxyServer"];
       private static string proxyUserName = System.Configuration.ConfigurationManager.AppSettings["ProxyUserName"];
       private static string proxyPassWord = System.Configuration.ConfigurationManager.AppSettings["ProxyPassWord"];

       private static int timeout =Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Timeout"]);
       public static T DoExecute<T>(IRequest<T> request) where T : BaseResponse
       {
           Dictionary<string,object> parm=new Dictionary<string, object>();
           request.pareParam(parm);
           string paramData = JsonConvert.SerializeObject(parm);
           string result= Post(request.ApiName, paramData);
           return JsonConvert.DeserializeObject<T>(result);
       }

        private static string Post(string postUrl, string paramData)
        {
            WebRequest request = WebRequest.Create(postUrl);
            byte[] postdatabyte = Encoding.UTF8.GetBytes(paramData);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = postdatabyte.Length;
            request.Timeout = timeout;
            string authorization = CreateAuthorization(postUrl + "|" + paramData, secretKey);
            request.Headers.Add(HttpRequestHeader.Authorization, authorization);

           SetWebProxy(request);
           Stream stream = null;
            HttpWebResponse response = null;
            try
            {
                stream = request.GetRequestStream();
                stream.Write(postdatabyte, 0, postdatabyte.Length);
                stream.Close();
                response = (HttpWebResponse)request.GetResponse();
                Encoding encoding = Encoding.GetEncoding(response.CharacterSet);
                return GetResponseAsString(response, encoding);
            }
            finally
            {
                // 释放资源
                if (stream != null) stream.Close();
                if (response != null) response.Close();
            }
            
        }


        private static string CreateAuthorization(string message, string secret)
        {
            var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(secret));
            hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(message));

            string result = "";
            foreach (byte hash in hmacsha256.Hash)
            {
                result += hash.ToString("x2");
            }

            return result;
        }
        private static String GetResponseAsString(HttpWebResponse rsp, Encoding encoding)
        {
            Stream stream = null;
            StreamReader reader = null;

            try
            {
                // 以字符流的方式读取HTTP响应
                stream = rsp.GetResponseStream();
                reader = new StreamReader(stream, encoding);
                return reader.ReadToEnd();
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (rsp != null) rsp.Close();
            }
        }
        public static void SetWebProxy(WebRequest request)
        {
            if (true == isProxy)
            {
                var proxyServer = proxyserver;
                var username = proxyUserName;
                var password = proxyPassWord;

                var proxy = new WebProxy(proxyServer)
                {
                    Credentials = new NetworkCredential(username, password)
                };

                request.Proxy = proxy;
            }
        }
    }
}
