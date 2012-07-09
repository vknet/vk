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
            WebResponse response = request.GetResponse();

            Stream stream = response.GetResponseStream();

            if (stream == null)
                throw new VkApiException("Stream response is null.");

            var sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }
    }
}