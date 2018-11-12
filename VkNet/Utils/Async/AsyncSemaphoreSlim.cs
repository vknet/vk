using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class AsyncSemaphoreSlim
{
	private readonly Queue<TaskCompletionSource<bool>> _mWaiters = new Queue<TaskCompletionSource<bool>>();

	private int _mCurrentCount;

	public AsyncSemaphoreSlim(int initialCount)
	{
		if (initialCount < 0) throw new ArgumentOutOfRangeException("initialCount");

		_mCurrentCount = initialCount;
	}

	public Task WaitAsync(CancellationToken cancellationToken)
	{
		cancellationToken.ThrowIfCancellationRequested();

		lock (_mWaiters)
		{
			if (_mCurrentCount > 0)
			{
				--_mCurrentCount;
			#if NET40
				return TaskEx.FromResult(true);
			#else
				return Task.FromResult(true);
			#endif
			}

			var waiter = new TaskCompletionSource<bool>();
			_mWaiters.Enqueue(waiter);

			return waiter.Task;
		}
	}

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