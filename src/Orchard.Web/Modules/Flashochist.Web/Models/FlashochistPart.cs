using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.Users.Models;

namespace Flashochist.Web.Models
{
    public class FlashochistPart : ContentPart<FlashochistPartRecord>
    {
        public string FirstName {
            get { return Record.FirstName; }
            set { Record.FirstName = value; }
        }
        public string LastName {
            get { return Record.LastName; }
            set { Record.LastName = value; }
        }

        public UserPart User {
            get { return this.As<UserPart>(); }
        }

        public DateTime CreatedAt {
            get { return Record.CreatedAt; }
            set { Record.CreatedAt = value; }
        }
    }
}