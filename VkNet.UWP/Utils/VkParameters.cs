using System.Globalization;
using System.Reflection;

namespace VkNet.Utils
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Параметры запроса к ВКонтакте.
    /// </summary>
    //[DataContract]
    public partial class VkParameters : Dictionary<string, string>
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VkParameters"/>.
        /// </summary>
        public VkParameters()
        {
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VkParameters"/> на основе словаря.
        /// </summary>
        /// <param name="parameters">
        /// Параметры запроса.
        /// </param>
        public VkParameters(IDictionary<string, string> parameters) : base(parameters)
        {
        }

        /// <summary>
        /// Параметры для запроса без параметров.
        /// </summary>
        public static VkParameters Empty => new VkParameters();

        /// <summary>
        /// Добавляет параметр запроса.
        /// </summary>
        /// <typeparam name="T">Тип значения параметра запроса.</typeparam>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="value">Значение параметра запроса.</param>
        public void Add<T>(string name, T value)
        {
            Remove(name);

            if (value == null)
            {
                return;
            }

            if (typeof(T).GetTypeInfo().IsEnum)
            {
                Add(name, (int)(object)value);
                return;
            }

            var stringValue = value.ToString();
            if (!string.IsNullOrWhiteSpace(stringValue))
            {
                base.Add(name, stringValue);
            }
        }

        /// <summary>
        /// Добавляет параметр запроса, представляющий собой последовательность элементов заданного типа.
        /// Последовательность добавляется в виде строкового значения, содержащего ее элементы, разделенные запятой.
        /// </summary>
        /// <typeparam name="T">Имя типа элементов последовательности.</typeparam>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="collection">Последовательность, представляющая значение параметра запроса.</param>
        public void Add<T>(string name, IEnumerable<T> collection)
        {
            var value = collection.JoinNonEmpty();
            Add(name, value);
        }

        /// <summary>
        /// Добавляет именованный параметр запроса, представляющий собой коллекцию элементов заданного типа.
        /// Коллекция добавляетсяв виде строкового значения, содержащего ее элементы, разделенные запятой.
        /// </summary>
        /// <typeparam name="T">Имя типа элементов коллекции.</typeparam>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="collection">Коллекция, представляющая значение параметра запроса.</param>
        public void Add<T>(string name, List<T> collection)
        {
            Add(name, (IEnumerable<T>)collection);
        }

        /// <summary>
        /// Добавляет параметр запроса.
        /// Если передан null, то добавление параметра не производится.
        /// </summary>
        /// <typeparam name="T">Тип значения параметра запроса.</typeparam>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="nullableValue">Значение параметра запроса.</param>
        public void Add<T>(string name, T? nullableValue) where T : struct
        {
            Remove(name);

            if (nullableValue == null)
            {
                return;
            }

            Add(name, nullableValue.Value);
        }

        /// <summary>
        /// Добавляет параметр-дату.
        /// Если передан null, то добавление не производится.
        /// </summary>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="nullableDateTime">Значение параметра.</param>
        public void Add(string name, DateTime? nullableDateTime)
        {
            Remove(name);

            if (nullableDateTime == null)
            {
                return;
            }

            var totalSeconds = (nullableDateTime.Value.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            var offset = Convert.ToInt64(totalSeconds);

            Add(name, offset);
        }

        /// <summary>
        /// Добавляет логический параметр.
        /// Если передан null или значение параметра false, то добавление не производится.
        /// </summary>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="nullableValue">Значение параметра.</param>
        public void Add(string name, bool? nullableValue)
        {
            Remove(name);

            if (nullableValue == null || !nullableValue.Value)
            {
                return;
            }

            base.Add(name, "1");
        }

        /// <summary>
        /// Добавляет логический параметр.
        /// Если передан null, то добавление не производится.
        /// </summary>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="value">Значение параметра.</param>
        public void Add(string name, bool value)
        {
            Remove(name);

            base.Add(name, value ? "1" : "0");
        }

        /// <summary>
        /// Добавляет параметр десятичное число.
        /// Если передан null, то добавление не производится.
        /// </summary>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="value">Значение параметра.</param>
        public void Add(string name, decimal value)
        {
            Remove(name);

            base.Add(name, value.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Добавляет параметр десятичное число.
        /// Если передан null, то добавление не производится.
        /// </summary>
        /// <param name="name">Имя параметра запроса.</param>
        /// <param name="value">Значение параметра.</param>
        public void Add(string name, decimal? value)
        {
            Remove(name);

            if (value == null)
            {
                return;
            }

            base.Add(name, value.Value.ToString(CultureInfo.InvariantCulture));
        }
    }
}