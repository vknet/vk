using System;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Result of Utils.CheckLink
/// </summary>
[Serializable]
public class CheckLinkResult
{
	/// <summary>
	/// Status
	/// </summary>
	public LinkAccessType? Status { get; set; }
}