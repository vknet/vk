namespace VkNet.Abstractions.Core
{
	/// <summary>
	/// Менеджер версий Vk Api
	/// </summary>
	/// <remarks>
	/// <a href="https://vk.com/dev/versions">Версии API</a>
	/// </remarks>
	public interface IVkApiVersionManager
	{
		/// <summary>
		/// Версия Vk Api
		/// </summary>
		string Version { get; }

		/// <summary>
		/// Установить версию Vk Api по умолчанию
		/// </summary>
		/// <param name="major">Мажорная версия Vk Api</param>
		/// <param name="minor">Минорная версия Vk Api</param>
		void SetVersion(int major, int minor);

		/// <summary>
		/// Проверить что версия больше либо равна значению <paramref name="major"/> и <paramref name="minor"/>
		/// </summary>
		/// <param name="major">Мажорная версия Vk Api</param>
		/// <param name="minor">Минорная версия Vk Api</param>
		/// <returns>
		/// <c>true</c> если версия больше или равна значению <paramref name="major"/> и <paramref name="minor"/>
		/// </returns>
		bool IsGreaterThanOrEqual(int major, int minor);

		/// <summary>
		/// Проверить что версия меньше либо равна значению <paramref name="major"/> и <paramref name="minor"/>
		/// </summary>
		/// <param name="major">Мажорная версия Vk Api</param>
		/// <param name="minor">Минорная версия Vk Api</param>
		/// <returns>
		/// <c>true</c> если версия меньше или равна значению <paramref name="major"/> и <paramref name="minor"/>
		/// </returns>
		bool IsLessThanOrEqual(int major, int minor);
	}
}