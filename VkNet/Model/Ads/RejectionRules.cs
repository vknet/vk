﻿using System;
using Newtonsoft.Json;
using VkNet.Utils;

namespace VkNet.Model;

/// <summary>
///
/// </summary>
[Serializable]
public class RejectionRules
{
	/// <summary>
	///
	/// </summary>
	[JsonProperty("title")]
	public string Title { get; set; }

	/// <summary>
	///
	/// </summary>
	[JsonProperty("paragraphs")]
	public string Paragraphs { get; set; }
}