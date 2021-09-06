using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Sitecon.Feature.Homepage
{
    public static class Templates
    {
        public static class HomepageTwoColumnCTA
        {
            public static class Fields
            {
                public static readonly ID Column1Title = new ID("{D41B65C8-8BB0-4617-945F-FACC66A83A20}");
                public static readonly ID Column1Text = new ID("{A1F6E265-E0CE-4A44-BC9D-FCC2CBF19E79}");
                public static readonly ID Column1Link = new ID("{FD5783B4-F6C6-47A6-AA30-45D7936DCC98}");
                public static readonly ID Column1Image = new ID("{D3FCB1FA-A933-4EFE-B1AC-5F81AAD24FB6}");
                public static readonly ID Column2Title = new ID("{D46C5EBF-F005-4416-8157-49C1947BB026}");
                public static readonly ID Column2Text = new ID("{3A4EACDC-D115-4F22-8E4C-C2B3EB331C9B}");
                public static readonly ID Column2Link = new ID("{31D7D3D7-E912-49D1-B733-8F7DB4EF4865}");
                public static readonly ID Column2Image = new ID("{9912A396-CA66-497F-8B2D-6E2BF60F8BEA}");
            }
        }

        public static class HomepageCTA
        {
            public static class Fields
            {
                public static readonly ID CTABackgroundImage = new ID("{74BE8A5A-9018-4EFA-B3C8-175D0B75FE55}");
                public static readonly ID CTATitle = new ID("{D1A19ABA-8488-4FF2-9432-1FF42F96A333}");
                public static readonly ID CTAText = new ID("{B5FA4118-83FD-48E7-AA0E-D2EE69AD9136}");
                public static readonly ID CTALink = new ID("{2740BFD4-6E0D-4099-A044-B29D6EF2C3DF}");
            }
        }

        public static class HomepageHero
        {
            public static class Fields
            {
                public static readonly ID HomepageHeroBackgroundImage = new ID("{372D4EEF-4FE2-4040-B52B-28ED912AB099}");
                public static readonly ID HomepageHeroTagline = new ID("{A2C27361-C25E-4BFB-95AE-5C831455C06B}");
                public static readonly ID HomepageHeroTitle = new ID("{2B780F4A-E72B-44BC-ABD4-683532B83DDD}");
                public static readonly ID HomepageHeroSubtitle = new ID("{CFAD1589-35EF-47E1-940C-F04D1BC00ED9}");
                public static readonly ID HomepageHeroCTALink = new ID("{48B24967-7AE3-48BE-BC6E-D2415D4797FF}");
                public static readonly ID HomepageHeroCTALinkText = new ID("{D6B08588-FFBB-400D-BC84-854D48432AE9}");
            }
        }
    }
}