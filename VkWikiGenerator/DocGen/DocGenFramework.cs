namespace VkWikiGenerator.DocGen
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Генератор документации.
    /// </summary>
    internal class DocGenFramework
    {
        /// <summary>
        /// Парсер документации.
        /// </summary>
        private VkDocParser _parser;

        /// <summary>
        /// Типы сборки.
        /// </summary>
        public IList<VkDocType> Types { get; private set; }

        /// <summary>
        /// Разбирает xml с документацией.
        /// </summary>
        /// <param name="xml">xml с документацией сборки.</param>
        public void Parse(string xml)
        {
            _parser = new VkDocParser();
            Types = _parser.Parse(xml);
        }

        /// <summary>
        /// Считывает файл по данному пути.
        /// </summary>
        /// <param name="path">
        /// Путь к файлу.
        /// </param>
        /// <returns>
        /// Содержимое файла.
        /// </returns>
        public static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        /// <summary>
        /// Генерирует Wiki-описание метода.
        /// </summary>
        /// <param name="method">Метод, для которого необходимо получить описание.</param>
        /// <returns>
        /// Wiki-описание метода.
        /// </returns>
        public static string GenerateWikiMethod(VkDocMethod method)
        {
            if (method == null) return string.Empty;

            var template = new StringBuilder(ReadFile(@"templates\method.txt"));

            if (string.IsNullOrEmpty(template.ToString())) 
                throw new IOException("Method template not found.");

            template.Replace(Placeholder.MethodName, method.ShortName);
            template.Replace(Placeholder.CategoryName, method.Type.ShortName.Replace("Category", string.Empty));
            template.Replace(Placeholder.MethodDesc, method.Summary);
            template.Replace(Placeholder.MethodResult, method.Returns);
            template.Replace(Placeholder.MethodRamarks, method.Remarks);
            template.Replace(Placeholder.MethodSignature, method.Signature);

            var parameters = new StringBuilder();
            if (method.Params.Count == 0)
            {
                parameters.Append("Данный метод не принимает параметров.");
            }
            else
            {
                parameters.Append("|| Параметр || Описание ||").AppendLine();
                foreach (var p in method.Params)
                    parameters.AppendFormat("| {0} | {1} |{2}", p.Name, p.Description, Environment.NewLine);
            }

            template.Replace(Placeholder.ParamsList, parameters.ToString());
            
            return template.ToString();
        }

    }
}