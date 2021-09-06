using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Sitecon.Feature.Navigation
{
    public static class Templates
    {
        public static class Header
        {
            public static class Fields
            {
                public static readonly ID Logo = new ID("{4E1A039B-E80C-41F4-A05A-B21C6249FD98}");
                public static readonly ID HomeLink = new ID("{6C6D496B-A562-4DBA-9B9A-4C970459C236}");
                public static readonly ID EventsRoot = new ID("{B90408A2-EF93-42F0-9531-5FE68956A64B}");
                public static readonly ID ScheduleLink = new ID("{A6663CCC-7D14-4F7F-A26B-69A41A370EB5}");
            }
        }

        public static class Footer
        {
            public static class Fields
            {
                public static readonly ID FooterTextLeft = new ID("{911C6C67-F72B-4ECE-8DEB-5683204CCCAF}");
                public static readonly ID FooterLinkLeft = new ID("{2AF92090-AACB-4D8C-AD61-61EB07CBB410}");
                public static readonly ID FooterLinkTextLeft = new ID("{39ACA2C8-CC87-4FCE-A3A4-888ED68AE4B2}");
                public static readonly ID FooterTextRight = new ID("{107C9AF2-7938-4289-A758-5B52F2CB94B9}");
                public static readonly ID FooterLinkRight = new ID("{15405AE3-C7B9-4A35-B0EE-9A1CC41F6F09}");
                public static readonly ID FooterLinkTextRight = new ID("{FB634D5C-7547-4A7A-9947-3D616D9B28E1}");
            }
        }
    }
}