using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MusicNoteHelper
{
    public class CircularCollection<T> : IEnumerable<T>
    {
        private readonly IReadOnlyCollection<Node<T>> _items;

        private CircularCollection(IList<T> items)
        {
            var first = new Node<T>(items.First());
            var last = new Node<T>(items.Last());
            var nodes = new Node<T>[items.Count];
            first.Prev = last;
            last.Next = first;
            for(var i = 0; i < items.Count; i++)
            {
                var node = new Node<T>(items[i]);
                nodes[i] = node;
                if(i != 0)
                {
                    node.Prev = nodes[i - 1];
                    nodes[i - 1].Next = node;
                }
            }
            _items = new ReadOnlyCollection<Node<T>>(nodes);
        }

        public static CircularCollection<T> FromCollection(IList<T> collection)
        {
            return new CircularCollection<T>(collection);
        }

        public int Count => _items.Count;

        public T Next()
        {
            throw new NotImplementedException();    
        }

        public T Prev()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    internal sealed class Node<T>
    {
        public T Value { get; }

        public Node<T> Next { get; internal set; }

        public Node<T> Prev { get; internal set; }

        internal Node(T item)
        {
            this.Value = item;
        }
    }
}
