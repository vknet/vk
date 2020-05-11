using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода LeadsForms.GetLead
	/// </summary>
	[Serializable]
	public class LeadFormsGetLeadResult
	{
		/// <summary>
		/// Leads.
		/// </summary>
		[JsonProperty("leads")]
		public ReadOnlyCollection<GetLeadResult> Leads { get; set; }
	}
}