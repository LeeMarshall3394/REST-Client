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
        //Make public variables
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

            //Create an Httpwebrequest
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            //Assign the correct method to the request.
            request.Method = httpMethod.ToString();

            //Run the request
            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                //If it returns an error
                if(response.StatusCode != HttpStatusCode.OK)
                {
                    //Throw an application exception displaying the error message.
                    throw new ApplicationException("Error Code" + response.StatusCode.ToString());
                }

                //Create new Stream named responseStream
                using (Stream responseStream = response.GetResponseStream())
                {
                    //If responseStream isn't empty
                    if(responseStream != null)
                    {
                        //Make new StreamReader using the values in responseStream
                        using(StreamReader reader = new StreamReader(responseStream))
                        {
                            //Make strResponseValue equal to the entirety of the StreamReader
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            //Return the string
            return strResponseValue;
        }
    }
}
