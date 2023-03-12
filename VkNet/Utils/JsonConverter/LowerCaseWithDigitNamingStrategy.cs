using System.Linq;
using Newtonsoft.Json.Serialization;

namespace VkNet.Utils.JsonConverter;

/// <summary>
///
/// </summary>
public class LowerCaseWithDigitNamingStrategy : NamingStrategy
{
	/// <inheritdoc />
	protected override string ResolvePropertyName(string str)
	{
		return string.Concat(str.Select((x, i) => i > 0 && char.IsDigit(x) ? "_" + x : x.ToString())).ToLower();
	}
}