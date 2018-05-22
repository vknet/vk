using System.Threading.Tasks;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <inheritdoc />
    public partial class AdsCategory
    {
        /// <inheritdoc />
        public async Task<AdsGetAccountsObject> GetAccountsAsync(bool skipAuthorization = false)
        {
            return await TypeHelper.TryInvokeMethodAsync(() => _vk.Ads.GetAccounts(skipAuthorization));
        }

    }
}
