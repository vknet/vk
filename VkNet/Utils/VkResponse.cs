using System;
using System.Net;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using VkNet.Enums;
using VkNet.Model;

namespace VkNet.Utils
{
	/// <summary>
	/// Ответ vk.com
	/// </summary>
	[CanBeNull]
	public sealed partial class VkResponse
	{
		/// <summary>
		/// JSON токен
		/// </summary>
		private readonly JToken _token;

		/// <summary>
		/// Ответ vk.com
		/// </summary>
		/// <param name="token"> JSON токен. </param>
		public VkResponse(JToken token)
		{
			_token = token;
		}

		/// <summary>
		/// Сырой JSON.
		/// </summary>
		public string RawJson { get; set; }

		/// <summary>
		/// Получить объект по указанному ключу.
		/// </summary>
		/// <param name="key"> Ключ. </param>
		/// <returns> Объект </returns>
		public VkResponse this[object key]
		{
			get
			{
				if (_token is JArray && key is string)
				{
					return null;
				}

				var token = _token[key: key];

				return token != null && token.Type != JTokenType.Null
					? new VkResponse(token)
					: null;
			}
		}

		/// <summary>
		/// HasToken
		/// </summary>
		/// <returns> </returns>
		public bool HasToken()
		{
			return _token != null && _token.HasValues;
		}

		/// <summary>
		/// Определяет, содержит ли JSON указанный ключ.
		/// </summary>
		/// <param name="key"> Ключ. </param>
		/// <returns> Признак наличия ключа в JSON </returns>
		public bool ContainsKey(string key)
		{
			if (!(_token is JObject))
			{
				return false;
			}

			var token = _token[key: key];

			return token != null;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator VkResponseArray(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			var resp = response.ContainsKey(key: "items") ? response[key: "items"] : response;

			return !(resp._token is JArray array) ? null : new VkResponseArray(array: array);
		}

		/// <summary>
		/// Преобразовать объект в строку.
		/// </summary>
		/// <returns>
		/// Строковое представление объекта.
		/// </returns>
		public override string ToString()
		{
			return _token.ToString();
		}

	#region Model exceptions

		/// <summary>
		/// Преобразовать из VkResponse
		/// </summary>
		/// <param name="response"> Ответ. </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator Coordinates(VkResponse response)
		{
			if (response?._token == null)
			{
				return null;
			}

			return Coordinates.FromJson(response: response);
		}

	#endregion

	#region System types

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator bool(VkResponse response)
		{
			return response != null && response == 1;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator bool?(VkResponse response)
		{
			return response == null ? (bool?) null : response == 1;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator long(VkResponse response)
		{
			return (long) response._token;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator long?(VkResponse response)
		{
			return response != null ? (long?) response._token : null;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator byte?(VkResponse response)
		{
			return response != null ? (byte?) response._token : null;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator byte(VkResponse response)
		{
			return (byte) response._token;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator ulong(VkResponse response)
		{
			return (ulong) response._token;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator ulong?(VkResponse response)
		{
			return response != null ? (ulong?) response._token : null;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator float(VkResponse response)
		{
			return (float) response._token;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator float?(VkResponse response)
		{
			return response != null ? (float?) response._token : null;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator decimal(VkResponse response)
		{
			return (decimal) response._token;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator decimal?(VkResponse response)
		{
			return response != null ? (decimal?) response._token : null;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator uint(VkResponse response)
		{
			return (uint) response._token;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator uint?(VkResponse response)
		{
			return response != null ? (uint?) response._token : null;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator int(VkResponse response)
		{
			return (int) response._token;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator int?(VkResponse response)
		{
			return response != null ? (int?) response._token : null;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator string(VkResponse response)
		{
			return response == null ? null : WebUtility.HtmlDecode(value: (string) response._token);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator DateTime?(VkResponse response)
		{
			var dateStringValue = response?.ToString();

			if (string.IsNullOrWhiteSpace(value: dateStringValue)
				|| !long.TryParse(s: dateStringValue, result: out var unixTimeStamp)
				|| unixTimeStamp <= 0)
			{
				return null;
			}

			return TimestampToDateTime(unixTimeStamp: unixTimeStamp);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator DateTime(VkResponse response)
		{
			if (response == null)
			{
				throw new ArgumentNullException(paramName: nameof(response));
			}

			var dateStringValue = response.ToString();

			if (string.IsNullOrWhiteSpace(value: dateStringValue))
			{
				throw new ArgumentException(message: "Пустое значение невозможно преобразовать в дату", paramName: nameof(response));
			}

			if (!long.TryParse(s: dateStringValue, result: out var unixTimeStamp) || unixTimeStamp <= 0)
			{
				throw new ArgumentException(message: "Невозможно преобразовать в дату", paramName: nameof(response));
			}

			return TimestampToDateTime(unixTimeStamp: unixTimeStamp);
		}

		/// <summary>
		/// Timestamps to date time.
		/// </summary>
		/// <param name="unixTimeStamp"> The unix time stamp. </param>
		/// <returns> </returns>
		public static DateTime TimestampToDateTime(long unixTimeStamp)
		{
			var dt = new DateTime(year: 1970, month: 1, day: 1, hour: 0, minute: 0, second: 0, millisecond: 0, kind: DateTimeKind.Utc);

			return dt.AddSeconds(value: unixTimeStamp);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator Uri(VkResponse response)
		{
			return Uri.TryCreate(uriString: response, uriKind: UriKind.Absolute, result: out var uriResult) ? uriResult : null;
		}

	#endregion

	#region Enums

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator PageAccessKind?(VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<PageAccessKind>(value: response);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator GroupPublicity?(VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<GroupPublicity>(value: response);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator ContentAccess?(VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<ContentAccess>(value: response);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator GroupSubjects?(VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<GroupSubjects>(value: response);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AdminLevel?(VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<AdminLevel>(value: response);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AudioGenre?(VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<AudioGenre>(value: response);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator MessageType?(VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<MessageType>(value: response);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response"> Ответ vk.com </param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator MessageReadState?(VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<MessageReadState>(value: response);
		}

	#endregion
	}
}