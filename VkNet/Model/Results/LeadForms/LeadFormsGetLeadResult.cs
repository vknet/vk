using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model
{
	[Serializable]
	public class LeadFormsGetLeadResult
	{
		[JsonProperty("leads")]
		public ReadOnlyCollection<GetLeadResult> Leads { get; set; }
	}
}