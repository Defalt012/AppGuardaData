using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCLExt.FileStorage.Folders;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppGuardaData
{
    public partial class App : Application
    {
        //Conexao com o banco
        public SQLite.SQLiteConnection Conexao { get; private set; }

        public App()
        {
            //Local do banco
            var pasta = new LocalRootFolder();

            //Crio o arquivo do banco (se ele não existir)
            // se ele existir, abor ele
            var arquivo = pasta.CreateFile("banco.db",PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);

            //faço a "conexao"
            Conexao = new SQLite.SQLiteConnection(arquivo.Path);

            // Criar uma tabela, se ela não existir
            Conexao.Execute("CREATE TABLE IF NOT EXISTS informacoes (id INTEGER PRIMARY KEY AUTOINCREMENT, info TEXT)");

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
