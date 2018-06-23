using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	/// <inheritdoc />
	public partial class AdsCategory
	{
		/// <inheritdoc />
		public Task<ReadOnlyCollection<AdsAccount>> GetAccountsAsync()
		{
			return TypeHelper.TryInvokeMethodAsync(func: GetAccounts);
		}

		/// <inheritdoc />
		public Task<ReadOnlyCollection<AdsCampaign>> GetCampaignsAsync(AdsGetCampaignsParams @params)
		{
			return TypeHelper.TryInvokeMethodAsync(func: () => GetCampaigns(@params: @params));
		}
	}
}