namespace VkNet.Utils
{
    using System;

    /// <summary>
    /// Задает название метода на сервере ВК (используется генератором юнит-тестов)
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ApiMethodName : Attribute
    {
        /// <summary>
        /// Название метода
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Порядок вызова метода
        /// </summary>
        /// <remarks>
        /// Методы с большим числом вызываются раньше
        /// </remarks>
        public int Order { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Название метода</param>
        public ApiMethodName(string name)
        {
            Name = name;
        }
    }
}