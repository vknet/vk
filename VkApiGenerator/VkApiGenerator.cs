using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using RazorEngine;
using VkApiGenerator.Model;
using VkApiGenerator.Utils;

namespace VkApiGenerator
{
    public class VkApiGenerator
    {
        public string GenerateMethod(VkMethodInfo method)
        {   
            var model = new VkMethodViewModel(method);
            return Razor.Parse(Template.Method, model);
        }

        public string GetThrowIfNumberIsNegative(string paramName)
        {
            if (string.IsNullOrEmpty(paramName)) return string.Empty;

            return string.Format(Template.ThrowIfNumberIsNegative, paramName);
        }

        public string GenerateUnitTest(string categoryName)
        {
            // 1. read assembly
            // 2. find methods in particular category
            // 3. find methods with not input parameters (it's the most simple case)
            // 4. invoke a method
            // 5. construct unit-test
            // 6. return it

            Assembly dll = Assembly.LoadFrom("VkNet.dll");

            // todo refactor it later
            List<Type> classes = dll.GetTypes().Where(t => t.Name.Contains("Category") && t.Name.Contains(categoryName)).ToList();

            Type category = classes.FirstOrDefault();

            MethodInfo[] methods = category.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public);

            foreach (var methodInfo in methods)
            {
                if (methodInfo.GetParameters().Length == 0)
                {
                    Debug.WriteLine(" -- " + methodInfo.Name);

                }
            }

            throw new NotImplementedException();
        }
    }
}