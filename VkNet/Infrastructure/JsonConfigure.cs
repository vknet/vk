using Newtonsoft.Json;

namespace VkNet.Infrastructure
{
	public static class JsonConfigure
	{
		public static JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
		{
			MaxDepth = null,
			ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
		};
	}
}