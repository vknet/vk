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
            

            throw new NotImplementedException();
        }

        public string GetCheckBlock(VkMethodParamsCollection params)
        {
            throw new NotImplementedException();
        }
    }
}