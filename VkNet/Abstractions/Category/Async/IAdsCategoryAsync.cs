using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Асинхронные методы для работы со стеной пользователя.
	/// </summary>
	public interface IAdsCategoryAsync
	{
		/// <summary>
		/// Возвращает список рекламных кабинетов.
		/// </summary>
		/// <returns>
		/// В случае успеха возвращается список рекламных кабинетов.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/ads.getAccounts
		/// </remarks>
		Task<ReadOnlyCollection<AdsAccount>> GetAccountsAsync();

		/// <summary>
		/// Возвращает список рекламных кабинетов.
		/// </summary>
		/// <returns>
		/// В случае успеха возвращается список рекламных кабинетов.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/ads.getCampaigns
		/// </remarks>
		Task<ReadOnlyCollection<AdsCampaign>> GetCampaignsAsync(AdsGetCampaignsParams @params);
	}
}