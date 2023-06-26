using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model;

/// <inheritdoc />
[Serializable]
public class PrettyCards : MediaAttachment
{
	/// <inheritdoc />
	protected override string Alias => "pretty_cards";

	/// <summary>
	/// Cards
	/// </summary>
	[JsonProperty("cards")]
	public ReadOnlyCollection<PrettyCard> Cards { get; set; }
}