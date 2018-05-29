using VkNet.Abstractions;
using System.Collections.ObjectModel;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <summary>
	/// Методы для работы со стеной пользователя.
	/// </summary>
	public partial class AdsCategory : IAdsCategory
	{
		private readonly VkApi _vk;

		/// <summary>
		///
		/// </summary>
		/// <param name="vk"></param>
		public AdsCategory(VkApi vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public ReadOnlyCollection<AdsAccount> GetAccounts()
		{
			return _vk.Call<ReadOnlyCollection<AdsAccount>>("ads.getAccounts", new VkParameters());
		}

        /// <summary>
        /// Возвращает список рекламных кабинетов.
        /// </summary>
        /// <returns>
        /// В случае успеха возвращается список рекламных кабинетов.
        /// </returns>
        /// <remarks>
        /// Страница документации ВКонтакте https://vk.com/dev/ads.getCampaigns
        /// </remarks>
        public ReadOnlyCollection<AdsCampaign> GetCampaigns(AdsGetCampaignsParams @params)
        {
            return _vk.Call<ReadOnlyCollection<AdsCampaign>>("ads.getCampaigns", @params);
        }
    }
}