using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using JetBrains.Annotations;

namespace VkNet.UWP.Utils
{
    /// <summary>
    /// Подмена WebClient
    /// </summary>
    public class WebClient : IDisposable
    {
        /// <summary>
        /// HTTP клиент
        /// </summary>
        private readonly HttpClient client;

        /// <summary>
        /// Инициализация класса
        /// </summary>
        public WebClient()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// Выгружает указанный локальный файл ресурс с указанным URI.
        /// </summary>
        /// <param name="address">URI ресурса, на этот файл. Например ftp://localhost/samplefile.txt. </param>
        /// <param name="fileName">Файл для отправки на ресурс. Например «samplefile.txt».</param>
        /// <returns></returns>
        public byte[] UploadFile([NotNull] string address, [NotNull] string fileName)
        {
            var content = new MultipartFormDataContent();

            using (var stream = new MemoryStream(File.Read(fileName).Result))
            {
                var streamContent = new StreamContent(stream);

                streamContent.Headers.ContentDisposition = ContentDispositionHeaderValue.Parse("form-data");

                streamContent.Headers.ContentDisposition.Parameters.Add(new NameValueHeaderValue("name", "contentFile"));

                streamContent.Headers.ContentDisposition.Parameters.Add(new NameValueHeaderValue("filename", "\"" + fileName + "\""));

                content.Add(streamContent);
            }

            var response = client.PostAsync(new Uri(address), content).Result;
            return response.Content.ReadAsByteArrayAsync().Result;
        }
        /// <summary>
        /// Загружает ресурс с указанным URI в локальный файл.
        /// </summary>
        /// <param name="address">URI, с которого будут загружены данные.</param>
        /// <param name="fileName">Имя локального файла, который будет получать данные.</param>
        public void DownloadFile([NotNull] string address, [NotNull] string fileName)
        {
            using (var response = client.GetAsync(address).Result)
            {
                response.EnsureSuccessStatusCode();

                File.Create(fileName, response.Content.ReadAsByteArrayAsync().Result);
            }
        }

        #region Implementation of IDisposable
        /// <summary>
        /// Освобождение ресурсов.
        /// </summary>
        public void Dispose()
        {
            client.Dispose();
        }

        #endregion
    }
}