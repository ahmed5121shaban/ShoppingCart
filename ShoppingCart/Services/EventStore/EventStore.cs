using Contracts;
using EventFeed;

namespace Services
{
    public class EventStore : IEventStore
    {
        public IEnumerable<Event> GetEvents(long firstEventSequenceNumber, long lastEventSequenceNumber)
        => database.Where(e =>
            e.SequenceNumber >= firstEventSequenceNumber && e.SequenceNumber <= lastEventSequenceNumber
            ).OrderBy(e => e.SequenceNumber);

        public void Raise(string eventName, object content)
        {
            var seqNumber = database.NextSequenceNumber();
            database.Add(new Event(seqNumber,DateTimeOffset.UtcNow,eventName,content));
        }
    }
}
