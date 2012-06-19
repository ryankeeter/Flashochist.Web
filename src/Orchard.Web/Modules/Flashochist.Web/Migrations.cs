using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flashochist.Web.Models;
using Orchard.Core.Common.Models;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;
using Orchard.ContentManagement.MetaData;

namespace Flashochist.Web
{
    public class Migrations : DataMigrationImpl
    {
        public int Create() {
            ContentDefinitionManager.AlterTypeDefinition("Flashochist",
                                                         builder => builder
                                                                        .WithPart(typeof(CommonPart).Name)
                                                                        .Creatable());
            SchemaBuilder.CreateTable("FlashochistPartRecord", table
                => table
                .ContentPartRecord()
                .Column<string>("FirstName")
                .Column<string>("LastName"));

            ContentDefinitionManager.AlterTypeDefinition("Flashochist", builder =>
                                                                        builder.WithPart(typeof (FlashochistPart).Name));
            return 1;
        }
        public int UpdateFrom1() {
            SchemaBuilder.AlterTable("FlashochistPartRecord", table
                                                              => table.AddColumn<DateTime>("CreatedAt"));
            return 2;
        }
    }
}