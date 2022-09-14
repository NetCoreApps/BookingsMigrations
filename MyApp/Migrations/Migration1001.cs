using ServiceStack.OrmLite;

namespace MyApp.Migrations;

public class Migration1001 : MigrationBase
{
    class Booking
    {
        public bool? IsRepeatGuest { get; set; }
    }
    
    public override void Up()
    {
        Db.Migrate<Booking>();
    }

    public override void Down()
    {
        Db.Revert<Booking>();
    }
}