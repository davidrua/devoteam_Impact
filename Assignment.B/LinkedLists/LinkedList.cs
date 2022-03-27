namespace Assignment.B.LinkedLists
{
    using Assignment.B.LinkedLists.Abstracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<TData> : ILinkedList<TData>, IEnumerable<TData>
    {
        #region Fields

        private LinkedListNode<TData> _head;

        #endregion Fields

        #region Constructors

        public LinkedList()
        {
            _head = null;
            Count = 0;
        }

        #endregion Constructors

        #region ILinkedList implementations

        public void AddFirst(TData data)
        {
            _head = new LinkedListNode<TData>(data, _head);
            Count = CountNodes();
        }

        public void AddLast(TData data)
        {
            var newNode = new LinkedListNode<TData>(data);
            if (_head is null)
            {
                _head = newNode;
                Count = CountNodes();
                return;
            }
            var lastNode = GetLastNode();
            lastNode.Next = newNode;
            Count = CountNodes();
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        public LinkedListNode<TData> Find(TData data)
        {
            var node = _head;
            while (node is not null)
            {
                if ((node.Data is null && data is null) || node.Data.Equals(data))
                {
                    return node;
                }
                node = node.Next;
            }
            return null;
        }

        #endregion ILinkedList implementations

        #region IEnumerable implementations

        public IEnumerator<TData> GetEnumerator()
        {
            var node = _head;
            while (node is not null)
            {
                var data = node.Data;
                node = node.Next;
                yield return data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion IEnumerable implementations

        #region Operators Overload

        public TData this[int index]
        {
            get => GetValue(index);
            set => SetValue(index, value);
        }

        #endregion Operators Overload

        #region Properties

        public int Count { get; private set; }

        #endregion Properties

        #region Private Methods

        private int CountNodes()
        {
            int count = 0;
            var node = _head;
            while (node is not null)
            {
                ++count;
                node = node.Next;
            }
            return count;
        }

        private LinkedListNode<TData> GetLastNode()
        {
            var node = _head;
            while (node?.Next is not null)
            {
                node = node.Next;
            }
            return node;
        }

        private TData GetValue(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(paramName: nameof(index), actualValue: index, string.Empty);
            }
            int count = 0;
            var node = _head;
            while (node?.Next is not null && count < index)
            {
                ++count;
                node = node.Next;
            }
            return node.Data;
        }

        private void SetValue(int index, TData data)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(paramName: nameof(index), actualValue: index, string.Empty);
            }
            int count = 0;
            var node = _head;
            while (node?.Next is not null && count < index)
            {
                node = node.Next;
            }
            node.Data = data;
        }

        #endregion Private Methods
    }
}