using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
/// Результат метода account.changePassword
/// </summary>
[Serializable]
public class AccountChangePasswordResult
{
	/// <summary>
	/// Токен.
	/// </summary>
	[JsonProperty("token")]
	public string Token { get; set; }

	/// <summary>
	/// secret в случае, если токен был nohttps.
	/// </summary>
	[Obsolete(ObsoleteText.Obsolete)]
	[JsonProperty("secret")]
	public string Secret { get; set; }
}