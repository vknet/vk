using System.IO;
using System.Threading.Tasks;
using PCLStorage;

namespace VkNet.UWP.Utils
{
    /// <summary>
    /// Работа с файлами
    /// </summary>
    internal static class File
    {
        /// <summary>
        /// Создать файл
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="data"></param>
        public static async void Create(string filePath, byte[] data)
        {
            var folder = FileSystem.Current.LocalStorage;
            var file = await folder.CreateFileAsync(filePath, CreationCollisionOption.ReplaceExisting);
            using (var stream = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                stream.Write(data, 0, data.Length);
            }
        }

        /// <summary>
        /// Прочитать из файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns></returns>
        public static async Task<byte[]> Read(string filePath)
        {
            var file = await FileSystem.Current.GetFileFromPathAsync(filePath);
            using (var stream = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
    }
}