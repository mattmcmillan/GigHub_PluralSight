namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameArtistsFollowedToUsersFollowed : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Followings", name: "ArtistFollowedId", newName: "UserFollowedId");
            RenameIndex(table: "dbo.Followings", name: "IX_ArtistFollowedId", newName: "IX_UserFollowedId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Followings", name: "IX_UserFollowedId", newName: "IX_ArtistFollowedId");
            RenameColumn(table: "dbo.Followings", name: "UserFollowedId", newName: "ArtistFollowedId");
        }
    }
}
