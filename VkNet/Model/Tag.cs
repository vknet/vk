using System;
using System.Diagnostics;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// ������� � �����������.
    /// </summary>
    [DebuggerDisplay("Id = {Id}, TaggedName = {TaggedName}")]
    [Serializable]
    public class Tag
    {
        /// <summary>
        /// ������������� �������.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// �������� �������.
        /// </summary>
        public string TaggedName { get; set; }

        /// <summary>
        /// ������������� ������������, �������� ������������� �������.
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// ������������� ������������, ���������� �������.
        /// </summary>
        public long? PlacerId { get; set; }

        /// <summary>
        /// ���� ���������� �������.
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// ������ �������: true - ��������������, false - �� ��������������.
        /// </summary>
        public bool? IsViewed { get; set; }

        /// <summary>
        /// ���������� ������������� �������, �� ������� ������� ������� (������� ����� ���� � ������ ������ ����) � ���������.
        /// </summary>
        public decimal? X { get; set; }

        /// <summary>
        /// ���������� ������������� �������, �� ������� ������� ������� (������� ����� ���� � ������ ������ ����) � ���������.
        /// </summary>
        public decimal? Y { get; set; }

        /// <summary>
        /// ���������� ������������� �������, �� ������� ������� ������� (������� ����� ���� � ������ ������ ����) � ���������.
        /// </summary>
        public decimal? X2 { get; set; }

        /// <summary>
        /// ���������� ������������� �������, �� ������� ������� ������� (������� ����� ���� � ������ ������ ����) � ���������.
        /// </summary>
        public decimal? Y2 { get; set; }

        #region ������

        /// <summary>
        /// ��������� �� json.
        /// </summary>
        /// <param name="response">����� �������.</param>
        /// <returns></returns>
        public static Tag FromJson(VkResponse response)
        {
            var result = new Tag
            {
                Id = response["tag_id"],
                TaggedName = response["tagged_name"],
                UserId = response["user_id"] ?? response["uid"],
                PlacerId = response["placer_id"],
                Date = response["tag_created"] ?? response["date"],
                IsViewed = response["viewed"],
                X = response["x"],
                Y = response["y"],
                X2 = response["x2"],
                Y2 = response["y2"]
            };

            return result;
        }

        #endregion
    }
}