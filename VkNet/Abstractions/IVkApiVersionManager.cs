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
		/// <param name="version">Версия Vk Api</param>
		void SetVersion(string version);
	}
}