namespace VkNet.Utils
{
    using System;

    /// <summary>
    /// Указывает параметры метода на сервере ВК
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class VkValueAttribute : Attribute
    {
        /// <summary>
        /// Название параметра
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Значение параметра
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Название параметра</param>
        /// <param name="value">Значение параметра</param>
        public VkValueAttribute(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}