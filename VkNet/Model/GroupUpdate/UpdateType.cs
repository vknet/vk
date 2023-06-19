using System;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
///
/// </summary>
/// <param name="Value"></param>
[Serializable]
public record UpdateType(GroupUpdateType Value) : IGroupUpdate;
