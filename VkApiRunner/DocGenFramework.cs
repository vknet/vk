using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VkNet.Documentation;

namespace VkApiRunner
{
    internal class DocGenFramework
    {
        public IList<VkDocType> Types { get; private set; }
        public VkDocParser Parser { get; private set; }

        public void Parse(string xml)
        {
            Parser = new VkDocParser();
            Types = Parser.Parse(xml);
        }

        public static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public static string GenerateVkMethod(VkDocMethod method)
        {
            if (method == null) return string.Empty;

            var tmpl = new StringBuilder(ReadFile(@"templates\method.txt"));

            if (string.IsNullOrEmpty(tmpl.ToString())) 
                throw new IOException("Method template not found.");

            tmpl.Replace(Placeholder.MethodName, method.ShortName);
            tmpl.Replace(Placeholder.CategoryName, method.Type.ShortName.Replace("Category", string.Empty));
            tmpl.Replace(Placeholder.MethodDesc, method.Summary);
            tmpl.Replace(Placeholder.MethodResult, method.Returns);
            tmpl.Replace(Placeholder.MethodRamarks, method.Remarks);
            tmpl.Replace(Placeholder.MethodSignature, method.Signature);

            var parameters = new StringBuilder();
            if (method.Params.Count == 0)
            {
                parameters.Append("Данный метод не принимает параметров.");
            }
            else
            {
                parameters.Append("|| Параметр || Описание ||").AppendLine();
                foreach (var p in method.Params)
                {
                    parameters.AppendFormat("| {0} | {1} |{2}", p.Name, p.Description, Environment.NewLine);
                }
            }
            tmpl.Replace(Placeholder.ParamsList, parameters.ToString());
            
            return tmpl.ToString();
        }

    }
}