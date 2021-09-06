using Sitecon.Feature.Events.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecon.Feature.Events.Helpers
{
    public class EventHelpers
    {
        public List<Event> PopulateEventList(MultilistField eventListField)
        {
            Item[] eventItems = eventListField.GetItems();
            List<Event> eventList = new List<Event>();
            if (eventItems != null && eventItems.Count() > 0)
            {
                foreach (Item ev in eventItems)
                {
                    Event e = new Event();
                    Item eventItem = Sitecore.Context.Database.GetItem(ev.ID);
                    e.EventName = eventItem.Fields[Templates.Event.Fields.EventName.ToString()].Value;
                    CheckboxField isFeaturedEventField = eventItem.Fields[Templates.Event.Fields.IsFeaturedEvent];
                    e.IsFeaturedEvent = isFeaturedEventField.Checked;
                    DateField eventDateField = eventItem.Fields[Templates.Event.Fields.EventDate];
                    e.EventDate = eventDateField.DateTime.ToLocalTime();
                    e.EventDateString = eventDateField.DateTime.ToLocalTime().ToString("f");
                    e.EventTimeString = eventDateField.DateTime.ToLocalTime().ToString("t");

                    //TreelistEx
                    MultilistField eventSpeakersField = eventItem.Fields[Templates.Event.Fields.EventSpeakers];
                    Item[] eventSpeakerItems = eventSpeakersField.GetItems();
                    List<Speaker> eventSpeakerList = new List<Speaker>();
                    if (eventSpeakerItems != null && eventSpeakerItems.Count() > 0)
                    {
                        foreach (Item sp in eventSpeakerItems)
                        {
                            Speaker speaker = new Speaker();
                            Item speakerItem = Sitecore.Context.Database.GetItem(sp.ID);
                            speaker.SpeakerName = speakerItem.Fields[Templates.Speaker.Fields.SpeakerName.ToString()].Value;
                            ImageField speakerImage = speakerItem.Fields[Templates.Speaker.Fields.SpeakerImage];
                            speaker.SpeakerImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(speakerImage.MediaItem);
                            speaker.SpeakerImageAlt = speakerImage.Alt;

                            eventSpeakerList.Add(speaker);
                        }

                        e.EventSpeakers = eventSpeakerList;
                    }

                    eventList.Add(e);
                }
            }

            return eventList;
        }

        public Speaker GetFeaturedSpeaker(Item item)
        {
            Speaker featuredSpeaker = new Speaker();

            Item featuredSpeakerItem = Sitecore.Context.Database.GetItem(item.ID);
            if (featuredSpeakerItem != null)
            {
                LinkField featuredSpeakerTwitterLink = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerTwitterUrl];
                featuredSpeaker.SpeakerTwitterUrl = featuredSpeakerTwitterLink.Url;
                LinkField featuredSpeakerLinkedInLink = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerLinkedInUrl];
                featuredSpeaker.SpeakerLinkedInUrl = featuredSpeakerLinkedInLink.Url;
                LinkField featuredSpeakerWebsiteLink = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerWebsiteUrl];
                featuredSpeaker.SpeakerWebsiteUrl = featuredSpeakerWebsiteLink.Url;
            }

            return featuredSpeaker;
        }
    }
}
