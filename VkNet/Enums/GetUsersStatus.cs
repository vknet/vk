namespace VkNet.Enums
{
	/// <summary>
	/// Тип действия
	/// </summary>
	public enum GetUsersStatus
	{
		/// <summary>
		/// Начало действия;
		/// </summary>
		Start = 0

		, /// <summary>
		/// Завершения действия;
		/// </summary>
		End = 1

		, /// <summary>
		/// Действия по блокированию пользователей;
		/// </summary>
		Lock = 2

		, /// <summary>
		/// Начало действия в тестовом режиме;
		/// </summary>
		StartTest = 4

		, /// <summary>
		/// Завершения действия в тестовом режиме.
		/// </summary>
		EndTest = 5
	}
}