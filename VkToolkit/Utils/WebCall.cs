namespace VkToolkit.Utils
{
    using System.Net;
    using System.Text;

    using VkToolkit.Exception;

    internal sealed class WebCall
    {
        private HttpWebRequest Request { get; set; }

        private WebCallResult Result { get; set; }

        private WebCall(string url, Cookies cookies)
        {
            Request = (HttpWebRequest)WebRequest.Create(url);
            Request.Accept = "text/html";
            Request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
            Request.CookieContainer = cookies.Container;

            Result = new WebCallResult(url, cookies);
        }

        public static WebCallResult MakeCall(string url)
        {
            var call = new WebCall(url, new Cookies());

            return call.MakeRequest();
        }

        public static WebCallResult Post(WebForm form)
        {
            var call = new WebCall(form.ActionUrl, form.Cookies);

            var request = call.Request;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            var formRequest = form.GetRequest();
            request.ContentLength = formRequest.Length;
            request.GetRequestStream().Write(formRequest, 0, formRequest.Length);
            request.AllowAutoRedirect = false;
            request.Referer = form.OriginalUrl;

            return call.MakeRequest();
        }

        private WebCallResult RedirectTo(string url)
        {
            var call = new WebCall(url, Result.Cookies);

            var request = call.Request;
            request.Method = "GET";
            request.ContentType = "text/html";
            request.Referer = Request.Referer;

            return call.MakeRequest();
        }

        private WebCallResult MakeRequest()
        {
            using (var response = GetResponse())
            using (var stream = response.GetResponseStream())
            {
                if (stream == null)
                    throw new VkApiException("Response is null.");

                var encoding = response.CharacterSet != null ? Encoding.GetEncoding(response.CharacterSet) : Encoding.UTF8;
                Result.SaveResponse(response.ResponseUri, stream, encoding);

                Result.SaveCookies(response.Cookies);

                if (response.StatusCode == HttpStatusCode.Redirect)
                    return RedirectTo(response.Headers["Location"]);

                return Result;
            }
        }

        private HttpWebResponse GetResponse()
        {
            try
            {
                return (HttpWebResponse)Request.GetResponse();
            }
            catch (WebException ex)
            {
                throw new VkApiException(ex.Message, ex);
            }
        }
    }
}