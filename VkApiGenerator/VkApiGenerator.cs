using System;
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

        public string GenerateUnitTest(string category)
        {
            // 1. read assembly
            // 2. find methods in particular category
            // 3. find methods with not input parameters (it's the most simple case)
            // 4. invoke a method
            // 5. construct unit-test
            // 6. return it

            throw new NotImplementedException();
        }
    }
}