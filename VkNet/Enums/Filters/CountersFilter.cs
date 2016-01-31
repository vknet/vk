namespace VkNet.Enums.Filters
{
	/// <summary>
	/// ������� ���������
	/// </summary>
	public sealed class CountersFilter : MultivaluedFilter<CountersFilter>
	{
		/// <summary>
		/// ���������� ������ � ������
		/// </summary>
		public static readonly CountersFilter Friends = RegisterPossibleValue(1 << 0, "friends");
		/// <summary>
		/// ���������� ������������� ���������
		/// </summary>
		public static readonly CountersFilter Messages = RegisterPossibleValue(1 << 1, "messages");
		/// <summary>
		/// ���������� ����
		/// </summary>
		public static readonly CountersFilter Photos = RegisterPossibleValue(1 << 2, "photos");
		/// <summary>
		/// ���������� �����
		/// </summary>
		public static readonly CountersFilter Videos = RegisterPossibleValue(1 << 3, "videos");
		/// <summary>
		/// ���������� �������
		/// </summary>
		public static readonly CountersFilter Notes = RegisterPossibleValue(1 << 4, "notes");
		/// <summary>
		/// ���������� ��������
		/// </summary>
		public static readonly CountersFilter Gifts = RegisterPossibleValue(1 << 5, "gifts");
		/// <summary>
		/// ���������� �������
		/// </summary>
		public static readonly CountersFilter Events = RegisterPossibleValue(1 << 6, "events");
		/// <summary>
		/// ���������� �����
		/// </summary>
		public static readonly CountersFilter Groups = RegisterPossibleValue(1 << 7, "groups");
		/// <summary>
		/// ���������� �����������
		/// </summary>
		public static readonly CountersFilter Notifications = RegisterPossibleValue(1 << 8, "notifications");

		/// <summary>
		/// ��� �������
		/// </summary>
		public static readonly CountersFilter All = Friends | Messages | Photos | Videos
			| Notes | Gifts | Events | Groups | Notifications;

	}
}