using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;

namespace Sitecon.Foundation.SitecoreHelperExtensions.Ribbon.Security
{
    public class ResetSecurityTSV : Command
    {
        public override void Execute(CommandContext context)
        {
            if (context.Items != null && context.Items.Length != 0)
            {
                Sitecore.Data.Items.Item targetItem = context.Items[0];
                if (targetItem == null) return;

                Sitecore.Data.Items.Item stdVals = targetItem.Template.StandardValues;
                bool hasStandardValues = stdVals != null;

                if (hasStandardValues)
                {
                    using (new Sitecore.SecurityModel.SecurityDisabler())
                    {
                        targetItem.Editing.BeginEdit();
                        targetItem["__Security"] = stdVals["__Security"];
                        targetItem.Editing.EndEdit();
                    }
                }
            }
        }
    }
}
