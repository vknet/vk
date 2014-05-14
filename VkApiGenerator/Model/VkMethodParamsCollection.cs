using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VkApiGenerator.Model
{
    public class VkMethodParamsCollection : ICollection<VkMethodParam>
    {
        private readonly IList<VkMethodParam> _list;

        public VkMethodParamsCollection()
        {
            _list = new List<VkMethodParam>();
        }

        public IEnumerator<VkMethodParam> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(VkMethodParam item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(VkMethodParam item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(VkMethodParam[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(VkMethodParam item)
        {
            return _list.Remove(item);
        }

        public VkMethodParam this[int i]
        {
            get { return _list[i]; }
            set { _list[i] = value; }
        }

        public int Count { get { return _list.Count; } }
        public bool IsReadOnly { get { return _list.IsReadOnly; } }

        public override string ToString()
        {
            if (_list.Count == 0) return string.Empty;

            var sb = new StringBuilder();
            for (int i = 0; i < _list.Count; i++)
            {
                sb.Append(_list[i]);

                if (i != _list.Count - 1)
                    sb.Append(", ");
            }

            return sb.ToString();
        }
    }
}