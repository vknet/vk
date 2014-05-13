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
    }
}