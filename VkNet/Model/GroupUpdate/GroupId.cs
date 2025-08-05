using System;

namespace VkNet.Model;

/// <summary>
/// ID группы
/// </summary>
/// <param name="Value">Значение</param>
[Serializable]
public record GroupId(ulong? Value) : IGroupUpdate;