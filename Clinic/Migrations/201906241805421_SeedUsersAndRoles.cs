namespace Clinic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'17039d70-011c-48c6-83a0-5d6959c10f68', N'guest@clinic.com', 0, N'AI27MQQwe1E2ybpqKYRd82Ow7xsGoLfnGk5MvGM9T86bE5ZPM3EY46IchyfreGxQLw==', N'5deedb37-f9ac-4110-b9e2-00095d9a06ab', NULL, 0, 0, NULL, 1, 0, N'guest@clinic.com')");
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4fd6790f-f889-4f32-80ea-2f45ccfd79d5', N'admin@clinic.com', 0, N'ALyFI5BaS7aXUiEKKlQo6zozzgc/zWHp3NT3xD3kI82n1HzZL0ViJr7D6/9J0a+gzg==', N'a3102e5a-6a46-4255-bfd0-f784996bb96d', NULL, 0, 0, NULL, 1, 0, N'admin@clinic.com')");

            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a0794c9b-e526-4f46-b2a1-ad783ea52311', N'CanManageClinic')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4fd6790f-f889-4f32-80ea-2f45ccfd79d5', N'a0794c9b-e526-4f46-b2a1-ad783ea52311')");
        }

        public override void Down()
        {
        }
    }
}
