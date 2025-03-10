using MauiAppMinhasCompras2.Helpers;
using MauiAppMinhasCompras2.Views;

namespace MauiAppMinhasCompras2
{
    public partial class App : Application
    {
        //campo estático (pertence a classe)
        static SQLiteDatabaseHelper _db;

        public static SQLiteDatabaseHelper Db
        {
            get 
            {
                //se a instância _db não foi criada, cria uma nova instância
                if (_db == null)
                {
                    //obtém o caminho do banco de dados atráves da pasta LocalApplicationData

                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");

                    //Cria uma nova instância do SQLiteDatabaseHelper, passando o caminho do bd
                    _db = new SQLiteDatabaseHelper(path);
                }

                return _db;
            }
        }
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
