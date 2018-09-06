using VkNet.Utils;

namespace VkNet.Enums
{
	/// <summary>
	/// Информация о главной секции в сообществе
	/// </summary>
	public enum MainSection
	{
		/// <summary>
		/// Главная секция отсутствует
		/// </summary>
		[DefaultValue]
		NoSection = 0

		, /// <summary>
		/// Фотографии
		/// </summary>
		Photo

		, /// <summary>
		/// Обсуждения
		/// </summary>
		Post

		, /// <summary>
		/// Аудиозаписи
		/// </summary>
		Audio

		, /// <summary>
		/// Видеозаписи
		/// </summary>
		Video

		, /// <summary>
		/// Товары
		/// </summary>
		Goods
	}
}