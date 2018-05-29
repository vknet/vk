using System;
using VkNet.Utils;

namespace VkNet.Model
{
	/// <summary>
	/// Улица
	/// </summary>
	[Serializable]
	public class Street
	{
		/// <summary>
		/// Идентификатор улицы
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Название улицы
		/// </summary>
		public string Title { get; set; }

	#region public Methods

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Street FromJson(VkResponse response)
		{
			var street = new Street
			{
					Id = response[key: "sid"] ?? response[key: "id"]
					, Title = response[key: "name"]
			};

			return street;
		}

	#endregion
	}
}