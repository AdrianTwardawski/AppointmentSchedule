using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduling.Utility
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailjetClient client = new MailjetClient("2a458ac05aecf8e4607ac8a47980f16d", "2a5aea2f65e11956605e6754effdb873")
            {
               
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
               .Property(Send.Messages, new JArray {
                new JObject {
                 {"From", new JObject {
                  {"Email", "adriantwardawski@gmail.com"},
                  {"Name", "Appointment Scheduler"}
                  }},
                 {"To", new JArray {
                  new JObject {
                   {"Email", email},                
                   }
                  }},
                 {"Subject", subject},          
                 {"HTMLPart", htmlMessage}
                 }
                   });
            MailjetResponse response = await client.PostAsync(request);
        }
    }
}
