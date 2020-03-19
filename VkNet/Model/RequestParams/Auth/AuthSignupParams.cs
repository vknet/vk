using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Enums;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса регистрации нового пользователя по номеру телефона.
	/// </summary>
	[Serializable]
	public class AuthSignupParams
	{
		/// <summary>
		/// Имя пользователя. строка, обязательный параметр.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия пользователя. строка, обязательный параметр.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Дата рождения пользователя.
		/// </summary>
		[JsonConverter(converterType: typeof(UnixDateTimeConverter))]
		public DateTime Birthday { get; set; }

		/// <summary>
		/// Идентификатор Вашего приложения. целое число, обязательный параметр.
		/// </summary>
		public long ClientId { get; set; }

		/// <summary>
		/// Секретный ключ приложения, доступный в резделе редактирования приложения.
		/// строка, обязательный параметр.
		/// </summary>
		public string ClientSecret { get; set; }

		/// <summary>
		/// Номер телефона регистрируемого пользователя. Номер телефона может быть проверен
		/// заранее методом auth.checkPhone.
		/// строка, обязательный параметр.
		/// </summary>
		public string Phone { get; set; }

		/// <summary>
		/// Пароль пользователя, который будет использоваться при входе. Не меньше 6
		/// символов. Также пароль может быть указан
		/// позже, при вызове метода auth.confirm. строка.
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// 1 — тестовый режим, при котором не будет зарегистрирован новый пользователь, но
		/// при этом номер не будет проверяться
		/// на использованность. 0 — (по умолчанию) рабочий. флаг, может принимать значения
		/// 1 или 0.
		/// </summary>
		public bool? TestMode { get; set; }

		/// <summary>
		/// 1 — в случае, если вместо SMS необходимо позвонить на указанный номер и
		/// продиктовать код голосом. 0 — (по
		/// умолчанию) необходимо отправить SMS. В случае если СМС не дошло до пользователя
		/// – необходимо вызвать метод повторно
		/// указав voice=1 и sid, полученный при первом вызове метода. флаг, может
		/// принимать значения 1 или 0.
		/// </summary>
		public bool? Voice { get; set; }

		/// <summary>
		/// Пол пользователя: 1 — женский, 2 — мужской. положительное число.
		/// </summary>
		public Sex Sex { get; set; }

		/// <summary>
		/// Идентификатор сессии, необходимый при повторном вызове метода, в случае если
		/// SMS сообщение доставлено не было. При
		/// первом вызове этот параметр не передается. строка.
		/// </summary>
		public string Sid { get; set; }
	}
}