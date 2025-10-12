using System.Collections.ObjectModel;
using Finances_Uno.Models.DataModels;
using Finances_Uno.WebServices;

namespace Finances_Uno.Models.ViewModels;

public class MainViewModel : DispatchedBindableBase
{
    // Insert member variables below here
    private bool _isBusy;
    private string _searchTerm = string.Empty;
    private ObservableCollection<Breed> _searchResults = new ObservableCollection<Breed>();
    private BreedSearchApi _breedSearchApi = new BreedSearchApi();

    // Insert properties below here
    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public string SearchTerm
    {
        get => _searchTerm;
        set => SetProperty(ref _searchTerm, value);
    }

    public ObservableCollection<Breed> SearchResults
    {
        get => _searchResults;
        set => SetProperty(ref _searchResults, value);
    }

    // Insert constructor below here

    // Insert SearchBreeds below here
    public async Task SearchBreeds()
    {
        if (!string.IsNullOrWhiteSpace(SearchTerm))
        {
            try
            {
                IsBusy = true;
                var result = await _breedSearchApi.Search(SearchTerm).ConfigureAwait(false);
                if (result.Any())
                {
                    SearchResults = new ObservableCollection<Breed>(result);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

    // Insert Favorites below here
}
