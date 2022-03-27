using System.Collections.Generic;

namespace Assignment.A.Entities
{
    public class Feed
    {
        #region Properties

        public string Title { get; set; }

        public string Desc { get; set; }

        public FeedImage Img { get; set; }

        public IEnumerable<FeedEntry> Entries { get; set; }

        public int AuthorsToday { get; set; }

        #endregion Properties
    }
}