#if NET40
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace VkNet.Utils
{
	/// <summary>
	/// Represents a lightweight alternative to <see cref="Semaphore"/> for .NET 4
	/// that limits the number of threads that can access a resource or pool of resources concurrently.
	/// </summary>
	internal class AsyncSemaphoreSlim
	{
		private readonly Queue<TaskCompletionSource<bool>> _mWaiters = new Queue<TaskCompletionSource<bool>>();

		private uint _mCurrentCount;

		/// <summary>
		/// Initializes a new instance of the <see cref="AsyncSemaphoreSlim"/> class,
		/// specifying the initial number of requests that can be granted concurrently.
		/// </summary>
		/// <param name="initialCount">
		/// The initial number of requests for the semaphore that can be granted concurrently.
		/// </param>
		public AsyncSemaphoreSlim(uint initialCount)
		{
			_mCurrentCount = initialCount;
		}

		/// <summary>
		/// Asynchronously waits to enter the SemaphoreSlim, while observing a CancellationToken.
		/// </summary>
		/// <param name="cancellationToken">
		/// The CancellationToken token to observe.
		/// </param>
		/// <returns>
		/// A task that will complete when the semaphore has been entered.
		/// </returns>
		public Task WaitAsync(CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();

			lock (_mWaiters)
			{
				if (_mCurrentCount > 0)
				{
					--_mCurrentCount;

					return TaskEx.FromResult(true);
				}

				var waiter = new TaskCompletionSource<bool>();
				_mWaiters.Enqueue(waiter);

				return waiter.Task;
			}
		}

		/// <summary>
		/// Releases the SemaphoreSlim object once.
		/// </summary>
		public void Release()
		{
			TaskCompletionSource<bool> toRelease = null;

			lock (_mWaiters)
			{
				if (_mWaiters.Count > 0)
					toRelease = _mWaiters.Dequeue();
				else
					++_mCurrentCount;
			}

			toRelease?.SetResult(true);
		}
	}
}
#endif