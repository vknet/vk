namespace VkNet.Documentation
{
    using System.Diagnostics;

    [DebuggerDisplay("{Summary} ({ShortName})")]
    internal class VkDocEnumItem
    {
        public VkDocType Type { get; set; }
        public string FullName { get; set; }
        public string ShortName { get { return VkDocParser.GetShortName(FullName); } }
        public string Summary { get; set; }
    }
}