namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SchedulerContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Type = c.String(nullable: false, maxLength: 50, unicode: false),
                        StartDateTime = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        UserUsername = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserUsername)
                .Index(t => t.UserUsername);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50, unicode: false),
                        Firstname = c.String(nullable: false, maxLength: 50, unicode: false),
                        Lastname = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Role = c.String(nullable: false, maxLength: 50, unicode: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Username)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Desc = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserMeetings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserUsername = c.String(maxLength: 50, unicode: false),
                        MeetingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meetings", t => t.MeetingId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserUsername)
                .Index(t => t.UserUsername)
                .Index(t => t.MeetingId);
            
            CreateTable(
                "dbo.Meetings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Desc = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vacations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 50, unicode: false),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        NumberOfDays = c.Int(nullable: false),
                        UserUsername = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserUsername)
                .Index(t => t.UserUsername);
            
            CreateTable(
                "dbo.Holidays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacations", "UserUsername", "dbo.Users");
            DropForeignKey("dbo.UserMeetings", "UserUsername", "dbo.Users");
            DropForeignKey("dbo.UserMeetings", "MeetingId", "dbo.Meetings");
            DropForeignKey("dbo.Users", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Activities", "UserUsername", "dbo.Users");
            DropIndex("dbo.Vacations", new[] { "UserUsername" });
            DropIndex("dbo.UserMeetings", new[] { "MeetingId" });
            DropIndex("dbo.UserMeetings", new[] { "UserUsername" });
            DropIndex("dbo.Users", new[] { "TeamId" });
            DropIndex("dbo.Activities", new[] { "UserUsername" });
            DropTable("dbo.Holidays");
            DropTable("dbo.Vacations");
            DropTable("dbo.Meetings");
            DropTable("dbo.UserMeetings");
            DropTable("dbo.Teams");
            DropTable("dbo.Users");
            DropTable("dbo.Activities");
        }
    }
}
