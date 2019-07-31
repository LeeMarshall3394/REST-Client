using System;
using System.IO;
using System.Net;
using System.Text;

namespace REST_Client
{
    public enum httpverb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class restClient
    {
        public string endPoint { get; set; }
        public httpverb httpMethod { get; set; }

        public restClient()
        {
            //Creating Variables
            endPoint = string.Empty;
            httpMethod = httpverb.GET;
        }

        public string makeRequest()
        {
            //Create return string
            string strResponseValue = string.Empty;


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = httpMethod.ToString();

            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if(response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Error Code" + response.StatusCode.ToString());
                }

                //Process response stream
                using (Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        using(StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }

            return strResponseValue;
        }
    }
}
