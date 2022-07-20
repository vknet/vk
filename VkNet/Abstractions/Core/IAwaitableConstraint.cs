using System;
using System.Threading;
using System.Threading.Tasks;

namespace VkNet.Abstractions.Core
{
	/// <summary>
	/// The <see cref="IAwaitableConstraint"/>.
	/// </summary>
	public interface IAwaitableConstraint
	{
		/// <summary>
		/// Starts a <see cref="Task"/> that will complete after readiness.
		/// </summary>
		Task<IDisposable> WaitForReadinessAsync(CancellationToken cancellationToken);

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
}