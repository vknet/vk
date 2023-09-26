using Microsoft.Extensions.DependencyInjection;

namespace VkNet.Shared;

/// <summary>
/// Экземпляр API
/// </summary>
public class Api
{
	private static VkApi _instance;

	private Api()
	{
	}

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <param name="collection">Коллекция сервисов для регистрации в DI</param>
	/// <returns>
	/// Экземпляр API
	/// </returns>
	public static VkApi GetInstance(IServiceCollection collection)
	{
		return _instance ??= new VkApi(collection);
	}

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <returns>
	/// Экземпляр API
	/// </returns>
	public static VkApi GetInstance()
	{
		return _instance ??= new VkApi();
	}
}