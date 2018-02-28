using System;
using VkNet.Utils;

namespace VkNet.Model
{
    /// <summary>
    /// ����� � �����
    /// </summary>
    [Serializable]
    public class SchoolClass
    {
        /// <summary>
        /// ����� �������������, ������� ����������� ������.
        /// </summary>
        public long Class { get; set; }

        /// <summary>
        /// ������� ����������� �� ������ �������� ������������.
        /// </summary>
        public string Text { get; set; }

        #region ������
        /// <summary>
        /// ��������� �� json.
        /// </summary>
        /// <param name="response">����� �������.</param>
        /// <returns></returns>
        public static SchoolClass FromJson(VkResponse response)
        {
            var schoolClass = new SchoolClass
            {
                Class = response[0],
                Text = response[1]
            };

            return schoolClass;
        }

        #endregion
    }
}