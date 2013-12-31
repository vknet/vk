namespace VkToolkit.Model
{
    using VkToolkit.Utils;

    /// <summary>
    /// Информация о статусе пользователя.
    /// См. описание <see cref="http://vk.com/dev/status.get"/>.
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Текст статуса.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Информация об играющей в текущей момент у пользователя аудиокомпозиции.
        /// </summary>
        public Audio Audio { get; set; }

        #region Методы

        internal static Status FromJson(VkResponse response)
        {
            var status = new Status();

            status.Text = response["text"];
            status.Audio = response["audio"];

            return status;
        }

        #endregion
    }
}