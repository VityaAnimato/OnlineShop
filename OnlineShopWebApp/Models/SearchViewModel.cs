namespace OnlineShopWebApp.Models
{
    public class SearchViewModel
    {
        public string SearchString { get; set; }

        public SearchViewModel(string searchString)
        {
            SearchString = searchString;
        }

        public SearchViewModel() { }
    }
}
