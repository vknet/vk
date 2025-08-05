using System;

namespace VkNet.Model;

/// <summary>
/// <c>Secret Key</c> для Callback
/// </summary>
/// <param name="Value">Значение</param>
[Serializable]
public record Secret(string Value) : IGroupUpdate;