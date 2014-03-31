namespace VkWikiGenerator.DocGen
{
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Описание типа объекта.
    /// </summary>
    [DebuggerDisplay("Name = {FullName}, MethodsCount = {Methods.Count}, Props = {Properties.Count}")]
    internal class VkDocType
    {
        /// <summary>
        /// Полное имя типа.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Короткое имя типа.
        /// </summary>
        public string ShortName { get { return VkDocParser.GetShortName(FullName); } }

        /// <summary>
        /// Информация о типе.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Признак является ли тип перечислением.
        /// </summary>
        public bool IsEnum { get { return EnumItems.Count > 0; } }

        /// <summary>
        /// Методы типа.
        /// </summary>
        public List<VkDocMethod> Methods { get; set; }

        /// <summary>
        /// Свойства типа.
        /// </summary>
        public List<VkDocProperty> Properties { get; set; }

        /// <summary>
        /// Элементы перечисления типа.
        /// </summary>
        public List<VkDocEnumItem> EnumItems { get; set; } 
        
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VkDocType"/>.
        /// </summary>
        public VkDocType()
        {
            Methods = new List<VkDocMethod>();
            Properties = new List<VkDocProperty>();
            EnumItems = new List<VkDocEnumItem>();
        }

        /// <summary>
        /// Преобразует описание типа объекта в строку.
        /// </summary>
        /// <returns>Возвращает строку с описанием типа объекта.</returns>
        public override string ToString()
        {
            return FullName;
        }
    }
}