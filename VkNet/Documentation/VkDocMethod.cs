namespace VkNet.Documentation
{
    using System;
    using System.Collections.Generic;

    internal class VkDocMethod
    {
        public VkDocType Type { get; set; }
        public string ShortName { get { return VkDocParser.GetShortName(FullName); } }
        public string FullName { get; set; }
        public IList<VkDocMethodParam> Params { get; private set; }

        public string Summary { get; set; }
        public string Returns { get; set; }
        public string Remarks { get; set; }
        public string Example { get; set; }

        public string Signature 
        { 
            get
            {
                if (string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(ShortName))
                    return string.Empty;

                int pos = FullName.IndexOf(ShortName, StringComparison.InvariantCulture);
                if (pos == -1) return string.Empty;

                return FullName.Substring(pos);

            } 
        }

        public VkDocMethod()
        {
            Params = new List<VkDocMethodParam>();
        }
    }
}