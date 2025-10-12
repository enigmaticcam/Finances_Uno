namespace Finances_Uno.Presentation;
public partial class CatAPIPage : Page
{
    public CatAPIPage()
    {
        InitializeComponent();
        ViewModel.Dispatcher = Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread();
    }
    private async void BreedSearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
    {
        await ViewModel.SearchBreeds();
    }
}
