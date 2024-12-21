namespace Infrastructure.Common
{
    public static class Constants
    {
        public const string DEFAULT_PASSWORD = "StrongP@ssw0rd!";

        public const string STATUS_OPEN = "OPEN";
        public const string STATUS_NEW = "NEW";
        public const string STATUS_CLOSED = "CLOSED";

        public const string ROLE_ADMIN_ID = "d3b07384-d9a0-4c8b-8b0d-2f3b8b6e0a1e";
        public const string ROLE_USER_ID = "a1b2c3d4-e5f6-7890-abcd-ef1234567890";

        public const string ROLE_ADMIN = "Admin";
        public const string ROLE_USER = "User";

        public static readonly Dictionary<string, string> UserRoles = new()
        {
            { ROLE_ADMIN_ID, ROLE_ADMIN },
            { ROLE_USER_ID, ROLE_USER }
        };

        public const string DEFAULT_AVATAR = "avatar.png";
    }
}