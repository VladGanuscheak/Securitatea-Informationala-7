using BackgroundScripts.Options.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundScripts.Options
{
    public class SendEmailAnonymous : ISendEmailAnonymous
    {
        public string SendEmail { get; set; }
    }
}
