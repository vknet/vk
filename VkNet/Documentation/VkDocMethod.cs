using System.Text;

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

                // заменяем типы CLR
                var raw = new StringBuilder(FullName.Substring(pos));
                raw.Replace("System.Nullable{System.Int32}", "int?")
                   .Replace("System.Int32@", "out int")
                   .Replace("System.Int64@", "out long")
                   .Replace("System.Nullable{System.Int64}", "long?")
                   .Replace("System.Int64", "long")
                   .Replace("System.Int32", "int")
                   .Replace("System.String", "string")
                   .Replace("System.Boolean", "bool")
                   .Replace("System.Collections.Generic.", string.Empty)
                   .Replace("{", "<")
                   .Replace("}", ">");
//                   .Replace(",", ", ");

                return InsertParameters(raw.ToString());
            } 
        }

        private string InsertParameters(string signature)
        {
            if (string.IsNullOrEmpty(signature)) return string.Empty;

            int start = signature.IndexOf('(');
            int end = signature.IndexOf(')');
            if (start == -1 || end == -1)
                return string.Format("{0}()", ShortName);

            string raw = signature.Substring(start + 1, end - start - 1).Trim();

            string[] parts = raw.Split(new[] {'\r', '\n', ','}, StringSplitOptions.RemoveEmptyEntries);

            var sb = new StringBuilder();
            for (int i = 0; i < parts.Length; i++)
            {
                string type = GetTypeWithoutNamespace(parts[i]);
                sb.AppendFormat(type.Contains("?") ? "{0} {1} = null" : "{0} {1}", type, Params[i].Name);

                if (i != parts.Length - 1)
                    sb.Append(", ");
            }

            return string.Format("{0}({1})", ShortName, sb);
        }

        private string GetTypeWithoutNamespace(string fullType)
        {
            fullType = fullType.Trim();
            if (string.IsNullOrEmpty(fullType))
                return string.Empty;

            int pos = fullType.LastIndexOf('.');
            if (pos == -1) return fullType;

            // possible error when string contains . (dot) in the end of line
            return fullType.Substring(pos + 1);
        }

        public VkDocMethod()
        {
            Params = new List<VkDocMethodParam>();
        }

        public override string ToString()
        {
            return ShortName;
        }
    }
}