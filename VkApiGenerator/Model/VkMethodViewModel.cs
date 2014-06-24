using System;
using System.Text;
using VkApiGenerator.Utils;

namespace VkApiGenerator.Model
{
    public class VkMethodViewModel
    {
        public string ReturnType { get; set; }
        public string Name { get; set; }
        public string Params { get; set; }
        public string Check { get; set; }
        public string ParamsDefinition { get; set; }
        public string Invoke { get; set; }
        public string Return { get; set; }
        public string XmlDoc { get; set; }

        public VkMethodViewModel(VkMethodInfo method)
        {
            switch (method.ReturnType)
            {
                case Model.ReturnType.Bool:
                    ReturnType = "bool";
                    break;

                case Model.ReturnType.Collection:
                    ReturnType = "ReadOnlyCollection<>";
                    break;

                case Model.ReturnType.Void:
                    ReturnType = "void";
                    break;

                case Model.ReturnType.Long:
                    ReturnType = "long";
                    break;

                case Model.ReturnType.Unknown:
                    ReturnType = "Unknown";
                    break;

                case Model.ReturnType.String:
                    ReturnType = "string";
                    break;

                case Model.ReturnType.Double:
                    ReturnType = "double";
                    break;

                default:
                    throw new ArgumentException("Unknown return type: " + method.ReturnType);
            }

            Name = method.CanonicalName;
            Params = method.Params.ToString();
            Check = GetCheckBlock(method.Params);
            ParamsDefinition = GetParamsDefinitionnBlock(method.Params);
            Invoke = GetInvokeBlock(method.ReturnType, method.Name, method.Params.Count);
            Return = GetReturnBlock(method.ReturnType);
            XmlDoc = GetXmlDoc(method.Name, method.Description, method.ReturnText, method.Params);
        }

        public string GetReturnBlock(ReturnType returnType)
        {
            return string.Format("return response{0};",
                returnType == Model.ReturnType.Collection ? ".ToReadOnlyCollectionOf<>(x => x)" : string.Empty);
        }

        public string GetCheckBlock(VkMethodParamsCollection parameters)
        {
            var sb = new StringBuilder();

            foreach (var p in parameters)
            {
                if (p.Restrictions == VkParamRestrictions.PositiveDigit)
                    sb.AppendFormat("    " + Template.ThrowIfNumberIsNegative, p.CanonicalName).AppendLine();
            }

            return sb.ToString();
        }

        public string GetInvokeBlock(ReturnType returnType, string name, int parametersCount)
        {
            var sb = new StringBuilder();

            sb.Append(returnType == Model.ReturnType.Collection ? "VkResponseArray" : "VkResponse");
            sb.AppendFormat(" response = _vk.Call(\"{0}\", ", name);
            sb.Append(parametersCount > 0 ? "parameters);" : "VkParameters.Empty);");

            return sb.ToString();
        }

        public string GetParamsDefinitionnBlock(VkMethodParamsCollection parameters)
        {
            if (parameters == null || parameters.Count == 0) return string.Empty;

            var sb = new StringBuilder("    var parameters = new VkParameters\r\n        {\r\n");
            for (int i = 0; i < parameters.Count; i++)
            {
                var p = parameters[i];
                sb.AppendFormat("            {{\"{0}\", {1}}}", p.Name, p.CanonicalName);

                if (i != parameters.Count - 1)
                    sb.Append(",");

                sb.Append("\r\n");
            }
            sb.Append("        };");

            return sb.ToString();
        }

        public string GetXmlDoc(string name, string description, string returnText, VkMethodParamsCollection parameters)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException("description");

            if (string.IsNullOrEmpty(returnText))
                throw new ArgumentNullException("returnText");

            var sb = new StringBuilder();

            sb.AppendFormat(@"/// <summary>
/// {0}
/// </summary>", description).AppendLine();

            foreach (var p in parameters)
            {
                sb.AppendFormat("/// <param name=\"{0}\">{1}</param>", p.CanonicalName, p.Description).AppendLine();
            }

            sb.AppendFormat("/// <returns>{0}</returns>", returnText).AppendLine();

            sb.AppendFormat(@"/// <remarks>
/// Страница документации ВКонтакте <see href=""http://vk.com/dev/{0}""/>.
/// </remarks>", name);

            return sb.ToString();
        }
    }
}