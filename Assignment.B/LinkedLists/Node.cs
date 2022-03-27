namespace Assignment.B.LinkedLists
{
    public class LinkedListNode<TData>
    {
        #region Constructors

        public LinkedListNode(TData data, LinkedListNode<TData> next = null)
        {
            Data = data;
            Next = next;
        }

        #endregion Constructors

        #region Properties

        public TData Data { get; set; }

        public LinkedListNode<TData> Next { get; set; }

        #endregion Properties
    }
}