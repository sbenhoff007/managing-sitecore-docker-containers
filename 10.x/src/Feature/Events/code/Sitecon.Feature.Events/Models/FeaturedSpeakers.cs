using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecon.Feature.Events.Models
{
    public class FeaturedSpeakers
    {
        public Speaker FeaturedSpeaker { get; set; }
        public List<Speaker> FeaturedSpeakersList { get; set; }
    }
}