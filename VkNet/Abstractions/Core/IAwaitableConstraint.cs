using System;
using System.Threading;
using System.Threading.Tasks;

namespace VkNet.Abstractions.Core
{
	public interface IAwaitableConstraint
	{
		Task<IDisposable> WaitForReadiness(CancellationToken cancellationToken);

		void SetRate(int count, TimeSpan timeSpan);
	}
}