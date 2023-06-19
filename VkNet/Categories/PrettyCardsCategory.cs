using System;
using System.Collections.ObjectModel;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
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
	public PrettyCardsCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public PrettyCardsCreateResult Create(PrettyCardsCreateParams @params) => _vk.Call<PrettyCardsCreateResult>("prettyCards.create",
		new()
		{
			{
				"owner_id", @params.OwnerId
			},
			{
				"is_board", @params.Button
			},
			{
				"poll_id", @params.Link
			},
			{
				"photo", @params.Photo
			},
			{
				"price", @params.Price
			},
			{
				"price_old", @params.PriceOld
			},
			{
				"title", @params.Title
			}
		});

	/// <inheritdoc />
	public PrettyCardsDeleteResult Delete(PrettyCardsDeleteParams @params) => _vk.Call<PrettyCardsDeleteResult>("prettyCards.delete",
		new()
		{
			{
				"owner_id", @params.OwnerId
			},
			{
				"card_id", @params.CardId
			}
		});

	/// <inheritdoc />
	public PrettyCardsEditResult Edit(PrettyCardsEditParams @params) => _vk.Call<PrettyCardsEditResult>("prettyCards.edit", new()
	{
		{
			"owner_id", @params.OwnerId
		},
		{
			"card_id", @params.CardId
		}
	});

	/// <inheritdoc />
	public VkCollection<PrettyCardsGetByIdResult> Get(PrettyCardsGetParams @params) => _vk.Call<VkCollection<PrettyCardsGetByIdResult>>(
		"prettyCards.get", new()
		{
			{
				"owner_id", @params.OwnerId
			},
			{
				"offset", @params.Offset
			},
			{
				"count", @params.Count
			}
		});

	/// <inheritdoc />
	public ReadOnlyCollection<PrettyCardsGetByIdResult> GetById(PrettyCardsGetByIdParams @params) =>
		_vk.Call<ReadOnlyCollection<PrettyCardsGetByIdResult>>("prettyCards.getById", new()
		{
			{
				"owner_id", @params.OwnerId
			},
			{
				"card_ids", @params.CardIds
			}
		});

	/// <inheritdoc />
	public Uri GetUploadUrl() => _vk.Call<Uri>("prettyCards.getUploadURL", VkParameters.Empty);
}