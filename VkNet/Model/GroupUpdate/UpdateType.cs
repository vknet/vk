using System;
using VkNet.Enums.StringEnums;

namespace VkNet.Model;

/// <summary>
/// Тип обновления
/// </summary>
/// <param name="Value">Значение</param>
[Serializable]
public record UpdateType(GroupUpdateType? Value) : IGroupUpdate;
