namespace VkNet.Utils
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Массив
    /// </summary>
    public sealed class VkResponseArray : IEnumerable<VkResponse>
    {
        /// <summary>
        /// Массив
        /// </summary>
        private readonly JArray _array;

        /// <summary>
        /// Инициализация нового массива.
        /// </summary>
        /// <param name="array">Массив.</param>
        public VkResponseArray(JArray array)
        {
            _array = array;
        }

        /// <summary>
        /// Взять <see cref="VkResponse"/> по специфическому ключу.
        /// </summary>
        /// <value>
        /// The <see cref="VkResponse"/>.
        /// </value>
        /// <param name="key">Ключ.</param>
        /// <returns></returns>
        public VkResponse this[object key]
        {
            get
            {
                var token = _array[key];
                return new VkResponse(token);
            }
        }

        /// <summary>
        /// Количество.
        /// </summary>
        /// <value>
        /// Количество.
        /// </value>
        public int Count => _array.Count;

        /// <summary>
        /// Возвращает перечислитель, выполняющий итерацию в коллекции.
        /// </summary>
        /// <returns>
        /// Интерфейс <see cref="T:System.Collections.Generic.IEnumerator`1" />, который может использоваться для перебора элементов коллекции.
        /// </returns>
        public IEnumerator<VkResponse> GetEnumerator()
        {
            return _array.Select(i => new VkResponse(i)).GetEnumerator();
        }

        /// <summary>
        /// Возвращает перечислитель, который осуществляет перебор элементов коллекции.
        /// </summary>
        /// <returns>
        /// Объект <see cref="T:System.Collections.IEnumerator" />, который может использоваться для перебора элементов коллекции.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}