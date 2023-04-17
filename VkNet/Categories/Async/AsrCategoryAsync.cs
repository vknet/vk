using System.Threading;
using System.Threading.Tasks;
using VkNet.Model.Results.Asr;
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
}