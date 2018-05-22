using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <inheritdoc />
    public partial class AdsCategory
    {
        /// <inheritdoc />
        public async Task<ReadOnlyCollection<AdsAccount>> GetAccountsAsync(bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Ads.GetAccounts(skipAuthorization));
        }

    }
}
