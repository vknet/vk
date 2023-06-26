using System;
using System.Net;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using VkNet.Enums;

namespace VkNet.Utils;

/// <summary>
/// Ответ vk.com
/// </summary>
[CanBeNull]
public sealed class VkResponse
{
	/// <summary>
	/// JSON токен
	/// </summary>
	private readonly JToken _token;

	/// <summary>
	/// Ответ vk.com
	/// </summary>
	/// <param name="token"> JSON токен. </param>
	public VkResponse(JToken token) => _token = token;

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
		get {
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
	public bool HasToken() => _token != null && _token.HasValues;

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

		var resp = response.ContainsKey(key: "items")
			? response[key: "items"]
			: response;

		return !(resp._token is JArray array)
			? null
			: new VkResponseArray(array: array);
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
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator bool(VkResponse response) => response != null && response == 1;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator bool?(VkResponse response) => response == null
		? null
		: response == 1;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator long(VkResponse response) => (long) response._token;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator long?(VkResponse response) => response != null
		? (long?) response._token
		: null;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator byte?(VkResponse response) => response != null
		? (byte?) response._token
		: null;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator byte(VkResponse response) => (byte) response._token;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator ulong(VkResponse response) => (ulong) response._token;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator ulong?(VkResponse response) => response != null
		? (ulong?) response._token
		: null;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator float(VkResponse response) => (float) response._token;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator float?(VkResponse response) => response != null
		? (float?) response._token
		: null;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator decimal(VkResponse response) => (decimal) response._token;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator decimal?(VkResponse response) => response != null
		? (decimal?) response._token
		: null;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator uint(VkResponse response) => (uint) response._token;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator uint?(VkResponse response) => response != null
		? (uint?) response._token
		: null;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator int(VkResponse response) => (int) response._token;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator int?(VkResponse response) => response != null
		? (int?) response._token
		: null;

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator string(VkResponse response) => response == null
		? null
		: WebUtility.HtmlDecode(value: (string) response._token);

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
			|| !long.TryParse(dateStringValue, out var unixTimeStamp)
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
			throw new ArgumentException("Пустое значение невозможно преобразовать в дату", nameof(response));
		}

		if (!long.TryParse(dateStringValue, out var unixTimeStamp) || unixTimeStamp <= 0)
		{
			throw new ArgumentException("Невозможно преобразовать в дату", nameof(response));
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
		var dt = new DateTime(1970, 1, 1, 0, 0,
			0, 0, DateTimeKind.Utc);

		return dt.AddSeconds(value: unixTimeStamp);
	}

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator Uri(VkResponse response) => Uri.TryCreate(response, UriKind.Absolute, out var uriResult)
		? uriResult
		: null;

	#endregion

	#region Enums

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator PageAccessKind?(VkResponse response) => response == null
		? null
		: Utilities.NullableEnumFrom<PageAccessKind>(value: response);

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator GroupPublicity?(VkResponse response) => response == null
		? null
		: Utilities.NullableEnumFrom<GroupPublicity>(value: response);

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator ContentAccess?(VkResponse response) => response == null
		? null
		: Utilities.NullableEnumFrom<ContentAccess>(value: response);

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator GroupSubjects?(VkResponse response) => response == null
		? null
		: Utilities.NullableEnumFrom<GroupSubjects>(value: response);

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator AdminLevel?(VkResponse response) => response == null
		? null
		: Utilities.NullableEnumFrom<AdminLevel>(value: response);

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator AudioGenre?(VkResponse response) => response == null
		? null
		: Utilities.NullableEnumFrom<AudioGenre>(value: response);

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator MessageType?(VkResponse response) => response == null
		? null
		: Utilities.NullableEnumFrom<MessageType>(value: response);

	/// <summary>
	/// Выполняет неявное преобразование из VkResponse
	/// </summary>
	/// <param name="response"> Ответ vk.com </param>
	/// <returns>
	/// Результат преобразования.
	/// </returns>
	public static implicit operator MessageReadState?(VkResponse response) => response == null
		? null
		: Utilities.NullableEnumFrom<MessageReadState>(value: response);

	#endregion
}