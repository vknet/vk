using System.Linq;

namespace VkNet.Utils
{
    using System.Collections.Generic;
    using System.Collections;
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
        /// Взять VkResponse
        /// </summary>
        /// <value>
        /// The VkResponse
        /// </value>
        /// <param name="key">Ключ.</param>
        /// <returns>Текущий объект</returns>
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
        public int Count
		{
			get { return _array.Count; }
		}

		/// <summary>
        /// Возвращает перечислитель, выполняющий итерацию в коллекции.
        /// </summary>
        /// <returns>
        /// Интерфейс T:System
        /// </returns>
        public IEnumerator<VkResponse> GetEnumerator()
		{
			return _array.Select(i => new VkResponse(i)).GetEnumerator();
		}

		/// <summary>
        /// Возвращает перечислитель, который осуществляет перебор элементов коллекции.
        /// </summary>
        /// <returns>
        /// Объект T:System
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}