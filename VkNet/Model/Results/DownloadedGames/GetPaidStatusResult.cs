using System;

namespace VkNet.Model.Results.DownloadedGames
{
	/// <summary>
	/// Результат метода downloadedGames.getPaidStatus
	/// </summary>
	[Serializable]
	public class GetPaidStatusResult
	{
		/// <summary>
		/// Оплачено пользователем
		/// </summary>
		public bool IsPaid { get; set; }
	}
}