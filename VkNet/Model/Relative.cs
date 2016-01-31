using VkNet.Enums.SafetyEnums;

namespace VkNet.Model
{
    using System;
	using Utils;

    /// <summary>
    /// Информация о родственнике.
    /// См. описание <see href="http://vk.com/dev/fields"/>. Раздел relatives.
    /// </summary>
    [Serializable]
    public class Relative
	{
		/// <summary>
		/// Идентификатор родственника.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Тип родственника (sibling и т.п.)
		/// </summary>
		public RelativeType Type { get; set; }

		/// <summary>
		/// Имя родственника, если он не является пользователем ВКонтакте.
		/// </summary>
		public string Name { get; set; }

		#region Методы
		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response">Ответ сервера.</param>
		/// <returns></returns>
		internal static Relative FromJson(VkResponse response)
		{
			var relative = new Relative
			{
				Id = response["id"] ?? response["uid"],
				Type = response["type"],
				Name = response["name"]
			};

			return relative;
		}

		#endregion
	}
}