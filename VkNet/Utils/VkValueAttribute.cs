using System;

namespace VkNet.Utils
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class VkValueAttribute : Attribute
    {
        public string Name { get; private set; }
        public object Value { get; private set; }

        public VkValueAttribute(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}