namespace TaskList2.Helpers
{
    public static class Locations
    {
//#if DEBUG
//        public static readonly string AppServiceUrl = "http://localhost:17568/";
//        public static readonly string AlternateLoginHost = "https://the-book.azurewebsites.net";
//#else
        public static readonly string AppServiceUrl = "https://azuresyncpocapp2.azurewebsites.net/";
        public static readonly string AlternateLoginHost = null;
//#endif

        public static readonly string AadClientId = "f80bd29d-a3d2-438d-8807-e2dc6be9f27d";

        public static readonly string AadRedirectUri = "https://azuresyncpocapp2.azurewebsites.net/.auth/login/done";

        public static readonly string AadAuthority = "https://login.windows.net/redarrow.cloud.onmicrosoft.com";

        public static readonly string CommonAuthority = "https://login.windows.net/common";
    }
}
