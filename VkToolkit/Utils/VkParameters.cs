namespace VkToolkit.Utils
{
    using System;
    using System.Collections.Generic;

    public class VkParameters : Dictionary<string, string>
    {
        public VkParameters()
        {
        }

        public VkParameters(IDictionary<string, string> parameters) : base(parameters)
        {
        }

        public static VkParameters Empty
        {
            get { return new VkParameters(); }
        }

        public void Add<T>(string name, T value) 
        {
            if (value == null)
                return;

            if (typeof(T).IsEnum)
            {
                Add(name, (int)(object)value);
                return;
            }

            var stringValue = value.ToString();
            if (!string.IsNullOrEmpty(stringValue))
                base.Add(name, stringValue);
        }

        public void Add<T>(string name, IEnumerable<T> collection)
        {
            var value = collection.JoinNonEmpty();
            Add(name, value);
        }

        public void Add<T>(string name, List<T> collection)
        {
            Add(name, (IEnumerable<T>)collection);
        }

        public void Add<T>(string name, T? nullableValue) where T : struct
        {
            if (!nullableValue.HasValue)
                return;

            Add(name, nullableValue.Value);
        }

        public void Add(string name, DateTime? nullableDateTime) 
        {
            if (!nullableDateTime.HasValue)
                return;

            var offset = DateTime.Now - nullableDateTime.Value;
            Add(name, (long)offset.TotalSeconds);
        }

        public void Add(string name, bool? nullableValue)
        {
            if (!nullableValue.HasValue || !nullableValue.Value)
                return;

            base.Add(name, "1");
        }

        public void Add(string name, bool value)
        {
            base.Add(name, value ? "1" : "0");
        }
    }
}