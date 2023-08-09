using System;
using System.Collections.Generic;
using System.Linq;

namespace Oriflame.PolicyBuilder.Xml.Collections
{
    /// <summary>
    /// Priority queue which grants the items with same priority a FIFO order.
    /// </summary>
    public class StalePriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
    {
        private readonly SortedDictionary<TPriority, Queue<TElement>> _data = new SortedDictionary<TPriority, Queue<TElement>>();

        public void Enqueue(TElement item, TPriority priority)
        {
            Queue<TElement> q;
            if (!_data.TryGetValue(priority, out q))
            {
                q = new Queue<TElement>();
                _data.Add(priority, q);
            }
            q.Enqueue(item);
        }

        public TElement Dequeue()
        {
            // will throw if there isn’t any first element!
            var pair = _data.First();
            var v = pair.Value.Dequeue();
            if (pair.Value.Count == 0) // nothing left of the top priority.
                _data.Remove(pair.Key);
            return v;
        }

        public bool IsEmpty
        {
            get { return _data.Count == 0; }
        }
    }
}
