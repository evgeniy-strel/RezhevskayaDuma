﻿using MailKit.Security;

namespace RezhDumaASPCore_Backend.Services
{
    public class EmailSenderOptions
    {
        public EmailSenderOptions()
        {
            HostSecureSocketOptions = SecureSocketOptions.Auto;
        }
        public string HostAddress { get; set; }
        public int HostPort { get; set; }
        public string HostUsername { get; set; }
        public string HostPassword { get; set; }
        public SecureSocketOptions HostSecureSocketOptions { get; set; }
        public string SenderName { get; set; }
    }
}
