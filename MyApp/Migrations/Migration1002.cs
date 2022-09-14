using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;

namespace MyApp.Migrations;

public class Migration1002 : MigrationBase
{
    public override void Up()
    {
        Db.ExecuteSql(
        @"ALTER TABLE ""Booking"" RENAME COLUMN ""IsRepeatGuest"" TO ""RepeatGuest"";");
    }

    public override void Down()
    {
        Db.ExecuteSql(
        @"ALTER TABLE ""Booking"" RENAME COLUMN ""RepeatGuest"" TO ""IsRepeatGuest"";");
    }
}