using Microsoft.Extensions.DependencyInjection;

namespace VkNet.Shared
{
	/// <summary>
	///
	/// </summary>
	public class Api
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static VkApi _instance;

		/// <summary>
		/// Prevents a default instance of the <see cref="Api"/> class from being created.
		/// </summary>
		private Api()
		{}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <returns></returns>
		public static VkApi GetInstance(IServiceCollection collection)
		{
			return _instance ??= new VkApi(collection);
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <returns></returns>
		public static VkApi GetInstance()
		{
			return _instance ??= new VkApi();
		}
	}
}