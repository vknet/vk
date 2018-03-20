namespace VkNet.Utils
{
    /// <summary>
    /// Работа с файлами
    /// </summary>
    public static class File
    {
        /// <summary>
        /// Создать файл
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <param name="data">Массив байт</param>
        public static void Create(string filePath, byte[] data)
        {
            throw new System.Exception("Не реализовано для UWP"); // todo Не реализовано для UWP
        }

        /// <summary>
        /// Прочитать из файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Массив байт</returns>
        public static byte[] Read(string filePath)
        {
            throw new System.Exception("Не реализовано для UWP"); // todo Не реализовано для UWP
        }
    }
}