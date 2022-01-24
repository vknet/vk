using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace VkNet.Model
{
	/// <summary>
	/// Результат метода leadForms.getLeads
	/// </summary>
	// TODO: правильное название этого объекта LeadFormsGetLeadsResult
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