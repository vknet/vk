using VkNet.Model;

namespace VkNet.Abstractions;

/// <summary>
/// Методы для работы со звонками
/// </summary>
public interface ICallsCategory : ICallsCategoryAsync
{
	/// <inheritdoc cref="ICallsCategoryAsync.ForceFinishAsync"/>
	bool ForceFinish(CallsForceFinishParams @params);

	/// <inheritdoc cref="ICallsCategoryAsync.StartAsync"/>
	CallStartResult Start(CallsStartParams @params);
}