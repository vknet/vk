namespace VkWikiGenerator.DocGen
{
    using System.Diagnostics;

    /// <summary>
    /// Описание элемента перечисления типа.
    /// </summary>
    [DebuggerDisplay("{Summary} ({ShortName})")]
    internal class VkDocEnumItem
    {
        /// <summary>
        /// Описание типа, которому принадлежит элемент перечисления.
        /// </summary>
        public VkDocType Type { get; set; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Короткое имя.
        /// </summary>
        public string ShortName { get { return VkDocParser.GetShortName(FullName); } }

        /// <summary>
        /// Описание элемента перечисления типа.
        /// </summary>
        public string Summary { get; set; }
    }
}