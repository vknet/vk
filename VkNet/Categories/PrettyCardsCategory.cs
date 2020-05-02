using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Categories
{
	public partial class PrettyCardsCategory : IPrettyCardsCategory
	{
		/// <summary>
		/// API.
		/// </summary>
		private readonly IVkApiInvoke _vk;

		/// <summary>
		/// Методы для работы с опросами.
		/// </summary>
		/// <param name="vk"> API. </param>
		public PrettyCardsCategory(IVkApiInvoke vk)
		{
			_vk = vk;
		}

		/// <inheritdoc />
		public PrettyCardsCreateResult Create(PrettyCardsCreateParams @params)
		{
			return _vk.Call<PrettyCardsCreateResult>("prettyCards.create",
				new VkParameters
				{
					{ "owner_id", @params.OwnerId },
					{ "is_board", @params.Button },
					{ "poll_id", @params.Link },
					{ "photo", @params.Photo },
					{ "price", @params.Price },
					{ "price_old", @params.PriceOld },
					{ "title", @params.Title }
				});
		}

		/// <inheritdoc />
		public PrettyCardsDeleteResult Delete(PrettyCardsDeleteParams @params)
		{
			return _vk.Call<PrettyCardsDeleteResult>("prettyCards.delete",
				new VkParameters
				{
					{ "owner_id", @params.OwnerId },
					{ "card_id", @params.CardId }
				});
		}

		/// <inheritdoc />
		public PrettyCardsEditResult Edit(PrettyCardsEditParams @params)
		{
			return _vk.Call<PrettyCardsEditResult>("prettyCards.edit", new VkParameters
			{
				{ "owner_id", @params.OwnerId },
				{ "card_id", @params.CardId }
			});

		}

		/// <inheritdoc />
		public object Get(object @params)
		{
			return _vk.Call("prettyCards.get", VkParameters.Empty);
		}

		/// <inheritdoc />
		public object GetById(object @params)
		{
			return _vk.Call("prettyCards.getById", VkParameters.Empty);
		}

		/// <inheritdoc />
		public object GetUploadUrl(object @params)
		{
			return _vk.Call("prettyCards.getUploadURL", VkParameters.Empty);
		}
	}
}