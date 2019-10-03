using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppGuardaData
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CarregarInformacoes();
        }
        private void CarregarInformacoes()
        {
            string sql = "SELECT * FROM informacoes";
            var lista = ((App)Application.Current).Conexao.Query<Model>(sql);
            listView.ItemsSource = lista;
        }

        private void ButtonAdicionar_Clicked(object sender, EventArgs e)
        {
            string sql = $"INSERT INTO informacoes (info) VALUES ('{DateTime.Now}')";
            ((App)Application.Current).Conexao.Execute(sql);
            DisplayAlert("SUCESSO", "Item inserido", "OK");
            CarregarInformacoes();
        }

        private async void ButtonApagarTudo_Clicked(object sender, EventArgs e)
        {
            var confirmacao = await DisplayAlert("Confirmação","Tem certeza ?","Sim","Não");
            if (confirmacao == true) //SQLite.SQLiteException: no such table: informaçõeswew
            {
                string sql = "DELETE FROM informacoes";
                ((App)Application.Current).Conexao.Execute(sql);
                await DisplayAlert("SUCESSO", "VAI CARAI", "OK");
                CarregarInformacoes();

            }
            else
            {
                await DisplayAlert("EITA", "MERLIN", "OK");
            }
        }

        private void MenuItemAtualizar_Clicked(object sender, EventArgs e)
        {
            var mi = (MenuItem)sender;
            var model = (Model)mi.CommandParameter;
            var sql = $"UPDATE informacoes SET info = '{DateTime.Now}' WHERE id = '{model.ID}'";
            ((App)Application.Current).Conexao.Execute(sql);
            DisplayAlert("OPAAAAA","AAAAOOPPPPP","OK");
        }

        private async void MenuItemDeletar_Clicked(object sender, EventArgs e)
        {
            var confirmacao = await DisplayAlert("Confirmação", "Tem certeza ?", "Sim", "Não");
            if (confirmacao == true)
            {
                var mi = (MenuItem)sender;
                var model = (Model)mi.CommandParameter;

                var sql = $"DELETE FROM informacoes WHERE id = {model.ID}";
                ((App)Application.Current).Conexao.Execute(sql);
                await DisplayAlert("SUCESSO", "VAI CARAI", "OK");
                CarregarInformacoes();


            }
            else
            {
                await DisplayAlert("EITA", "MERLIN", "OK");
            }

        }
    }
}
