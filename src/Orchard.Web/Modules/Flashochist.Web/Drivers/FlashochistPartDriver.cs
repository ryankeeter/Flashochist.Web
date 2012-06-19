using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flashochist.Web.Models;
using Orchard.ContentManagement.Drivers;

namespace Flashochist.Web.Drivers
{
    public class FlashochistPartDriver : ContentPartDriver<FlashochistPart>
    {
        protected override string Prefix
        {
            get { return "Flashochist"; }
        }
        //GET
        protected override DriverResult Editor(FlashochistPart part, dynamic shapeHelper) {
            return ContentShape("Parts_Flashochist_Edit",
                                () => shapeHelper.EditorTemplate(TemplateName: "Parts/Flashochist", Model: part, Prefix: Prefix));
        }
        //POST
        protected override DriverResult Editor(FlashochistPart part, Orchard.ContentManagement.IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}