using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Exception;

namespace VkNet.Infrastructure
{
	internal static class JsonConfigure
	{
		/// <returns></returns>
		internal static JsonSerializerSettings JsonSerializerSettings = new()
		{
			MaxDepth = null,
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
		};

		/// <returns></returns>
		internal static JObject ToJObject(this string answer)
		{
			try
			{
				using var stringReader = new StringReader(answer);

				using JsonReader jsonReader = new JsonTextReader(stringReader)
				{
					MaxDepth = null,
				};

				return JObject.Load(jsonReader);
			}
			catch (JsonReaderException ex)
			{
				throw new VkApiException("Wrong json data.", ex);
			}
		}
	}
}