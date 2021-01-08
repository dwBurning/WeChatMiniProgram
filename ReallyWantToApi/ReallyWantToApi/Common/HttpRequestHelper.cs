using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace ReallyWantToApi.Common
{
    public class HttpRequestHelper
    {
        public static string HttpGet(string url)
        {
            string result = string.Empty;
            try
            {
                HttpWebRequest wbRequest = (HttpWebRequest)WebRequest.Create(url);
                wbRequest.Method = "GET";
                HttpWebResponse wbResponse = (HttpWebResponse)wbRequest.GetResponse();
                using (Stream responseStream = wbResponse.GetResponseStream())
                {
                    using (StreamReader sReader = new StreamReader(responseStream))
                    {
                        result = sReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static string HttpPost(string url, string paramData, Dictionary<string, string> headerDic = null)
       {
           string result = string.Empty;
           try
           {
               HttpWebRequest wbRequest = (HttpWebRequest)WebRequest.Create(url);
               wbRequest.Method = "POST";
               wbRequest.ContentType = "application/x-www-form-urlencoded";
               wbRequest.ContentLength = Encoding.UTF8.GetByteCount(paramData);
               if (headerDic != null && headerDic.Count > 0)
               {
                   foreach (var item in headerDic)
                   {
                       wbRequest.Headers.Add(item.Key, item.Value);
                   }
               }
               using (Stream requestStream = wbRequest.GetRequestStream())
               {
                   using (StreamWriter swrite = new StreamWriter(requestStream))
                   {
                       swrite.Write(paramData);
                   }
               }
               HttpWebResponse wbResponse = (HttpWebResponse)wbRequest.GetResponse();
               using (Stream responseStream = wbResponse.GetResponseStream())
               {
                   using (StreamReader sread = new StreamReader(responseStream))
                   {
                       result = sread.ReadToEnd();
                   }
               }
           }
           catch (Exception ex)
           { }
         
           return result;
       }
    }
}