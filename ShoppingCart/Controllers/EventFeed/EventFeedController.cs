using Contracts;
using EventFeed;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("Events")]
    [ApiController]
    public class EventFeedController : ControllerBase
    {
        private readonly IEventStore _eventStore;
        public EventFeedController(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }
        [HttpGet]
        public Event[] GetEvents([FromQuery] long start, [FromQuery] long end = long.MaxValue)
        => _eventStore.GetEvents(start,end).ToArray();
        
    }
}
