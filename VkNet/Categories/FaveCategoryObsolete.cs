using System;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="IFaveCategory" />
public partial class FaveCategory
{
	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public VkCollection<User> GetUsers(int? count = null, int? offset = null)
	{
		VkErrors.ThrowIfNumberIsNegative(() => count);
		VkErrors.ThrowIfNumberIsNegative(() => offset);

		var parameters = new VkParameters
		{
			{
				"count", count
			},
			{
				"offset", offset
			}
		};

		return _vk.Call<VkCollection<User>>("fave.getUsers", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public VkCollection<Photo> GetPhotos(int? count = null, int? offset = null, bool? photoSizes = null)
	{
		VkErrors.ThrowIfNumberIsNegative(() => count);
		VkErrors.ThrowIfNumberIsNegative(() => offset);

		var parameters = new VkParameters
		{
			{
				"count", count
			},
			{
				"offset", offset
			},
			{
				"photo_sizes", photoSizes
			}
		};

		return _vk.Call<VkCollection<Photo>>("fave.getPhotos", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public WallGetObject GetPosts(int? count = null, int? offset = null, bool extended = false)
	{
		VkErrors.ThrowIfNumberIsNegative(() => count);
		VkErrors.ThrowIfNumberIsNegative(() => offset);

		var parameters = new VkParameters
		{
			{
				"count", count
			},
			{
				"offset", offset
			},
			{
				"extended", true
			}
		};

		return _vk.Call<WallGetObject>("fave.getPosts", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public FaveVideoEx GetVideos(int? count = null, int? offset = null, bool extended = false)
	{
		VkErrors.ThrowIfNumberIsNegative(() => count);
		VkErrors.ThrowIfNumberIsNegative(() => offset);

		var parameters = new VkParameters
		{
			{
				"count", count
			},
			{
				"offset", offset
			},
			{
				"extended", true
			}
		};

		return _vk.Call<FaveVideoEx>("fave.getVideos", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public VkCollection<ExternalLink> GetLinks(int? count = null, int? offset = null)
	{
		VkErrors.ThrowIfNumberIsNegative(() => count);
		VkErrors.ThrowIfNumberIsNegative(() => offset);

		var parameters = new VkParameters
		{
			{
				"count", count
			},
			{
				"offset", offset
			}
		};

		return _vk.Call<VkCollection<ExternalLink>>("fave.getLinks", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public bool AddUser(long userId)
	{
		var parameters = new VkParameters
		{
			{
				"user_id", userId
			}
		};

		return _vk.Call<bool>("fave.addUser", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public bool RemoveUser(long userId)
	{
		var parameters = new VkParameters
		{
			{
				"user_id", userId
			}
		};

		return _vk.Call<bool>("fave.removeUser", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public bool AddGroup(long groupId)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			}
		};

		return _vk.Call<bool>("fave.addGroup", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public bool RemoveGroup(long groupId)
	{
		var parameters = new VkParameters
		{
			{
				"group_id", groupId
			}
		};

		return _vk.Call<bool>("fave.removeGroup", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete + " Используйте вместо него bool AddLink(Uri link)")]
	public bool AddLink(Uri link, string text)
	{
		var parameters = new VkParameters
		{
			{
				"link", link
			},
			{
				"text", text
			}
		};

		return _vk.Call<bool>("fave.addLink", parameters);
	}

	/// <inheritdoc />
	[Obsolete(ObsoleteText.Obsolete)]
	public VkCollection<Market> GetMarketItems(ulong? count = null, ulong? offset = null, bool? extended = null)
	{
		var parameters = new VkParameters
		{
			{
				"count", count
			},
			{
				"offset", offset
			},
			{
				"extended", extended
			}
		};

		return _vk.Call<VkCollection<Market>>("fave.getMarketItems", parameters);
	}
}