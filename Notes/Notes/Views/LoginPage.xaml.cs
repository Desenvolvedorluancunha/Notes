using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new Usuario();

        }

        async void Logar(object sender, EventArgs e)
        {
            var note = (Usuario)BindingContext;

            var usuario = await App.Database.GeUsuarioAsync(note);

            if(note.NOME_USUARIO == null)
            {
                await DisplayAlert("Verifique os campos", "usuario vazio", "OK");
                return;
            }else if (note.SENHA_USUARIO == null)
            {
                await DisplayAlert("Verifique os campos", "Senha vazia", "OK");
                return;
            }

            if (usuario.SENHA_USUARIO == note.SENHA_USUARIO)
            {
                await Navigation.PushAsync(new View1());
            }
            else
            {
                await DisplayAlert("Verifique os campos", "Senha ou login invalidos", "OK");
            }

            
        }



        async void Resgistrar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastrarLoginPage());
        }
    }
}