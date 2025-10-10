namespace Finances_Uno.Services;

public static partial class Authentication
{
    // ClientIdSecret should be provided in `Authentication.Secrets.cs` as part of the 
    // partial class
    public static string Tenant => TenantSecret;

    // ClientIdSecret should be provided in `Authentication.Secrets.cs` as part of the 
    // partial class
    public static string ClientId => ClientIdSecret;

    // RedirectUriSecret should be provided in `Authentication.Secrets.cs` as part of the 
    // partial class
#if __ANDROID__ || __IOS__
    public static string RedirectUri => RedirectUriSecretDesktop;
#else
    public static string RedirectUri => RedirectUriSecret;
#endif

#if __IOS__
    // BundleNameSecret should be provided in `Authentication.Secrets.cs` as part of the 
    // partial class
    public static string BundleName => BundleNameSecret;
#endif

    // ScopesSecret should be provided in `Authentication.Secrets.cs` as part of the 
    // partial class
    public static IEnumerable<string> Scopes => ScopesSecret;

    public static string Authority => $"https://login.microsoftonline.com/{Tenant}";

    public static string GivenNameClaimType => "given_name";
}
