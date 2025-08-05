using VkNet.Abstractions;
using VkNet.Exception;
using VkNet.Model;

namespace VkNet.Categories;

/// <inheritdoc cref="ICallsCategory" />
public partial class CallsCategory : ICallsCategory
{
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// Инициализирует новый экземпляр класса <see cref="CallsCategory" />
	/// </summary>
	public CallsCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public bool ForceFinish(CallsForceFinishParams @params)
	{
		if (@params.CallId.Length is not 36)
		{
			throw new VkApiException(message: "Параметр call_id обязательный. Макс. длина = 36 Мин. длина = 36");
		}

		return _vk.Call<bool>("calls.forceFinish", new()
		{
			{
				"call_id", @params.CallId
			}
		});
	}

	/// <inheritdoc />
	public CallStartResult Start(CallsStartParams @params) =>
		_vk.Call<CallStartResult>("calls.start", new()
		{
			{
				"group_id", @params.GroupId
			}
		});
}