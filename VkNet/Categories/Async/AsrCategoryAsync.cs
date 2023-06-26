using System.Threading;
using System.Threading.Tasks;
using VkNet.Enums.StringEnums;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc />
public partial class AsrCategory
{
	/// <inheritdoc />
	public Task<AudioRecordingTask> CheckStatusAsync(string taskId,
								CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			CheckStatus(taskId), token);

	/// <inheritdoc />
	public Task<AsrUploadUrlResult> GetUploadUrlAsync(CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(GetUploadUrl, token);

	/// <inheritdoc />
	public Task<TaskIdResult> ProcessAsync(string audio, AsrProcessModel model, CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Process(audio, model), token);

}