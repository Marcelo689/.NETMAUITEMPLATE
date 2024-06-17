using Contacts.Models;

namespace Contacts
{
    public partial class App : Application
    {
        public App(SQLiteRepository repository)
        {
            InitializeComponent();

            MainPage = new AppShell();
            Repository = repository;
        }

        public static SQLiteRepository Repository { get; set; }
    }
}
