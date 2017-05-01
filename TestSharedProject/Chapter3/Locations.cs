namespace TaskList3
{
    public static class Locations
    {
        public static readonly string AppServiceUrl = "https://azuresyncpocapp3.azurewebsites.net";

        public static readonly string AlternateLoginHost = null;

        public static readonly string AadClientId = "63c8769b-ac55-41ca-8b60-cc9988d1fd2c";

        public static readonly string AadRedirectUri = $"{AppServiceUrl}/.auth/login/done";

        public static readonly string AadAuthority = "https://login.windows.net/redarrow.cloud.onmicrosoft.com";
    }
}

