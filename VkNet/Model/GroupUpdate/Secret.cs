using System;

namespace VkNet.Model.GroupUpdate;

/// <summary>
/// <c>Secret Key</c> для Callback
/// </summary>
/// <param name="Value"></param>
[Serializable]
public record Secret(string Value) : IGroupUpdate;