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
		/// Проверить что версия больше либо равна значению <see cref="major"/> и <see cref="minor"/>
		/// </summary>
		/// <param name="major">Мажорная версия Vk Api</param>
		/// <param name="minor">Минорная версия Vk Api</param>
		/// <returns><c>true</c> если версия больше или равна значению <see cref="major"/> и <see cref="minor"/></returns>
		bool IsGreaterThanOrEqual(int major, int minor);

		/// <summary>
		/// Проверить что версия меньше либо равна значению <see cref="major"/> и <see cref="minor"/>
		/// </summary>
		/// <param name="major"></param>
		/// <param name="minor"></param>
		/// <returns></returns>
		bool IsLessThanOrEqual(int major, int minor);
	}
}