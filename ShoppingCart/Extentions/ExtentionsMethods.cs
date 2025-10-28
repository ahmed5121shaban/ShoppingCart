using EventFeed;

namespace Extentions
{
    public static class ExtentionsMethods
    {
        public static long NextSequenceNumber(this List<Event> events)
          => events.Count == 0 ? 1 : events.Max(e => e.SequenceNumber) + 1;
    }
}
