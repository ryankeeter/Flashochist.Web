using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace Flashochist.Web.Models
{
    public class FlashochistPartRecord : ContentPartRecord
    {
        public virtual DateTime CreatedAt { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}