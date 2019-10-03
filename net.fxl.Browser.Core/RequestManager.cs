using System.IO;
using System.Net;

namespace Browser.Core
{
    public class RequestManager
    {
        //GET, POST, HEAD, OPTIONS, TRACE, PATCH, PUT, DELETE
        public static string Get(string url)
        {
            var request = WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            var response = request.GetResponse();

            if (response.GetResponseStream() == null) return null;

            string result;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }

            response.Close();
            return result;
        }
    }
}