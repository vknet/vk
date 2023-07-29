using System;
using System.Threading;
using System.Threading.Tasks;

namespace VkNet.Abstractions.Core;

/// <summary>
/// The <see cref="IRateLimiter"/>.
/// </summary>
public interface IRateLimiter
{
	/// <summary>
	/// Runs a <see cref="Task"/> with a constraint.
	/// </summary>
	/// <param name="perform">
	/// Func to perform.
	/// </param>
	/// <param name="cancellationToken">
	/// Propagates notification that operations should be canceled.
	/// </param>
	Task Perform(Func<Task> perform, CancellationToken cancellationToken);

	/// <summary>
	/// Runs a <see cref="Task"/> with a constraint.
	/// </summary>
	/// <param name="perform">
	/// Func to perform.
	/// </param>
	/// <param name="cancellationToken">
	/// Propagates notification that operations should be canceled.
	/// </param>
	/// <typeparam name="T">
	/// The type of the <see cref="Task"/> item.
	/// </typeparam>
	/// <returns>
	/// The <see cref="Task"/>
	/// </returns>
	Task<T> Perform<T>(Func<Task<T>> perform, CancellationToken cancellationToken);

	/// <summary>
	/// Runs a <see cref="Task"/> with a constraint.
	/// </summary>
	/// <param name="perform">
	/// Action> to perform.
	/// </param>
	/// <param name="cancellationToken">
	/// Propagates notification that operations should be canceled.
	/// </param>
	Task Perform(Action perform, CancellationToken cancellationToken);

	/// <summary>
	/// Runs a <see cref="Task"/> with a constraint.
	/// </summary>
	/// <param name="perform">
	/// Func to perform.
	/// </param>
	/// <param name="cancellationToken">
	/// Propagates notification that operations should be canceled.
	/// </param>
	/// <typeparam name="T">
	/// The type of the func item.
	/// </typeparam>
	/// <returns>
	/// The <see cref="Task"/>
	/// </returns>
	Task<T> Perform<T>(Func<T> perform, CancellationToken cancellationToken);

	/// <summary>
	/// Sets a rate for a constraint.
	/// </summary>
	/// <param name="number">
	/// Maximum <paramref name="number"/> times per <paramref name="timeSpan"/>.
	/// </param>
	/// <param name="timeSpan">
	/// Time interval.
	/// </param>
	void SetRate(int number, TimeSpan timeSpan);
}