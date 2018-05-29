using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Приложение.
	/// </summary>
	[Serializable]
	public class Application
	{
		/// <summary>
		/// Магазин.
		/// </summary>
		public Store Store { get; set; }

		/// <summary>
		/// Идентификатор приложения в магазине;.
		/// </summary>
		public long? AppId { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Application FromJson(VkResponse response)
		{
			var application = new Application
			{
					Store = response[key: "store"]
					, AppId = response[key: "app_id"]
			};

			return application;
		}
	}
}