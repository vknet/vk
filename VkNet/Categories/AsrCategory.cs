using VkNet.Abstractions;
using VkNet.Model.Results.Asr;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class AsrCategory : IAsrCategory
{
	/// <summary>
	/// API.
	/// </summary>
	private readonly IVkApiInvoke _vk;

	/// <summary>
	/// api vk.com
	/// </summary>
	/// <param name="vk"> API. </param>
	public AsrCategory(IVkApiInvoke vk) => _vk = vk;

	/// <inheritdoc />
	public AudioRecordingTask CheckStatus(string taskId) => _vk.Call<AudioRecordingTask>("asr.checkStatus",
		new()
		{
			{
				"task_id", taskId
			}
		});
}