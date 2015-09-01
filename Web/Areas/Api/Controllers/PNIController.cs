using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace Web.Areas.Api.Controllers
{
    public class PNIController : ApiController
    {
        // GET: api/PNI
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PNI/5
        public HttpResponseMessage Get(string data, string domainName)
        {
            string result = string.Empty;
            bool isException = false;
            if (!string.IsNullOrEmpty(data))
            {
                try
                {
                    byte[] decodedData = Convert.FromBase64String(data);
                    result = Encoding.UTF8.GetString(decodedData);

                    result = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><body><form action='http://" + domainName + "/api/pni/SaveItem' method='post' enctype='application/json' name='pnipost'><div><textarea type='text' rows='50' cols='120' name='pniData'>" + result + "</textarea></div><div><input type='submit' value='submit' name='submit'/><input type='hidden' name='domainname' value='l3.quill.com'/></div></form></body></html>";
                }
                catch (Exception ex)
                {
                    isException = true;
                    result = ex.ToString();

                }
            }

            //Post to Quill API -- TO DO

            //Redirect to Quill -- TO DO

            HttpResponseMessage response = Request.CreateResponse(isException ? HttpStatusCode.BadRequest : HttpStatusCode.OK, isException ? "Failure" : "Success");
            response.Content = new StringContent(result, Encoding.UTF8);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };
            return response;
        }

        // POST: api/PNI
        [HttpPost]
        public HttpResponseMessage Post(JObject pniData)
        {
            var response = new HttpResponseMessage();
            string result = string.Empty;
            result = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><body><a href='http://" + pniData.SelectToken("domainname").Value<string>() + "/pnigateway/transfertoquill'>Click to transfer back to local quill site</a></body></html>";
            response.Content = new StringContent(result);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return response;
        }

        // PUT: api/PNI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PNI/5
        public void Delete(int id)
        {
        }
    }
}
