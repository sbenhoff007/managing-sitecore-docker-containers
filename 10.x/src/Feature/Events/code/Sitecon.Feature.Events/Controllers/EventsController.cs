using Sitecon.Feature.Events.Models;
using Sitecon.Feature.Events.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Data.Fields;
using Sitecore.Mvc.Presentation;
using Sitecore.Diagnostics;

namespace Sitecon.Feature.Events.Controllers
{
    public class EventsController : Controller
    {
        public ActionResult FeaturedSpeakers()
        {
            if (Sitecore.Context.Item == null)
            {
                return null;
            }

            var dataSourceId = Sitecore.Context.Item.ID.ToString();
            Assert.IsNotNullOrEmpty(dataSourceId, "dataSourceId is null or empty");
            var item = Sitecore.Context.Database.GetItem(dataSourceId);
            if (item == null)
            {
                return null;
            }

            FeaturedSpeakers featuredSpeakers = new FeaturedSpeakers();

            //Featured Speaker - DropTree Field
            ReferenceField featuredSpeakerField = item.Fields[Templates.FeaturedSpeaker.Fields.FeaturedSpeaker];
            Item featuredSpeakerItem = Sitecore.Context.Database.GetItem(featuredSpeakerField.TargetID);
            if (featuredSpeakerItem != null)
            {
                Speaker featuredSpeaker = new Speaker();
                featuredSpeaker.SpeakerName = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerName.ToString()].Value;
                featuredSpeaker.SpeakerTitle = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerTitle.ToString()].Value;
                featuredSpeaker.SpeakerDescription = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerDescription.ToString()].Value;
                LinkField featuredSpeakerTwitterLink = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerTwitterUrl];
                featuredSpeaker.SpeakerTwitterUrl = featuredSpeakerTwitterLink.Url;
                LinkField featuredSpeakerLinkedInLink = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerLinkedInUrl];
                featuredSpeaker.SpeakerLinkedInUrl = featuredSpeakerLinkedInLink.Url;
                LinkField featuredSpeakerWebsiteLink = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerWebsiteUrl];
                featuredSpeaker.SpeakerWebsiteUrl = featuredSpeakerWebsiteLink.Url;
                featuredSpeakers.FeaturedSpeaker = featuredSpeaker;
                ImageField featuredSpeakerImage = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerImage];
                featuredSpeaker.SpeakerImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(featuredSpeakerImage.MediaItem);
                featuredSpeaker.SpeakerImageAlt = featuredSpeakerImage.Alt;
            }

            //Featured Speakers List - TreeList Field
            MultilistField featuredSpeakersListField = item.Fields[Templates.FeaturedSpeaker.Fields.FeaturedSpeakersList];
            Item[] featuredSpeakerItems = featuredSpeakersListField.GetItems();
            List<Speaker> featuredSpeakersList = new List<Speaker>();
            if (featuredSpeakerItems != null && featuredSpeakerItems.Count() > 0)
            {
                foreach (Item i in featuredSpeakerItems)
                {
                    Speaker speaker = new Speaker();
                    Item speakerItem = Sitecore.Context.Database.GetItem(i.ID);
                    speaker.SpeakerName = speakerItem.Fields[Templates.Speaker.Fields.SpeakerName.ToString()].Value;
                    speaker.SpeakerTitle = speakerItem.Fields[Templates.Speaker.Fields.SpeakerTitle.ToString()].Value;
                    speaker.SpeakerDescription = speakerItem.Fields[Templates.Speaker.Fields.SpeakerDescription.ToString()].Value;
                    LinkField speakerTwitterLink = speakerItem.Fields[Templates.Speaker.Fields.SpeakerTwitterUrl];
                    speaker.SpeakerTwitterUrl = speakerTwitterLink.Url;
                    LinkField speakerLinkedInLink = speakerItem.Fields[Templates.Speaker.Fields.SpeakerLinkedInUrl];
                    speaker.SpeakerLinkedInUrl = speakerLinkedInLink.Url;
                    LinkField speakerWebsiteLink = speakerItem.Fields[Templates.Speaker.Fields.SpeakerWebsiteUrl];
                    speaker.SpeakerWebsiteUrl = speakerWebsiteLink.Url;
                    ImageField speakerImage = speakerItem.Fields[Templates.Speaker.Fields.SpeakerImage];
                    speaker.SpeakerImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(speakerImage.MediaItem);
                    speaker.SpeakerImageAlt = speakerImage.Alt;

                    featuredSpeakersList.Add(speaker);
                }
            }

            featuredSpeakers.FeaturedSpeakersList = featuredSpeakersList;

            return View(featuredSpeakers);
        }

        /// <summary>
        /// No longer used, turned into a View Rendering
        /// </summary>
        /// <returns></returns>
        //public ActionResult FeaturedSpeakersRepeaterPattern()
        //{
        //  if (Sitecore.Context.Item == null)
        //  {
        //    return null;
        //  }

        //  var dataSourceId = Sitecore.Context.Item.ID.ToString();
        //  Assert.IsNotNullOrEmpty(dataSourceId, "dataSourceId is null or empty");
        //  var item = Sitecore.Context.Database.GetItem(dataSourceId);
        //  if (item == null)
        //  {
        //    return null;
        //  }

        //  FeaturedSpeakers featuredSpeakers = new FeaturedSpeakers();

        //  //Featured Speaker - DropTree Field
        //  ReferenceField featuredSpeakerField = item.Fields[Templates.FeaturedSpeaker.Fields.FeaturedSpeaker];
        //  Item featuredSpeakerItem = Sitecore.Context.Database.GetItem(featuredSpeakerField.TargetID);
        //  if (featuredSpeakerItem != null)
        //  {
        //    Speaker featuredSpeaker = new Speaker();
        //    featuredSpeaker.SpeakerName = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerName.ToString()].Value;
        //    featuredSpeaker.SpeakerTitle = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerTitle.ToString()].Value;
        //    featuredSpeaker.SpeakerDescription = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerDescription.ToString()].Value;
        //    LinkField featuredSpeakerTwitterLink = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerTwitterUrl];
        //    featuredSpeaker.SpeakerTwitterUrl = featuredSpeakerTwitterLink.Url;
        //    LinkField featuredSpeakerLinkedInLink = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerLinkedInUrl];
        //    featuredSpeaker.SpeakerLinkedInUrl = featuredSpeakerLinkedInLink.Url;
        //    LinkField featuredSpeakerWebsiteLink = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerWebsiteUrl];
        //    featuredSpeaker.SpeakerWebsiteUrl = featuredSpeakerWebsiteLink.Url;
        //    featuredSpeakers.FeaturedSpeaker = featuredSpeaker;
        //    ImageField featuredSpeakerImage = featuredSpeakerItem.Fields[Templates.Speaker.Fields.SpeakerImage];
        //    featuredSpeaker.SpeakerImageUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(featuredSpeakerImage.MediaItem);
        //    featuredSpeaker.SpeakerImageAlt = featuredSpeakerImage.Alt;
        //  }

        //  return View(featuredSpeakers);
        //}

        public ActionResult FeaturedSpeakerRepeaterPattern()
        {
            if (Sitecore.Context.Item == null)
            {
                return null;
            }

            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var item = !string.IsNullOrEmpty(dataSourceId)
                ? Sitecore.Context.Database.GetItem(dataSourceId)
                : Sitecore.Context.Item;

            EventHelpers helpers = new EventHelpers();

            Speaker featuredSpeaker = helpers.GetFeaturedSpeaker(item);

            return View(featuredSpeaker);
        }

        public ActionResult FeaturedSpeakerMainRepeaterPattern()
        {
            if (Sitecore.Context.Item == null)
            {
                return null;
            }

            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var item = !string.IsNullOrEmpty(dataSourceId)
                ? Sitecore.Context.Database.GetItem(dataSourceId)
                : Sitecore.Context.Item;

            EventHelpers helpers = new EventHelpers();

            Speaker featuredSpeaker = helpers.GetFeaturedSpeaker(item);

            return View(featuredSpeaker);
        }

        public ActionResult FeaturedSpeakersSidebar()
        {
            if (Sitecore.Context.Item == null)
            {
                return null;
            }

            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var item = !string.IsNullOrEmpty(dataSourceId)
                ? Sitecore.Context.Database.GetItem(dataSourceId)
                : Sitecore.Context.Item;

            Event e = new Event();

            //TreeList
            MultilistField featuredSpeakersListField = item.Fields[Templates.Event.Fields.EventSpeakers];
            Item[] featuredSpeakerItems = featuredSpeakersListField.GetItems();
            List<Speaker> featuredSpeakersList = new List<Speaker>();
            if (featuredSpeakerItems != null && featuredSpeakerItems.Count() > 0)
            {
                foreach (Item i in featuredSpeakerItems)
                {
                    Speaker speaker = new Speaker();
                    Item speakerItem = Sitecore.Context.Database.GetItem(i.ID);
                    speaker.SpeakerName = speakerItem.Fields[Templates.Speaker.Fields.SpeakerName].Value;
                    speaker.SpeakerTitle = speakerItem.Fields[Templates.Speaker.Fields.SpeakerTitle].Value;
                    speaker.SpeakerDescription = speakerItem.Fields[Templates.Speaker.Fields.SpeakerDescription].Value;
                    LinkField speakerTwitterLink = speakerItem.Fields[Templates.Speaker.Fields.SpeakerTwitterUrl];
                    speaker.SpeakerTwitterUrl = speakerTwitterLink.Url;
                    LinkField speakerLinkedInLink = speakerItem.Fields[Templates.Speaker.Fields.SpeakerLinkedInUrl];
                    speaker.SpeakerLinkedInUrl = speakerLinkedInLink.Url;
                    LinkField speakerWebsiteLink = speakerItem.Fields[Templates.Speaker.Fields.SpeakerWebsiteUrl];
                    speaker.SpeakerWebsiteUrl = speakerWebsiteLink.Url;
                    ImageField speakerImage = speakerItem.Fields[Templates.Speaker.Fields.SpeakerImage];
                    speaker.SpeakerImageUrl = speakerImage.MediaItem != null ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(speakerImage.MediaItem) : string.Empty;
                    speaker.SpeakerImageAlt = speakerImage.MediaItem != null ? speakerImage.Alt : string.Empty;

                    featuredSpeakersList.Add(speaker);
                }
            }

            e.EventSpeakers = featuredSpeakersList;

            return View(e);
        }

        public ActionResult EventSchedule()
        {
            if (Sitecore.Context.Item == null)
            {
                return null;
            }

            var dataSourceId = Sitecore.Context.Item.ID.ToString();
            Assert.IsNotNullOrEmpty(dataSourceId, "dataSourceId is null or empty");
            var item = Sitecore.Context.Database.GetItem(dataSourceId);
            if (item == null)
            {
                return null;
            }

            EventSchedule eventSchedule = new EventSchedule();

            //Background Image
            ImageField eventScheduleBackgroundImageField = item.Fields[Templates.EventSchedule.Fields.EventScheduleBackground];
            eventSchedule.EventScheduleBgImgUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(eventScheduleBackgroundImageField.MediaItem);

            EventHelpers helpers = new EventHelpers();

            //Multilist
            MultilistField day1EventsListField = item.Fields[Templates.EventSchedule.Fields.EventScheduleDay1Events];
            eventSchedule.EventScheduleDay1Events = helpers.PopulateEventList(day1EventsListField);

            //Date Field
            DateField day2DateField = item.Fields[Templates.EventSchedule.Fields.EventScheduleDay2Date];
            DateTime day2DateTime = day2DateField.DateTime;
            eventSchedule.EventScheduleDay2Date = day2DateTime.ToString("MMMM dd");

            //Multilist
            MultilistField day2EventsListField = item.Fields[Templates.EventSchedule.Fields.EventScheduleDay2Events];
            eventSchedule.EventScheduleDay2Events = helpers.PopulateEventList(day2EventsListField);

            return View(eventSchedule);
        }
    }
}