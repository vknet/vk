using System;

namespace VkNet.Utils.JsonConverter
{
	/// <inheritdoc />
	public class IgnoreUnexpectedArraysConverter<T> : IgnoreUnexpectedArraysConverterBase
	{
		/// <inheritdoc />
		public override bool CanConvert(Type objectType)
		{
			return typeof(T).IsAssignableFrom(objectType);
		}
	}
}