using System;
using System.Collections.Generic;
using System.Globalization;

namespace VkNet.Utils
{
	/// <inheritdoc />
	/// <summary>
	/// Параметры запроса к ВКонтакте.
	/// </summary>
	public partial class VkParameters : Dictionary<string, string>
	{
		/// <inheritdoc />
		/// <summary>
		/// Инициализирует новый экземпляр класса VkParameters
		/// </summary>
		public VkParameters()
		{
		}

		/// <inheritdoc />
		/// <summary>
		/// Инициализирует новый экземпляр класса VkParameters
		/// </summary>
		/// <param name="parameters">
		/// Параметры запроса.
		/// </param>
		public VkParameters(IDictionary<string, string> parameters) : base(dictionary: parameters)
		{
		}

		/// <summary>
		/// Параметры для запроса без параметров.
		/// </summary>
		public static VkParameters Empty => new VkParameters();

		/// <summary>
		/// Добавляет параметр запроса.
		/// </summary>
		/// <typeparam name="T"> Тип значения параметра запроса. </typeparam>
		/// <param name="name"> Имя параметра запроса. </param>
		/// <param name="value"> Значение параметра запроса. </param>
		public void Add<T>(string name, T value)
		{
			Remove(key: name);

			if (value == null
			) //TODO: V3111 http://www.viva64.com/en/w/V3111 Checking value of 'value' for null will always return false when generic type is instantiated with a value type.
			{
				return;
			}

			if (typeof(T).IsEnum)
			{
				Add(name: name, value: (int) (object) value);

				return;
			}

			var stringValue = value.ToString();

			if (!string.IsNullOrWhiteSpace(value: stringValue))
			{
				base.Add(key: name, value: stringValue);
			}
		}

		/// <summary>
		/// Добавляет параметр запроса, представляющий собой последовательность элементов
		/// заданного типа.
		/// Последовательность добавляется в виде строкового значения, содержащего ее
		/// элементы, разделенные запятой.
		/// </summary>
		/// <typeparam name="T"> Имя типа элементов последовательности. </typeparam>
		/// <param name="name"> Имя параметра запроса. </param>
		/// <param name="collection">
		/// Последовательность, представляющая значение параметра
		/// запроса.
		/// </param>
		public void Add<T>(string name, IEnumerable<T> collection)
		{
			var value = collection.JoinNonEmpty();
			Add(name: name, value: value);
		}

		/// <summary>
		/// Добавляет именованный параметр запроса, представляющий собой коллекцию
		/// элементов заданного типа.
		/// Коллекция добавляетсяв виде строкового значения, содержащего ее элементы,
		/// разделенные запятой.
		/// </summary>
		/// <typeparam name="T"> Имя типа элементов коллекции. </typeparam>
		/// <param name="name"> Имя параметра запроса. </param>
		/// <param name="collection"> Коллекция, представляющая значение параметра запроса. </param>
		public void Add<T>(string name, List<T> collection)
		{
			Add(name: name, collection: (IEnumerable<T>) collection);
		}

		/// <summary>
		/// Добавляет параметр запроса.
		/// Если передан null, то добавление параметра не производится.
		/// </summary>
		/// <typeparam name="T"> Тип значения параметра запроса. </typeparam>
		/// <param name="name"> Имя параметра запроса. </param>
		/// <param name="nullableValue"> Значение параметра запроса. </param>
		public void Add<T>(string name, T? nullableValue)
				where T : struct
		{
			Remove(key: name);

			if (nullableValue == null)
			{
				return;
			}

			Add(name: name, value: nullableValue.Value);
		}

		/// <summary>
		/// Добавляет параметр-дату.
		/// Если передан null, то добавление не производится.
		/// </summary>
		/// <param name="name"> Имя параметра запроса. </param>
		/// <param name="nullableDateTime"> Значение параметра. </param>
		public void Add(string name, DateTime? nullableDateTime)
		{
			Remove(key: name);

			if (nullableDateTime == null)
			{
				return;
			}

			var totalSeconds =
					(nullableDateTime.Value.ToUniversalTime()
					- new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, kind: DateTimeKind.Utc)).TotalSeconds;

			var offset = Convert.ToInt64(value: totalSeconds);

			Add(name: name, value: offset);
		}

		/// <summary>
		/// Добавляет логический параметр.
		/// Если передан null или значение параметра false, то добавление не производится.
		/// </summary>
		/// <param name="name"> Имя параметра запроса. </param>
		/// <param name="nullableValue"> Значение параметра. </param>
		public void Add(string name, bool? nullableValue)
		{
			Remove(key: name);

			if (!nullableValue.HasValue)
			{
				return;
			}

			base.Add(key: name, value: nullableValue.Value ? "1" : "0");
		}

		/// <summary>
		/// Добавляет логический параметр.
		/// Если передан null, то добавление не производится.
		/// </summary>
		/// <param name="name"> Имя параметра запроса. </param>
		/// <param name="value"> Значение параметра. </param>
		public void Add(string name, bool value)
		{
			Remove(key: name);

			base.Add(key: name, value: value ? "1" : "0");
		}

		/// <summary>
		/// Добавляет параметр десятичное число.
		/// Если передан null, то добавление не производится.
		/// </summary>
		/// <param name="name"> Имя параметра запроса. </param>
		/// <param name="value"> Значение параметра. </param>
		public void Add(string name, decimal value)
		{
			Remove(key: name);

			base.Add(key: name, value: value.ToString(provider: CultureInfo.InvariantCulture));
		}

		/// <summary>
		/// Добавляет параметр десятичное число.
		/// Если передан null, то добавление не производится.
		/// </summary>
		/// <param name="name"> Имя параметра запроса. </param>
		/// <param name="value"> Значение параметра. </param>
		public void Add(string name, decimal? value)
		{
			Remove(key: name);

			if (value == null)
			{
				return;
			}

			base.Add(key: name, value: value.Value.ToString(provider: CultureInfo.InvariantCulture));
		}

		/// <summary>
		/// Добавляет параметр десятичное число.
		/// Если передан null, то добавление не производится.
		/// </summary>
		/// <param name="name"> Имя параметра запроса. </param>
		/// <param name="value"> Значение параметра. </param>
		public void Add(string name, double value)
		{
			Remove(key: name);

			base.Add(key: name, value: value.ToString(provider: CultureInfo.InvariantCulture));
		}

		/// <summary>
		/// Добавляет параметр десятичное число.
		/// Если передан null, то добавление не производится.
		/// </summary>
		/// <param name="name"> Имя параметра запроса. </param>
		/// <param name="value"> Значение параметра. </param>
		public void Add(string name, double? value)
		{
			Remove(key: name);

			if (value == null)
			{
				return;
			}

			base.Add(key: name, value: value.Value.ToString(provider: CultureInfo.InvariantCulture));
		}

		/// <summary>
		/// Добавляет параметр десятичное число.
		/// Если передан null, то добавление не производится.
		/// </summary>
		/// <param name="name"> Имя параметра запроса. </param>
		/// <param name="value"> Значение параметра. </param>
		public void Add(string name, float value)
		{
			Remove(key: name);

			base.Add(key: name, value: value.ToString(provider: CultureInfo.InvariantCulture));
		}

		/// <summary>
		/// Добавляет параметр десятичное число.
		/// Если передан null, то добавление не производится.
		/// </summary>
		/// <param name="name"> Имя параметра запроса. </param>
		/// <param name="value"> Значение параметра. </param>
		public void Add(string name, float? value)
		{
			Remove(key: name);

			if (value == null)
			{
				return;
			}

			base.Add(key: name, value: value.Value.ToString(provider: CultureInfo.InvariantCulture));
		}
	}
}