using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;

namespace Sitecon.Feature.Navigation.Models
{
    public class NavigationItem
    {
        public Item Item { get; set; }
        public string ItemUrl { get; set; }
    }
}
