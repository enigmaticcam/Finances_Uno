namespace Finances_Uno.Services;

public static partial class Authentication
{
    // In this sample, this value will be "bebbsauthspike"
    private static readonly string TenantSecret = "942dc639-8461-4fce-bb9a-dbd099999553";

    // This is the ClientId value from the app registration. 
    // It will be in the form of "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee"
    private static readonly string ClientIdSecret = "ad0da1fc-d884-4115-8c95-40ce18f8a745";

    // In this sample, this value will be "http://localhost:5000"
    private static readonly string RedirectUriSecret = "ctangenfinances://login-callback";
    //private static readonly string RedirectUriSecret = "http://localhost:5000";

    private static readonly string RedirectUriSecretDesktop = $"msalad0da1fc-d884-4115-8c95-40ce18f8a745://auth";

    // In this sample, this value will be "com.companyname.UnoAuth"
    private static readonly string BundleNameSecret = "[REPLACE THIS VALUE]";

    // Note, we're currently only interested in authenticating, not defining any additional scopes which a
    // user may or may not have access to. As such, we only request access to the `openid` scope.
    private static readonly IEnumerable<string> ScopesSecret = new[] { "https://graph.microsoft.com/openid" };
}
