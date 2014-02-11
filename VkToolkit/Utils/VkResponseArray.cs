namespace VkToolkit.Utils
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Newtonsoft.Json.Linq;

    internal sealed class VkResponseArray : IEnumerable<VkResponse>
    {
        private readonly JArray _array;

        public VkResponseArray(JArray array)
        {
            _array = array;
        }

        public VkResponse this[object key]
        {
            get
            {
                var token = _array[key];
                return new VkResponse(token);
            }
        }

        public int Count
        {
            get { return _array.Count; }
        }

        public IEnumerator<VkResponse> GetEnumerator()
        {
            return _array.Select(i => new VkResponse(i)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}