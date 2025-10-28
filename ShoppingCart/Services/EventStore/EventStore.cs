using Contracts;
using EventFeed;
using Extentions;
namespace Services
{
    public class EventStore : IEventStore
    {
        private List<Event> database = new();
        public EventStore()
        {
            
        }
        public IEnumerable<Event> GetEvents(long firstEventSequenceNumber, long lastEventSequenceNumber)
        => database.Where(e => 
            e.SequenceNumber >= firstEventSequenceNumber &&
            e.SequenceNumber <= lastEventSequenceNumber
        ).OrderBy(e => e.SequenceNumber);

        public void Raise(string eventName, object content)
        {
            var seqNumber = database.NextSequenceNumber();
            database.Add(new Event(seqNumber,DateTimeOffset.UtcNow,eventName,content));
        }
        
    }
}
