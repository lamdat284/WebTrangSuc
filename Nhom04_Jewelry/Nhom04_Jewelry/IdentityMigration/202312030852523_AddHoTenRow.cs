namespace Nhom04_Jewelry.IdentityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHoTenRow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "HoTen", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "HoTen");
        }
    }
}
