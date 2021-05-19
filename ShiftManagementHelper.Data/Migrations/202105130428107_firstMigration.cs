namespace ShiftManagementHelper.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PositionAssignment",
                c => new
                    {
                        PositionAssignmentId = c.Int(nullable: false, identity: true),
                        PositionId = c.Int(nullable: false),
                        WorkerId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        Notes = c.String(),
                        Shift_ShiftId = c.Int(),
                    })
                .PrimaryKey(t => t.PositionAssignmentId)
                .ForeignKey("dbo.Position", t => t.PositionId, cascadeDelete: true)
                .ForeignKey("dbo.Worker", t => t.WorkerId, cascadeDelete: true)
                .ForeignKey("dbo.Shift", t => t.Shift_ShiftId)
                .Index(t => t.PositionId)
                .Index(t => t.WorkerId)
                .Index(t => t.Shift_ShiftId);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        PositionName = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.PositionId);
            
            CreateTable(
                "dbo.Worker",
                c => new
                    {
                        WorkerId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        WorkerFirstName = c.String(nullable: false),
                        WorkerLastName = c.String(nullable: false),
                        EmploymentStartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Role = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.WorkerId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Shift",
                c => new
                    {
                        ShiftId = c.Int(nullable: false, identity: true),
                        ShiftName = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        Date = c.DateTimeOffset(nullable: false, precision: 7),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ShiftId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.PositionAssignment", "Shift_ShiftId", "dbo.Shift");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.PositionAssignment", "WorkerId", "dbo.Worker");
            DropForeignKey("dbo.PositionAssignment", "PositionId", "dbo.Position");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.PositionAssignment", new[] { "Shift_ShiftId" });
            DropIndex("dbo.PositionAssignment", new[] { "WorkerId" });
            DropIndex("dbo.PositionAssignment", new[] { "PositionId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Shift");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Worker");
            DropTable("dbo.Position");
            DropTable("dbo.PositionAssignment");
        }
    }
}
