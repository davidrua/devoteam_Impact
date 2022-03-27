namespace Assignment.B.LinkedLists.Abstracts
{
    internal interface ILinkedList<TData>
    {
        #region Methods

        void AddFirst(TData data);

        void AddLast(TData data);

        void Clear();

        LinkedListNode<TData> Find(TData data);

        #endregion Methods
    }
}