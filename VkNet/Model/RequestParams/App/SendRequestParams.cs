using System;
using VkNet.Enums;

namespace VkNet.Model.RequestParams.App
{
	/// <summary>
	/// Параметры запроса SendRequest для приложений.
	/// </summary>
	public class SendRequestParams
	{
		/// <summary>
		/// Идентификатор пользователя, которому следует отправить запрос.
		/// </summary>
		public ulong UserId
		{ get; set; }

		/// <summary>
		/// Текст запроса.
		/// </summary>
		public string Text
		{ get; set; }

		/// <summary>
		/// Тип запроса, может принимать значения:.
		/// </summary>
		public AppRequestType Type
		{ get; set; }

		/// <summary>
		/// Уникальное в рамках приложения имя для каждого вида отправляемого запроса.
		/// </summary>
		public string Name
		{ get; set; }

		/// <summary>
		/// Строка, которая будет возвращена назад при переходе пользователя по запросу в приложение. Может использоваться для подсчета конверсии.
		/// </summary>
		public string Key
		{ get; set; }

		/// <summary>
		/// Запрет на группировку запроса с другими, имеющими тот же name. По умолчанию отключен.
		/// </summary>
		public bool Separate
		{ get; set; }
	}
}
