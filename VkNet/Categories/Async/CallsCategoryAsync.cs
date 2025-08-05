using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions;
using VkNet.Model;
using VkNet.Utils;

namespace VkNet.Categories;

/// <inheritdoc cref="ICallsCategory" />
public partial class CallsCategory
{
	/// <inheritdoc />
	public Task<bool> ForceFinishAsync(CallsForceFinishParams @params, CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			ForceFinish(@params), token);

	/// <inheritdoc />
	public Task<CallStartResult> StartAsync(CallsStartParams @params, CancellationToken token = default) =>
		TypeHelper.TryInvokeMethodAsync(() =>
			Start(@params), token);
}