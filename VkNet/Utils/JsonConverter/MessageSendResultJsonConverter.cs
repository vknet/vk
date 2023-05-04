using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VkNet.Model;

namespace VkNet.Utils.JsonConverter;

/// <inheritdoc />
public class MessagesSendResultJsonConverter : Newtonsoft.Json.JsonConverter
{
	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

	/// <inheritdoc />
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (objectType.IsGenericType)
		{
			throw new TypeAccessException();
		}

		if (reader.TokenType == JsonToken.Null)
		{
			return null;
		}

		var obj = JObject.Load(reader);
		var responseJToken = obj["response"] ?? obj;
		var response = new VkResponse(responseJToken);

		// В новых версиях изменился формат ответа, поддержка для других версий
		var res = new MessagesSendResult();

		if (response.ContainsKey("peer_id"))
		{
			res.PeerId = response[key: "peer_id"];
		}

		if (response.ContainsKey("message_id"))
		{
			res.MessageId = response[key: "message_id"];
		}

		if (response.ContainsKey("conversation_message_id"))
		{
			res.ConversationMessageId = response[key: "conversation_message_id"];
		}

		if (response.ContainsKey("error"))
		{
			var error = response[key: "error"];

			if (error.ContainsKey("code"))
			{
				res.ErrorCode = error[key: "code"];
				res.Error = error[key: "description"];
			} else
			{
				try
				{
					res.Error = response[key: "error"];
				}
				#pragma warning disable S2486 // Generic exceptions should not be ignored
				catch
				{
					// TODO: ensure no error or handle
				}
				#pragma warning restore S2486 // Generic exceptions should not be ignored
			}
		}

		return res;
	}

	/// <inheritdoc />
	public override bool CanConvert(Type objectType) => throw new NotImplementedException();
}