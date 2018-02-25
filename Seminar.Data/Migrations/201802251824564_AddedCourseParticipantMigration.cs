namespace Seminar.Data
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCourseParticipantMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseParticipant", "Name", c => c.String());
            AddColumn("dbo.CourseParticipant", "Email", c => c.String());
            AddColumn("dbo.CourseParticipant", "Course_Id", c => c.Int());
            CreateIndex("dbo.CourseParticipant", "Course_Id");
            AddForeignKey("dbo.CourseParticipant", "Course_Id", "dbo.Course", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseParticipant", "Course_Id", "dbo.Course");
            DropIndex("dbo.CourseParticipant", new[] { "Course_Id" });
            DropColumn("dbo.CourseParticipant", "Course_Id");
            DropColumn("dbo.CourseParticipant", "Email");
            DropColumn("dbo.CourseParticipant", "Name");
        }
    }
}
