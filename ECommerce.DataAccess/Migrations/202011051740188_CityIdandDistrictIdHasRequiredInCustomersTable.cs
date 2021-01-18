namespace ECommerce.DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class CityIdandDistrictIdHasRequiredInCustomersTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "CityId" });
            DropIndex("dbo.Customers", new[] { "DistrictId" });
            AlterColumn("dbo.Customers", "CityId", c => c.Int(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: "0", newValue: null)
                    },
                }));
            AlterColumn("dbo.Customers", "DistrictId", c => c.Int(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: "0", newValue: null)
                    },
                }));
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.DateTime(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: "5.11.2020 16:37:19", newValue: null)
                    },
                }));
            AlterColumn("dbo.Customers", "DateOfRegistration", c => c.DateTime());
            CreateIndex("dbo.Customers", "CityId");
            CreateIndex("dbo.Customers", "DistrictId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "DistrictId" });
            DropIndex("dbo.Customers", new[] { "CityId" });
            AlterColumn("dbo.Customers", "DateOfRegistration", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "DateOfBirth", c => c.DateTime(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "5.11.2020 16:37:19")
                    },
                }));
            AlterColumn("dbo.Customers", "DistrictId", c => c.Int(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            AlterColumn("dbo.Customers", "CityId", c => c.Int(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "Default",
                        new AnnotationValues(oldValue: null, newValue: "0")
                    },
                }));
            CreateIndex("dbo.Customers", "DistrictId");
            CreateIndex("dbo.Customers", "CityId");
        }
    }
}
