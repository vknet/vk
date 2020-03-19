using System;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса метода auth.confirm
	/// </summary>
	[Serializable]
	public class AuthConfirmParams
	{
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
		/// Код, отправленный пользователю по SMS. строка, обязательный параметр.
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// Пароль пользователя, который будет использоваться при входе. (Следует
		/// передавать только если он не был передан на
		/// предыдущем шаге auth.signup) Не меньше 6 символов. строка.
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
		/// Битовая маска отвечающая за прохождение обучения использованию приложения.
		/// положительное число.
		/// </summary>
		public long? Intro { get; set; }
	}
}