using System;

namespace VkNet.Model;
/// <summary>
/// Список параметров для метода calls.start
/// </summary>
[Serializable]
public class CallsStartParams
{
	/// <summary>
	/// Идентификатор сообщества
	/// </summary>
	public int? GroupId { get; set; }
}