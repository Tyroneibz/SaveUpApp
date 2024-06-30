namespace SaveUp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.EntryPage), typeof(Views.EntryPage));
        }
    }
}
