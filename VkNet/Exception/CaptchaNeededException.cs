using System;
using VkNet.Utils;

namespace VkNet.Exception
{
	/// <summary>
	/// Исключение, выбрасываемое при необходимости ввода капчи для вызова метода
	/// Код ошибки - 14
	/// </summary>
	[Serializable]
	public class CaptchaNeededException : VkApiMethodInvokeException
	{
		/// <summary>
		/// Создания экземпляра CaptchaNeededException
		/// </summary>
		/// <param name="sid"> Сид </param>
		/// <param name="img"> Uri-адрес изображения с капчей </param>
		public CaptchaNeededException(long sid, string img) : this(sid: sid
				, img: string.IsNullOrEmpty(value: img) ? null : new Uri(uriString: img))
		{
		}

		/// <summary>
		/// Создания экземпляра CaptchaNeededException
		/// </summary>
		/// <param name="sid"> Сид </param>
		/// <param name="img"> Uri-адрес изображения с капчей </param>
		public CaptchaNeededException(long sid, Uri img)
		{
			Sid = sid;
			Img = img;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса VkApiException
		/// </summary>
		/// <param name="response"> Ответ от сервера vk </param>
		public CaptchaNeededException(VkResponse response) : base(message: response[key: "error_msg"])
		{
			ErrorCode = response[key: "error_code"];
			Sid = response[key: "captcha_sid"];
			Img = response[key: "captcha_img"];
		}

		/// <summary>
		/// Идентификатор капчи
		/// </summary>
		public long Sid { get; }

		/// <summary>
		/// Uri-адрес изображения с капчей
		/// </summary>
		public Uri Img { get; }
	}
}