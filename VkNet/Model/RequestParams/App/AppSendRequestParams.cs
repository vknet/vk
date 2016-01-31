using VkNet.Enums;
using VkNet.Utils;

namespace VkNet.Model.RequestParams
{
	/// <summary>
	/// Параметры запроса SendRequest для приложений.
	/// </summary>
	public struct AppSendRequestParams
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

		/// <summary>
		/// Привести к типу VkParameters.
		/// </summary>
		/// <param name="p">Параметры.</param>
		/// <returns></returns>
		internal static VkParameters ToVkParameters(AppSendRequestParams p)
		{
			var parameters = new VkParameters
			{
				{ "user_id", p.UserId },
				{ "text", p.Text },
				{ "type", p.Type },
				{ "name", p.Name },
				{ "key", p.Key },
				{ "separate", p.Separate }
			};

			return parameters;
		}
	}
}
