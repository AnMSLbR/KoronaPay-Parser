using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KoronaPayParserLib
{
    internal class GetRequest
    {
        HttpWebRequest _request;
        string _address;

        public string Response { get; set; }

        public GetRequest(string address)
        {
            _address = address;
        }
        public void Run()
        {
            _request = (HttpWebRequest)WebRequest.Create(_address);
            _request.Method = "GET";
            _request.Headers.Add("accept-language", "en");

            try
            {
                using (var _response = (HttpWebResponse)_request.GetResponse())
                {
                    var stream = _response.GetResponseStream();
                    if (stream != null)
                    {
                        using var reader = new StreamReader(stream);
                            Response = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                string text;
                using (WebResponse response = ex.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    using Stream data = response.GetResponseStream();
                    using var reader = new StreamReader(data);
                        text = reader.ReadToEnd();
                }
                var message = JObject.Parse(text);
                throw new WebException($"{message["message"]}");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
