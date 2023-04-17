using VkNet.Enums.StringEnums;
using VkNet.Model.Results.Asr;

namespace VkNet.Abstractions;

/// <inheritdoc cref="IAsrCategoryAsync"/>
public interface IAsrCategory : IAsrCategoryAsync
{
	/// <inheritdoc cref = "IAsrCategoryAsync.CheckStatusAsync"/>
	AudioRecordingTask CheckStatus(string taskId);

	/// <inheritdoc cref = "IAsrCategoryAsync.GetUploadUrlAsync"/>
	UploadUrlResult GetUploadUrl();

	/// <inheritdoc cref = "IAsrCategoryAsync.ProcessAsync"/>
	TaskIdResult Process(string audio, AsrProcessModel model);
}