using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Sitecon.Feature.PageContent
{
    public static class Templates
    {
        public static class BodyCopy
        {
            public static class Fields
            {
                public static readonly ID BodyCopy = new ID("{BF336B27-849C-43F7-9EA7-279AC081FA7E}");
            }
        }

        public static class TwoImage
        {
            public static class Fields
            {
                public static readonly ID Image1 = new ID("{F8BA62DE-D51C-48C7-A1FE-1FF8C7F274B6}");
                public static readonly ID Image2 = new ID("{9B9E9AFC-BC6B-4BD5-BB16-351030223DAD}");
            }
        }

        public static class TitleAndText
        {
            public static class Fields
            {
                public static readonly ID ComponentTitle = new ID("{066248B8-F289-4049-BE0F-843CE9045678}");
                public static readonly ID ComponentText = new ID("{4B8A82EE-545A-467F-AB0D-AA07194110EB}");
            }
        }

        public static class ListWithIcons
        {
            public static class Fields
            {
                public static readonly ID ListIcon = new ID("{C31EB179-4A7F-4B82-90DD-6C4AECF53580}");
                public static readonly ID ListText = new ID("{BD997699-CD59-46AD-8ECE-CF51A20B4210}");
            }
        }

        public static class Hero
        {
            public static class Fields
            {
                public static readonly ID HeroBackgroundImage = new ID("{D8B32A62-7CD4-4AFB-89D6-A3E3A97C4632}");
                public static readonly ID HeroTitle = new ID("{21625D95-4C9E-458C-9436-7588E444A99E}");
                public static readonly ID HeroSubtitle = new ID("{1F7BA84F-C51E-4E00-97BB-6AF81226E099}");
            }
        }

        public static class YouTubeVideo
        {
            public static class Fields
            {
                public static readonly ID YouTubeVideoId = new ID("{DF7F0F3E-CE3A-407E-9F09-30E80C7B98CD}");
            }
        }
    }
}