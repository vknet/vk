using System;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса подписывания устройства на базе iOS, Android или Windows
	/// Phone на получение Push-уведомлений.
	/// </summary>
	[Serializable]
	public class AccountRegisterDeviceParams
	{
		/// <summary>
		/// Идентификатор устройства, используемый для отправки уведомлений. (для mpns
		/// идентификатор должен представлять из
		/// себя URL для отправки уведомлений) строка, обязательный параметр.
		/// </summary>
		public string Token { get; set; }

		/// <summary>
		/// Cтроковое название модели устройства. строка.
		/// </summary>
		public string DeviceModel { get; set; }

		/// <summary>
		/// Год устройства целое число.
		/// </summary>
		public long? DeviceYear { get; set; }

		/// <summary>
		/// Уникальный идентификатор устройства. строка, обязательный параметр.
		/// </summary>
		public string DeviceId { get; set; }

		/// <summary>
		/// Строковая версия операционной системы устройства. строка.
		/// </summary>
		public string SystemVersion { get; set; }

		/// <summary>
		/// Сериализованный JSON-объект, описывающий настройки уведомлений в специальном
		/// формате данные в формате JSON,
		/// доступен начиная с версии 5.31.
		/// </summary>
		public PushSettings Settings { get; set; }

		/// <summary>
		/// Флаг предназначен для iOS устройств. 1 — использовать sandbox сервер для
		/// отправки push-уведомлений, 0 — не
		/// использовать флаг, может принимать значения 1 или 0, по умолчанию 0.
		/// </summary>
		public bool? Sandbox { get; set; }

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p"> Параметры. </param>
		/// <returns> Объект типа AccountRegisterDeviceParams </returns>
		public static VkParameters ToVkParameters(AccountRegisterDeviceParams p)
		{
			var result = new VkParameters
			{
					{ "token", p.Token }
					, { "device_model", p.DeviceModel }
					, { "device_year", p.DeviceYear }
					, { "device_id", p.DeviceId }
					, { "system_version", p.SystemVersion }
					, { "settings", p.Settings }
					, { "sandbox", p.Sandbox }
			};

			return result;
		}
	}
}