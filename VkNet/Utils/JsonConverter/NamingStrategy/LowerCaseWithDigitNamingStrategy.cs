using System.Linq;
using Newtonsoft.Json.Serialization;

namespace VkNet.Utils.JsonConverter;

/// <summary>
///
/// </summary>
public class LowerCaseWithDigitNamingStrategy : NamingStrategy
{
	/// <inheritdoc />
	protected override string ResolvePropertyName(string name)
	{
		return string.Concat(name.Select((x, i) => i > 0 && char.IsDigit(x) ? "_" + x : x.ToString())).ToLower();
	}
}