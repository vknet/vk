using System.Collections;
using System.Collections.Generic;

namespace VkApiGenerator.Model
{
    public class VkMethodParamsCollection : ICollection<VkMethodParam>
    {
        private IList<VkMethodParam> _list;

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

        public int Count { get { return _list.Count; } }
        public bool IsReadOnly { get { return _list.IsReadOnly; } }
    }
}