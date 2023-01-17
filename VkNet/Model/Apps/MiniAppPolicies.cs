using System;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <summary>
/// Политика конфиденциальности приложения.
/// </summary>
[Serializable]
public class MiniAppPolicies
{
	/// <summary>
	/// Идентификатор приложения.
	/// </summary>
	[JsonProperty("privacy_policy")]
	public string PrivacyPolicy { get; set; }

	/// <summary>
	/// Название приложения.
	/// </summary>
	[JsonProperty("terms")]
	public string Terms { get; set; }
}