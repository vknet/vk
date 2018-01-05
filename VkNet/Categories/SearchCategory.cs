using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
    /// <inheritdoc />
    public partial class SearchCategory : ISearchCategory
    {
        /// <inheritdoc />
        public SearchCategory(VkApi vk)
        {
            Vk = vk;
        }

        private VkApi Vk { get; set; }

        /// <inheritdoc />
        public VkCollection<SearchHintsItem> GetHints(SearchGetHintsParams @params)
        {
            return Vk.Call<VkCollection<SearchHintsItem>>("search.getHints", @params);
        }
    }
}