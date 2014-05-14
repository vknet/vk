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

                default:
                    throw new NotImplementedException();
            }

            Name = method.CanonicalName;
            Params = method.Params.ToString();
            Check = GetCheckBlock(method.Params);
            ParamsDefinition = GetParamsDefinitionnBlock(method.Params);
            Invoke = GetInvokeBlock(method.ReturnType, method.Name, method.Params.Count);
            Return = GetReturnBlock(method.ReturnType);
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
                    sb.AppendFormat("    " + Template.ThrowIfNumberIsNegative, p.Name).AppendLine();
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
    }
}