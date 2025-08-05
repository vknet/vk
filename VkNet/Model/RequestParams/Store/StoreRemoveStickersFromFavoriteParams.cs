using System;
using System.Collections.Generic;

namespace VkNet.Model;

/// <summary>
/// Список параметров для метода store.removeStickersFromFavorite
/// </summary>
[Serializable]
public class StoreRemoveStickersFromFavoriteParams
{
	/// <summary>
	/// Идентификаторы стикеров
	/// </summary>
	public List<string> StickerIds { get; set; }
}