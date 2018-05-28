using VkNet.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VkNet.Enums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model.Attachments;

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
	}
}