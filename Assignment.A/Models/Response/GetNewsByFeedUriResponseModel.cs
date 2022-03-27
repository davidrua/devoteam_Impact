namespace Assignment.A.Models.Response
{
    using Assignment.A.Entities;
    using System.Collections.Generic;

    public class GetNewsByFeedUriResponseModel
    {
        #region Properties

        public IEnumerable<Feed> Feeds { get; set; }

        #endregion
    }
}