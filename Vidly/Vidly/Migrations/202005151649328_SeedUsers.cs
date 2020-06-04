namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3390eda7-c6b6-4f57-bbdc-78ce455715f8', N'admin@vidly.com', 0, N'AKRIVZMRJdTzvqzUV6qenwCK2pdJ5S6R/U88tY2gTWH+/lTKr2JV4ViJjholWWtE7g==', N'3f4bf8b1-cbbe-4329-84f6-0d78e5ca59c3', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'94a17b69-842c-4a98-be77-052feced441d', N'damianocr@gmail.com', 0, N'AEsiz9ceIwoIy5kVpBk72HnX6cWqUjdu1YGGLbxXL0q9EyZBXpgedIvWPWQ35nVn6w==', N'37a6b3ef-56e1-43a7-9721-effb81acae39', NULL, 0, 0, NULL, 1, 0, N'damianocr@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f30b9c83-86b9-47ee-a85c-1747358ff7d5', N'ospite@vidly.com', 0, N'AHEbx/RM8RwOcb+QW0P+xXsaN5k7/EuEZ6V8Wmb2L7qtdx3jEfwxqbz5gM09d0Yatw==', N'08412bdc-629e-4d90-844d-28f235c71b22', NULL, 0, 0, NULL, 1, 0, N'ospite@vidly.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3a20a100-7200-4dd4-a1b8-37262697adb4', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3390eda7-c6b6-4f57-bbdc-78ce455715f8', N'3a20a100-7200-4dd4-a1b8-37262697adb4')
");
        }
        
        public override void Down()
        {
        }
    }
}
