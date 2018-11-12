using System;
using System.Threading;
using System.Threading.Tasks;

namespace VkNet.Abstractions.Core
{
	public interface IAwaitableConstraint
	{
		Task WaitForReadiness(CancellationToken cancellationToken);

		void SetRate(int count, TimeSpan timeSpan);
	}
}