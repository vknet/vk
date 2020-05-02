using System;
using System.Collections.ObjectModel;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <inheritdoc cref="IPrettyCardsCategoryAsync"/>
	public interface IPrettyCardsCategory : IPrettyCardsCategoryAsync
	{
		/// <inheritdoc cref="IPrettyCardsCategoryAsync.CreateAsync"/>
		PrettyCardsCreateResult Create(PrettyCardsCreateParams @params);

		/// <inheritdoc cref="IPrettyCardsCategoryAsync.DeleteAsync"/>
		PrettyCardsDeleteResult Delete(PrettyCardsDeleteParams @params);

		/// <inheritdoc cref="IPrettyCardsCategoryAsync.EditAsync"/>
		PrettyCardsEditResult Edit(PrettyCardsEditParams @params);

		/// <inheritdoc cref="IPrettyCardsCategoryAsync.GetAsync"/>
		VkCollection<PrettyCardsGetByIdResult> Get(PrettyCardsGetParams @params);

		/// <inheritdoc cref="IPrettyCardsCategoryAsync.GetByIdAsync"/>
		ReadOnlyCollection<PrettyCardsGetByIdResult> GetById(PrettyCardsGetByIdParams @params);

		/// <inheritdoc cref="IPrettyCardsCategoryAsync.GetUploadUrlAsync"/>
		Uri GetUploadUrl();
	}
}