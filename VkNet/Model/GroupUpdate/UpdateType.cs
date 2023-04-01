using System;
using VkNet.Enums.SafetyEnums;

namespace VkNet.Model.GroupUpdate;

/// <summary>
///
/// </summary>
/// <param name="Value"></param>
[Serializable]
public record UpdateType(GroupUpdateType Value) : IGroupUpdate;
