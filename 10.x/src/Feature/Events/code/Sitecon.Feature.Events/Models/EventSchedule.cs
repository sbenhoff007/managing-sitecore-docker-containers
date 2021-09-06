using System.Collections.Generic;

namespace Sitecon.Feature.Events.Models
{
    public class EventSchedule
    {
        public string EventScheduleBgImgUrl { get; set; }
        public List<Event> EventScheduleDay1Events { get; set; }
        public string EventScheduleDay2Date { get; set; }
        public List<Event> EventScheduleDay2Events { get; set; }
    }
}