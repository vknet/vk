namespace VkNet.Abstractions
{
	/// <summary>
	/// Менеджер версий Vk Api
	/// </summary>
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
	}
}