namespace eCommerceSite.Models
{
    public class MusicCatalogViewModel
    {
        public MusicCatalogViewModel(List<Music> songs, int lastPage, int currentPage)
        {
            Songs = songs;
            LastPage = lastPage;
            CurrentPage = currentPage;
        }

        public List<Music> Songs { get; private set; }

        /// <summary>
        /// The last page of the catalog. Calculated by having
        /// a total number of products divided by products per page
        /// </summary>
        public int LastPage { get; private set; }

        /// <summary>
        /// The current page the user is viewing
        /// </summary>
        public int CurrentPage { get; private set; }
    }
}
