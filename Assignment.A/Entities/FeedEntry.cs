namespace Assignment.A.Entities
{
    using System.Collections.Generic;

    public class FeedEntry
    {
        #region Properties

        public string Title { get; set; }

        public string Link { get; set; }

        public string PubDate { get; set; }

        public IEnumerable<string> Authors { get; set; }

        #endregion Properties
    }
}