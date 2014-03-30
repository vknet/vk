namespace VkNet.Documentation
{
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Класс для описания типа объекта
    /// </summary>
    [DebuggerDisplay("Name = {FullName}, MethodsCount = {Methods.Count}, Props = {Properties.Count}")]
    internal class VkDocType
    {
        public string FullName { get; set; }
        public string ShortName { get { return VkDocParser.GetShortName(FullName); } }
        public string Summary { get; set; }
        public bool IsEnum { get { return EnumItems.Count > 0; } }

        public List<VkDocMethod> Methods { get; set; }
        public List<VkDocProperty> Properties { get; set; }
        public List<VkDocEnumItem> EnumItems { get; set; } 
        
        public VkDocType()
        {
            Methods = new List<VkDocMethod>();
            Properties = new List<VkDocProperty>();
            EnumItems = new List<VkDocEnumItem>();
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}