namespace Assignment.A.Controllers
{
    using Assignment.A.Entities;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.ServiceModel.Syndication;
    using System.Threading.Tasks;
    using System.Xml;

    [ApiController]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("services/news/api/v{version:apiVersion}/[controller]")]
    public class NewsController : ControllerBase
    {
        #region Fields

        private readonly IMapper _mapper;

        #endregion Fields

        #region MyRegion

        public NewsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion MyRegion

        /// <summary>
        /// Get news
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     get news
        ///     {
        ///     }
        ///
        /// </remarks>
        /// <param name="feedUri">string</param>
        [HttpGet("")]
        [ProducesResponseType((int)System.Net.HttpStatusCode.OK)]
        [ProducesResponseType((int)System.Net.HttpStatusCode.OK, Type = typeof(IEnumerable<Feed>))]
        public async Task<IActionResult> GetNewsByFeedUri([FromQuery] string feedUri)
        {
            using var reader = XmlReader.Create(feedUri);
            var feed = SyndicationFeed.Load(reader);
            return Ok(_mapper.Map<Feed>(feed));
        }
    }
}