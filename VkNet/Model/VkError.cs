using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Ошибка при вызове метода exeсute
	/// </summary>
	[Serializable]
	public class VkError
	{
		/// <summary>
		/// Метод в котором произошла ошибка
		/// </summary>
		[JsonProperty("method")]
		public string Method { get; set; }

		/// <summary>
		/// Код ошибки
		/// </summary>
		[JsonProperty("error_code")]
		public int ErrorCode { get; set; }

		/// <summary>
		/// Сообщение об ошибке
		/// </summary>
		[JsonProperty("error_msg")]
		public string ErrorMessage { get; set; }

		/// <summary>
		/// Параметры запроса
		/// </summary>
		[JsonProperty("request_params")]
		public ReadOnlyCollection<RequestParam> RequestParams { get; set; }

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		[JsonProperty("captcha_sid", NullValueHandling = NullValueHandling.Ignore)]
		public ulong CaptchaSid { get; set; }

		/// <summary>
		/// Ссылка на изображение капчи
		/// </summary>
		[JsonProperty("captcha_img", NullValueHandling = NullValueHandling.Ignore)]
		public Uri CaptchaImg { get; set; }

		/// <summary>
		/// Адрес который необходимо открыть в браузере для подтверждения валидации.
		/// </summary>
		[JsonProperty("redirect_uri", NullValueHandling = NullValueHandling.Ignore)]
		public Uri RedirectUri { get; set; }
	}
}