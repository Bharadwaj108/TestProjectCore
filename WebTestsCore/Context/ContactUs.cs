using Bogus.DataSets;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebTestsCore.Context
{
    public class ContactUs
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string WebSiteUrl { get; set; }
        public string Company { get; set; }
        public string ReasonOfEnquiry { get; set; }

    }
}
