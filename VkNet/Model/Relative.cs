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
		public string Type { get; set; }

		/// <summary>
		/// Имя родственника, если он не является пользователем ВКонтакте.
		/// </summary>
		public string Name { get; set; }

		#region Методы

		internal static Relative FromJson(VkResponse response)
		{
			var relative = new Relative();

			// Согласно документации VK API, должно возвращаться поле id, однако фактически может возвращаться uid (для старых версий API).
			// Можно будет парсить только id после перевода всех методов на более новые версии (как минимум Users.Search).
			if (response.ContainsKey("id"))
				relative.Id = response["id"];
			else if (response.ContainsKey("uid"))
				relative.Id = response["uid"];

			relative.Type = response["type"];
			relative.Name = response["name"];

			return relative;
		}

		#endregion
	}
}