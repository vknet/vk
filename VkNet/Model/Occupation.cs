using System;
using Newtonsoft.Json;
using VkNet.Enums.SafetyEnums;
using VkNet.Utils;
using VkNet.Utils.JsonConverter;

namespace VkNet.Model
{
	/// <summary>
	/// Информация о текущем роде занятия пользователя.
	/// </summary>
	[Serializable]
	public class Occupation
	{
		/// <summary>
		/// Название школы, вуза или места работы
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Идентификатор школы, вуза, группы компании (в которой пользователь работает).
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// Информация о текущем роде занятия пользователя.
		/// </summary>
		[JsonConverter(typeof(SafetyEnumJsonConverter))]
		public OccupationType Type { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Occupation FromJson(VkResponse response)
		{
			var occupation = new Occupation
			{
					Id = response[key: "id"]
					, Name = response[key: "name"]
					, Type = response[key: "type"]
			};

			return occupation;
		}
	}
}