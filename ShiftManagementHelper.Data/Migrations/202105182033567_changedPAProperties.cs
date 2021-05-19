namespace ShiftManagementHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedPAProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PositionAssignment", "Shift_ShiftId", "dbo.Shift");
            DropIndex("dbo.PositionAssignment", new[] { "Shift_ShiftId" });
            RenameColumn(table: "dbo.PositionAssignment", name: "Shift_ShiftId", newName: "ShiftId");
            AlterColumn("dbo.PositionAssignment", "ShiftId", c => c.Int(nullable: false));
            CreateIndex("dbo.PositionAssignment", "ShiftId");
            AddForeignKey("dbo.PositionAssignment", "ShiftId", "dbo.Shift", "ShiftId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PositionAssignment", "ShiftId", "dbo.Shift");
            DropIndex("dbo.PositionAssignment", new[] { "ShiftId" });
            AlterColumn("dbo.PositionAssignment", "ShiftId", c => c.Int());
            RenameColumn(table: "dbo.PositionAssignment", name: "ShiftId", newName: "Shift_ShiftId");
            CreateIndex("dbo.PositionAssignment", "Shift_ShiftId");
            AddForeignKey("dbo.PositionAssignment", "Shift_ShiftId", "dbo.Shift", "ShiftId");
        }
    }
}
