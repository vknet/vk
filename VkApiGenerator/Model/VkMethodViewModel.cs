using System;

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
            throw new NotImplementedException();
        }
    }
}