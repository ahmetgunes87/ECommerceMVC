namespace ECommerce.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTcKimlikNoToIdentificationNumberAndTelefonToPhoneInCustomersTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OrderStatus", newName: "OrderStatuses");
            AddColumn("dbo.Customers", "IdentificationNumber", c => c.String(maxLength: 11, unicode: false));
            AddColumn("dbo.Customers", "Phone", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AlterColumn("dbo.OrderStatuses", "Status", c => c.String(nullable: false, maxLength: 50, unicode: false));
            DropColumn("dbo.Customers", "TcKimlikNo");
            DropColumn("dbo.Customers", "Telefon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Telefon", c => c.String(nullable: false, maxLength: 30, unicode: false));
            AddColumn("dbo.Customers", "TcKimlikNo", c => c.String(maxLength: 11, unicode: false));
            AlterColumn("dbo.OrderStatuses", "Status", c => c.String());
            DropColumn("dbo.Customers", "Phone");
            DropColumn("dbo.Customers", "IdentificationNumber");
            RenameTable(name: "dbo.OrderStatuses", newName: "OrderStatus");
        }
    }
}
