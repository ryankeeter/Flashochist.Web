using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flashochist.Web.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Users.Models;

namespace Flashochist.Web.Handlers
{
    public class FlashochistHandler : ContentHandler
    {
        public FlashochistHandler(IRepository<FlashochistPartRecord> repo) {
            Filters.Add(StorageFilter.For(repo));
            Filters.Add(new ActivatingFilter<UserPart>("Flashochist"));

        }
    }
}