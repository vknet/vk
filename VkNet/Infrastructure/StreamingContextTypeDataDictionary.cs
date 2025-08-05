using System;
using System.Collections.Generic;

namespace VkNet.Infrastructure;

/// <inheritdoc cref="IStreamingContextTypeDataDictionary" />
internal class StreamingContextTypeDataDictionary : IStreamingContextTypeDataDictionary
{
	private readonly Dictionary<Type, object> _dictionary = new ();

	/// <inheritdoc />
	public void AddData(Type type, object data) => _dictionary.Add(type, data);

	/// <inheritdoc />
	public bool TryGetData(Type type, out object data) => _dictionary.TryGetValue(type, out data);
}