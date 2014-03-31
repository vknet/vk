namespace VkWikiGenerator.DocGen
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;

    using JetBrains.Annotations;

    /// <summary>
    /// Класс для разбора xml с информацией о классах и методах библиотеки
    /// </summary>
    internal class VkDocParser
    {
        public List<VkDocType> Types { get; private set; }
        public List<VkDocMethod> Methods { get; private set; }
        public List<VkDocProperty> Properties { get; private set; }
        public List<VkDocEnumItem> EnumItems { get; private set; }

        public VkDocParser()
        {
            Types = new List<VkDocType>();
            Methods = new List<VkDocMethod>();
            Properties = new List<VkDocProperty>();
            EnumItems = new List<VkDocEnumItem>();
        }

        private void Clear()
        {
            Types.Clear();
            Methods.Clear();
            Properties.Clear();
            EnumItems.Clear();
        }
            
        [Pure]
        public IList<VkDocType> Parse(string content)
        {
            Clear();

            if (string.IsNullOrEmpty(content)) return Types;
          
            using (XmlReader xml = new XmlTextReader(new StringReader(content)))
            {
                while (xml.Read())
                {
                    if (xml.NodeType == XmlNodeType.Element && xml.Name == "member")
                    {
                        string name = xml.GetAttribute("name");
                        if (string.IsNullOrEmpty(name)) continue;

                        if (name.StartsWith("T:"))
                            Types.Add(GetVkDocType(xml));
                        
                        if (name.StartsWith("M:"))
                            Methods.Add(GetVkDocMethod(xml));
                        
                        if (name.StartsWith("P:"))
                            Properties.Add(GetVkDocProperty(xml));

                        if (name.StartsWith("F:"))
                            EnumItems.Add(GetVkDocEnumItem(xml));

                    }
                }
            }

            foreach (VkDocType type in Types)
            {
                VkDocType t = type;
                List<VkDocMethod> mtds = Methods.Where(m => m.FullName.StartsWith(t.FullName)).ToList();
                t.Methods = mtds;
                mtds.ForEach(x => x.Type = t);

                List<VkDocProperty> prpts = Properties.Where(m => m.FullName.StartsWith(t.FullName)).ToList();
                t.Properties = prpts;
                prpts.ForEach(x => x.Type = t);

                List<VkDocEnumItem> items = EnumItems.Where(m => m.FullName.StartsWith(t.FullName)).ToList();
                t.EnumItems = items;
                items.ForEach(x => x.Type = t);
            }

            return Types;
        }

        [Pure]
        private VkDocEnumItem GetVkDocEnumItem(XmlReader xml)
        {
            var item = new VkDocEnumItem { FullName = GetMemberName(xml, "F:") };

            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.EndElement && xml.Name == "member")
                    break;

                if (xml.NodeType == XmlNodeType.Element && xml.Name == "summary")
                {
                    item.Summary = xml.ReadInnerXml().Trim();
                }
            }

            return item;
        }

        [Pure]
        private VkDocProperty GetVkDocProperty(XmlReader xml)
        {
            var prop = new VkDocProperty{FullName = GetMemberName(xml, "P:")};

            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.EndElement && xml.Name == "member")
                    break;

                if (xml.NodeType == XmlNodeType.Element && xml.Name == "summary")
                {
                    prop.Summary = xml.ReadInnerXml().Trim();
                }
            }

            return prop;
        }

        [Pure]
        private VkDocMethod GetVkDocMethod(XmlReader xml)
        {
            var method = new VkDocMethod {FullName = GetMemberName(xml, "M:")};

            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.EndElement && xml.Name == "member")
                    break;

                if (xml.NodeType == XmlNodeType.Element && xml.Name == "summary")
                {
                    //method.Summary = xml.ReadElementContentAsString().Trim();
                    method.Summary = xml.ReadInnerXml().Trim();
                    continue;
                }

                if (xml.NodeType == XmlNodeType.Element && xml.Name == "remarks")
                {
                    method.Remarks = xml.ReadInnerXml().Trim();
                    continue;
                }

                if (xml.NodeType == XmlNodeType.Element && xml.Name == "returns")
                {
                    method.Returns = xml.ReadInnerXml().Trim();
                    continue;
                }

                if (xml.NodeType == XmlNodeType.Element && xml.Name == "param")
                {
                    method.Params.Add(GetParam(xml));
                    continue;
                }

                if (xml.NodeType == XmlNodeType.Element && xml.Name == "example")
                {
                    method.Example = xml.ReadInnerXml().Trim();
                }
            }

            return method;
        }

        [Pure]
        private VkDocType GetVkDocType(XmlReader xml)
        {
            var type = new VkDocType {FullName = GetMemberName(xml, "T:")};

            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.EndElement && xml.Name == "member")
                    break;

                if (xml.NodeType == XmlNodeType.Element && xml.Name == "summary")
                {   
                    //type.Summary = xml.ReadElementContentAsString().Trim();
                    type.Summary = xml.ReadInnerXml().Trim();
                }
            }

            return type;
        }

        [Pure]
        private VkDocMethodParam GetParam(XmlReader xml)
        {
            var param = new VkDocMethodParam
                {
                    Name = GetMemberName(xml),
                    Description = xml.ReadInnerXml().Trim()
                };

            return param;
        }
        [Pure]
        private string GetMemberName(XmlReader xml)
        {
            return xml.GetAttribute("name");
        }

        [Pure]
        private string GetMemberName(XmlReader xml, string prefix)
        {
            string name = xml.GetAttribute("name");
            return !string.IsNullOrEmpty(name) ? name.Replace(prefix, "") : string.Empty;
        }

        [Pure]
        internal static string GetShortName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName)) return string.Empty;

            int bracketPos = fullName.IndexOf('(');
            if (bracketPos != -1)
            {
                fullName = fullName.Substring(0, bracketPos);
            }

            int pos = fullName.LastIndexOf('.');
            if (pos == -1) return fullName;

            return fullName.Substring(pos + 1);
        }
    }
}