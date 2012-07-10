using System.IO;
using System.Net;
using VkToolkit.Exception;

namespace VkToolkit.Utils
{
    public class Browser : IBrowser
    {
        public string GetRawHtml(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response;

            try
            {
                response = request.GetResponse();
            }
            catch (WebException ex)
            {
                throw new VkApiException(ex.Message, ex);
            }

            Stream stream = response.GetResponseStream();

            if (stream == null)
                throw new VkApiException("Stream response is null.");

            var sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }
    }
}