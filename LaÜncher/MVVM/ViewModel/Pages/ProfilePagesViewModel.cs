namespace USoftware_HUb.MVVM.ViewModel.Pages
{
    class ProfilePagesViewModel
    {
        private static ProfilePagesViewModel? _instance;
        public static ProfilePagesViewModel Instance => _instance ??= new ProfilePagesViewModel();

        private ProfilePagesViewModel()
        {

        }
    }
}
