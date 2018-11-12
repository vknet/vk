using System.Collections.Generic;

namespace VkNet.Utils
{
	internal class LimitedSizeStack<T> : LinkedList<T>
	{
		private readonly int _maxSize;

		public LimitedSizeStack(int maxSize)
		{
			_maxSize = maxSize;
		}

		public void Push(T item)
		{
			AddFirst(item);

			if (Count > _maxSize)
				RemoveLast();
		}
	}
}