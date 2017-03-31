using System.Net;
using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;
using VkNet.Enums;

namespace VkNet.Utils
{
	/// <summary>
	/// Ответ vk.com
	/// </summary>
	public sealed partial class VkResponse
	{
		/// <summary>
		/// JSON токен
		/// </summary>
		private readonly JToken _token;

		/// <summary>
		/// Сырой JSON.
		/// </summary>
		public string RawJson { get; set; }

		/// <summary>
		/// Ответ vk.com
		/// </summary>
		/// <param name="token">JSON токен.</param>
		public VkResponse(JToken token)
		{
			_token = token;
		}

		/// <summary>
		/// Определяет, содержит ли JSON указанный ключ.
		/// </summary>
		/// <param name="key">Ключ.</param>
		/// <returns>Признак наличия ключа в JSON</returns>
		public bool ContainsKey(string key)
		{
			if (!(_token is JObject))
			{
				return false;
			}

			var token = _token[key];
			return token != null;
		}

		/// <summary>
		/// Получить объект по указанному ключу.
		/// </summary>
		/// <param name="key">Ключ.</param>
		/// <returns>Объект</returns>
		public VkResponse this[object key]
		{
			get
			{
				if (_token is JArray && key is string)
				{
					return null;
				}

				var token = _token[key];
				return token != null ? new VkResponse(_token[key]) : null;
			}
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator VkResponseArray(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			var resp = response.ContainsKey("items") ? response["items"] : response;

			var array = resp._token as JArray;
			return array == null ? null : new VkResponseArray(array);
		}

		/// <summary>
		/// Преобразовать объект в строку.
		/// </summary>
		/// <returns>
		/// Строковое представление объекта.
		/// </returns>
		public override string ToString() => _token.ToString();

		#region System types

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator bool(VkResponse response) => response != null && response == 1;

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator bool? (VkResponse response)
		{
			return response == null ? (bool?)null : response == 1;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator long(VkResponse response)
		{
			return (long)response._token;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator long? (VkResponse response)
		{
			return response != null ? (long?)response._token : null;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator ulong(VkResponse response)
		{
			return (ulong)response._token;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator ulong? (VkResponse response)
		{
			return response != null ? (ulong?)response._token : null;
		}

        /// <summary>
        /// Выполняет неявное преобразование из VkResponse
        /// </summary>
        /// <param name="response">Ответ vk.com</param>
        /// <returns>
        /// Результат преобразования.
        /// </returns>
        public static implicit operator Collection<long>(VkResponse response)
		{
			return response?.ToCollectionOf<long>(i => i);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator float(VkResponse response)
		{
			return (float)response._token;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator float? (VkResponse response)
		{
			return response != null ? (float?)response._token : null;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator decimal(VkResponse response)
		{
			return (decimal)response._token;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator decimal? (VkResponse response)
		{
			return response != null ? (decimal?)response._token : null;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator uint(VkResponse response)
		{
			return (uint)response._token;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator uint? (VkResponse response)
		{
			return response != null ? (uint?)response._token : null;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator int(VkResponse response)
		{
			return (int)response._token;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator int? (VkResponse response)
		{
			return response != null ? (int?)response._token : null;
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator string(VkResponse response)
		{
			return response == null ? null : WebUtility.HtmlDecode((string)response._token);
		}

        /// <summary>
        /// Выполняет неявное преобразование из VkResponse
        /// </summary>
        /// <param name="response">Ответ vk.com</param>
        /// <returns>
        /// Результат преобразования.
        /// </returns>
        public static implicit operator Collection<string>(VkResponse response)
		{
			return response.ToCollectionOf<string>(s => s);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator DateTime? (VkResponse response)
		{
			var dateStringValue = response?.ToString();
			long unixTimeStamp;
			if (string.IsNullOrWhiteSpace(dateStringValue) ||
				(!long.TryParse(dateStringValue, out unixTimeStamp) || unixTimeStamp <= 0))
			{
				return null;
			}

			// Unix Timestamps is seconds past epoch
			var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			return dt.AddSeconds(unixTimeStamp).ToLocalTime();
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator DateTime(VkResponse response)
		{
			if (response == null)
			{
				throw new ArgumentNullException(nameof(response));
			}

			var dateStringValue = response.ToString();
			if (string.IsNullOrWhiteSpace(dateStringValue))
			{
				throw new ArgumentException("Пустое значение невозможно преобразовать в дату", nameof(response));
			}

			long unixTimeStamp;
			if (!long.TryParse(dateStringValue, out unixTimeStamp) || unixTimeStamp <= 0)
			{
				throw new ArgumentException("Невозможно преобразовать в дату", nameof(response));
			}

			// Unix Timestamps is seconds past epoch
			var dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			return dt.AddSeconds(unixTimeStamp).ToLocalTime();
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator Uri(VkResponse response)
		{
		    Uri uriResult;

		    return Uri.TryCreate(response, UriKind.Absolute, out uriResult) ? uriResult : null;
		}

		#endregion

		#region Enums

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator PageAccessKind? (VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<PageAccessKind>(response);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator GroupPublicity? (VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<GroupPublicity>(response);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator ContentAccess? (VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<ContentAccess>(response);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator GroupSubjects? (VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<GroupSubjects>(response);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AdminLevel? (VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<AdminLevel>(response);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator AudioGenre? (VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<AudioGenre>(response);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator MessageType? (VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<MessageType>(response);
		}

		/// <summary>
		/// Выполняет неявное преобразование из VkResponse
		/// </summary>
		/// <param name="response">Ответ vk.com</param>
		/// <returns>
		/// Результат преобразования.
		/// </returns>
		public static implicit operator MessageReadState? (VkResponse response)
		{
			return response == null ? null : Utilities.NullableEnumFrom<MessageReadState>(response);
		}

		#endregion

	}
}