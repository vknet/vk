namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Приложенный объект, имеющий идентификатор и владельца.
	/// </summary>
	public abstract class MediaAttachment
	{
		protected static string type;

		/// <summary>
		/// Идентификатор приложенного объекта.
		/// </summary>
		public long Id { get; set; }

		/// <summary>
		/// Идентификатор владельца приложенного объекта.
		/// </summary>
		public long? OwnerId { get; set; }

		public override string ToString()
		{
			return string.Format("{0}{1}_{2}", type, OwnerId, Id);
		}
	}
}