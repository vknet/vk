﻿using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы с поиском.
	/// </summary>
	public interface ISearchCategory : ISearchCategoryAsync
	{
		/// <summary>
		/// Метод позволяет получить результаты быстрого поиска по произвольной подстроке
		/// </summary>
		/// <param name="params"> Параметры запроса </param>
		/// <returns>
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте https://vk.com/dev/search.getHints
		/// </remarks>
		VkCollection<SearchHintsItem> GetHints(SearchGetHintsParams @params);
	}
}