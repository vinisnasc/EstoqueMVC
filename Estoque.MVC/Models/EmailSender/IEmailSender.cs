using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.MVC.Models.EmailSender
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string templateId, TemplateData templateData);
    }
}
