using System;

namespace VkNet.Model;

/// <summary>
/// ID группы
/// </summary>
/// <param name="Value"></param>
[Serializable]
public record GroupId(ulong? Value) : IGroupUpdate;