using System.IdentityModel.Tokens.Jwt;
using Finances_Uno.Services;
using Microsoft.Identity.Client;
using Uno.UI.MSAL;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Finances_Uno.Presentation.Login;

[TemplateVisualState(GroupName = AuthenticationStatesGroupName, Name = UnauthenticatedStateName)]
[TemplateVisualState(GroupName = AuthenticationStatesGroupName, Name = AuthenticatingStateName)]
[TemplateVisualState(GroupName = AuthenticationStatesGroupName, Name = AuthenticatedStateName)]
public sealed partial class MainLogin : Page
{
    private const string AuthenticationStatesGroupName = "AuthenticationStates";
    private const string UnauthenticatedStateName = "Unauthenticated";
    private const string AuthenticatingStateName = "Authenticating";
    private const string AuthenticatedStateName = "Authenticated";

    public static readonly DependencyProperty GivenNameProperty = DependencyProperty.Register("GivenName", typeof(string), typeof(MainLogin), new PropertyMetadata(string.Empty));

    private readonly IPublicClientApplication _authenticationClient;

    public MainLogin()
    {
        this.InitializeComponent();

        _authenticationClient = PublicClientApplicationBuilder
            .Create(Authentication.ClientId)
#if __IOS__
            .WithIosKeychainSecurityGroup(Authentication.BundleName)
#endif
            .WithAuthority(AzureCloudInstance.AzurePublic, Authentication.Tenant)
            .WithRedirectUri(Authentication.RedirectUri)
            .WithUnoHelpers()
            .Build();
    }

    private void TransitionToAuthenticated(AuthenticationResult authResult)
    {
        var token = new JwtSecurityToken(authResult.IdToken);

        GivenName = token.Claims
            .Where(claim => Authentication.GivenNameClaimType.Equals(claim.Type))
            .Select(claim => claim.Value)
            .First();

        VisualStateManager.GoToState(this, AuthenticatedStateName, true);
    }

    private async void SignInButton_Click(object sender, RoutedEventArgs e)
    {
        VisualStateManager.GoToState(this, AuthenticatingStateName, true);

        try
        {
            var accounts = await _authenticationClient.GetAccountsAsync();

            var result = await _authenticationClient
                .AcquireTokenSilent(Authentication.Scopes, accounts.FirstOrDefault())
                .ExecuteAsync();

            TransitionToAuthenticated(result);
        }
        catch (MsalUiRequiredException)
        {
            try
            {
                var result = await _authenticationClient
                    .AcquireTokenInteractive(Authentication.Scopes)
                    .WithPrompt(Prompt.ForceLogin)
                    .WithUnoHelpers()
                    .ExecuteAsync();

                TransitionToAuthenticated(result);
            }
            catch
            {
                // Something went wrong, the the user try again
                VisualStateManager.GoToState(this, UnauthenticatedStateName, true);
            }
        }
    }

    private async void SignOutButton_Click(object sender, RoutedEventArgs e)
    {
        IEnumerable<IAccount> accounts = await _authenticationClient.GetAccountsAsync();

        while (accounts.Any())
        {
            await _authenticationClient.RemoveAsync(accounts.First());
            accounts = await _authenticationClient.GetAccountsAsync();
        }

        VisualStateManager.GoToState(this, UnauthenticatedStateName, true);
    }

    public string GivenName
    {
        get { return (string)GetValue(GivenNameProperty); }
        set { SetValue(GivenNameProperty, value); }
    }
}
