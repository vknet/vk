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

        protected VkFilter(VkFilter f1, VkFilter f2)
        {
            Fields = new List<VkFilter>();

            if (f1.Fields != null && f1.Fields.Count != 0)
            {
                foreach (var f in f1.Fields)
                {
                    if (Fields.All(m => m.Value != f.Value))
                        Fields.Add(f);
                }
            }
            else
            {
                if (Fields.All(m => m.Value != f1.Value))
                    Fields.Add(f1);
            }

            if (f2.Fields != null && f2.Fields.Count != 0)
            {
                foreach (var f in f2.Fields)
                {
                    if (Fields.All(m => m.Value != f.Value))
                        Fields.Add(f);
                }
            }
            else
            {
                if (Fields.All(m => m.Value != f2.Value))
                    Fields.Add(f2);
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