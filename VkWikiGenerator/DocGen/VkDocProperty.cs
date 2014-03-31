namespace VkWikiGenerator.DocGen
{
    using System.Diagnostics;

    /// <summary>
    /// Описание свойства объекта.
    /// </summary>
    [DebuggerDisplay("Name = {ShortName} - {Summary}")]
    internal class VkDocProperty
    {
        /// <summary>
        /// Описание типа, которому принадлежит свойство.
        /// </summary>
        public VkDocType Type { get; set; }

        /// <summary>
        /// Полное имя свойства.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Короткое имя свойства.
        /// </summary>
        public string ShortName { get { return VkDocParser.GetShortName(FullName); } }

        /// <summary>
        /// Описание свойства.
        /// </summary>
        public string Summary { get; set; }
    }
}