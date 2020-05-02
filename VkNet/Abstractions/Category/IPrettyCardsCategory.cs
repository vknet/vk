using VkNet.Model;
using VkNet.Model.RequestParams;

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
		object Edit(object @params);

		/// <inheritdoc cref="IPrettyCardsCategoryAsync.GetAsync"/>
		object Get(object @params);

		/// <inheritdoc cref="IPrettyCardsCategoryAsync.GetByIdAsync"/>
		object GetById(object @params);

		/// <inheritdoc cref="IPrettyCardsCategoryAsync.GetUploadUrlAsync"/>
		object GetUploadUrl(object @params);
	}
}