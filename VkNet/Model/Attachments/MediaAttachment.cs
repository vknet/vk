using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VkNet.Model.Attachments
{
    /// <summary>
    /// ����������� ������, ������� ������������� � ���������.
    /// </summary>
    [Serializable]
    public abstract class MediaAttachment
	{
		/// <summary>
		/// ������� �����
		/// </summary>
		private static readonly IDictionary<Type, string> Types = new Dictionary<Type, string>();

		/// <summary>
		/// ������������� ������������ �������.
		/// </summary>
		public long? Id { get; set; }

		/// <summary>
		/// ������������� ��������� ������������ �������.
		/// </summary>
		public long? OwnerId { get; set; }

		/// <summary>
		/// �������� ������ � ������.
		/// </summary>
		public override string ToString()
		{
			return $"{MatchType(GetType())}{OwnerId}_{Id}";
		}

		/// <summary>
		/// ���������������� ���.
		/// </summary>
		/// <param name="type">��� ��������.</param>
		/// <param name="match">������������.</param>
		protected static void RegisterType(Type type, string match)
		{
			Types.Add(type, match);
		}

		/// <summary>
		/// ������������ ����.
		/// </summary>
		/// <param name="type">��� ��������.</param>
		/// <returns></returns>
		private static string MatchType(Type type)
		{
			return Types[type];
		}
	}
}