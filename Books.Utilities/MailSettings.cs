using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Utilities
{
    public class MailSettings
    {
        public string FromMail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SMTPServer { get; set; }
        public int Port { get; set; }
    }
}
