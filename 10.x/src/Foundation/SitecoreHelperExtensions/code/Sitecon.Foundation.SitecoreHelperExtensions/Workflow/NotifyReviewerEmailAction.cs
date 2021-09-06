using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Workflows.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Sitecon.Foundation.SitecoreHelperExtensions.Workflow
{
    public class NotifyReviewerEmailAction
    {
        public void Process(WorkflowPipelineArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            ProcessorItem processorItem = args.ProcessorItem;

            if (processorItem != null)
            {
                Item item = processorItem.InnerItem;

                if (item != null)
                {
                    string fullPath = item.Paths.FullPath;
                    string fromEmail = GetFieldValueFromArgs(item, "from", args);
                    string toEmail = GetFieldValueFromArgs(item, "to", args);
                    string mailServer = GetFieldValueFromArgs(item, "mail server", args);
                    string subject = GetFieldValueFromArgs(item, "subject", args);
                    string message = GetFieldValueFromArgs(item, "message", args);

                    MailMessage mailMessage = new MailMessage(fromEmail, toEmail);
                    mailMessage.Subject = subject;
                    mailMessage.Body = message;
                    mailMessage.IsBodyHtml = true;

                    var client = new SmtpClient(mailServer);
                    client.Credentials = new System.Net.NetworkCredential("name@gmail.com", "GmailPassword");
                    client.Port = 587;
                    client.EnableSsl = true;

                    client.Send(mailMessage);
                }
            }
        }

        public string GetFieldValueFromArgs(Item commandItem, string field, WorkflowPipelineArgs args)
        {
            string fieldText = commandItem[field];
            if (string.IsNullOrEmpty(fieldText)) return string.Empty;

            Item workflowItem = args.DataItem;
            if (workflowItem == null) return string.Empty;

            string currentHostName = "https://cm.sitecondocker.localho.st";
            string workflowItemId = workflowItem.ID.ToString().Replace("{", string.Empty).Replace("}", string.Empty);
            string contentEditorUrl = string.Format("<a href=\"{0}/sitecore/shell/Applications/Content%20editor.aspx?fo=%7B{1}%7D&id=%7B{2}%7D&la=en&v=1&sc_bw=1\" target=\"_blank\">{3}</a>", currentHostName, workflowItemId, workflowItemId, workflowItem.DisplayName);
            fieldText = fieldText.Replace("$itemLink$", contentEditorUrl);

            return fieldText;
        }
    }
}
