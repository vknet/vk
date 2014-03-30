using System.Collections.Generic;
using System.Linq;

namespace VkNet.Utils
{
    public abstract class VkFilter
    {
        /// <summary>
        /// Строковое значение фильтра.
        /// </summary>
        protected readonly string Name;

        /// <summary>
        /// Числовое значение фильтра.
        /// </summary>
        protected readonly int Value;

        /// <summary>
        /// Выбранные фильтры.
        /// </summary>
        protected readonly IList<VkFilter> Fields;

        protected VkFilter(int value, string name)
        {
            Name = name;
            Value = value;
        }

        protected VkFilter(VkFilter left, VkFilter right)
        {
            Fields = new List<VkFilter>();

            if (left.Fields != null && left.Fields.Count != 0)
            {
                foreach (var f in left.Fields)
                {
                    if (Fields.All(m => m.Value != f.Value))
                        Fields.Add(f);
                }
            }
            else
            {
                if (Fields.All(m => m.Value != left.Value))
                    Fields.Add(left);
            }

            if (right.Fields != null && right.Fields.Count != 0)
            {
                foreach (var f in right.Fields)
                {
                    if (Fields.All(m => m.Value != f.Value))
                        Fields.Add(f);
                }
            }
            else
            {
                if (Fields.All(m => m.Value != right.Value))
                    Fields.Add(right);
            }
        }

        public override string ToString()
        {
            if (Fields == null || Fields.Count == 0)
                return Name;

            return Fields.Select(f => f.Name).JoinNonEmpty();
        }
    }
}