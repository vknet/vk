using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VkNet.Abstractions.Core;

namespace VkNet.Utils
{
	public class CountByIntervalAwaitableConstraint : IAwaitableConstraint
	{
		private readonly LimitedSizeStack<DateTime> _timeStamps;

		private int _count;

		private TimeSpan _timeSpan;
	#if NET40
		private readonly AsyncSemaphoreSlim _semaphore = new AsyncSemaphoreSlim(1);
	#else
		private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
	#endif

		private readonly object _sync = new object();

		public CountByIntervalAwaitableConstraint()
		{
			_count = 3;
			_timeSpan = TimeSpan.FromSeconds(1);
			_timeStamps = new LimitedSizeStack<DateTime>(_count);
		}

		public CountByIntervalAwaitableConstraint(int count, TimeSpan timeSpan)
		{
			if (count <= 0)
				throw new ArgumentException("count should be strictly positive", nameof(count));

			if (timeSpan.TotalMilliseconds <= 0)
				throw new ArgumentException("timeSpan should be strictly positive", nameof(timeSpan));

			_count = count;
			_timeSpan = timeSpan;
			_timeStamps = new LimitedSizeStack<DateTime>(_count);
		}

		public async Task WaitForReadiness(CancellationToken cancellationToken)
		{
			await _semaphore.WaitAsync(cancellationToken);
			var count = 0;
			var now = DateTime.Now;
			var target = now - _timeSpan;

			LinkedListNode<DateTime> element = _timeStamps.First,
				last = null;

			while (element != null && element.Value > target)
			{
				last = element;
				element = element.Next;
				count++;
			}

			if (count < _count)
			{
				OnEnded();

				return;
			}

			var timetoWait = last.Value.Add(_timeSpan) - now;

			try
			{
			#if NET40
				await TaskEx.Delay(timetoWait, cancellationToken);
			#else
				await Task.Delay(timetoWait, cancellationToken);
			#endif
			}
			catch (System.Exception)
			{
				OnEnded();

				throw;
			}

			OnEnded();
		}

		public void SetRate(int count, TimeSpan timeSpan)
		{
			lock (_sync)
			{
				_count = count;
				_timeSpan = timeSpan;
			}
		}

		private void OnEnded()
		{
			var now = DateTime.Now;
			_timeStamps.Push(now);
			_semaphore.Release();
		}
	}
}