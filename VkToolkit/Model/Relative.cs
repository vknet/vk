namespace VkToolkit.Model
{
    using VkToolkit.Utils;

    public class Relative
    {
        /// <summary>
        /// Идентификатор родственника.
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Тип родственника.
        /// </summary>
        public string Type { get; set; }

        internal static Relative FromJson(VkResponse relative)
        {
            var result = new Relative();

            result.Id = relative["uid"];
            result.Type = relative["type"];

            return result;
        }
    }
}