using FreshHeadBackend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshHeadBackendUnitTest.STUB
{
    public class MailStub : IMailService
    {
        public bool SendEmailAsync(string mail, string subject, string mailMSG)
        {
            throw new NotImplementedException();
        }
    }
}
