using Acr.UserDialogs;
using Notes.Models;
using Notes.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{   
    public partial class CadastrarLoginPage : ContentPage
    {
        MovieService servico = new MovieService();

        protected IUserDialogs _userDialogs { get; private set; }
        public CadastrarLoginPage()
        {
            InitializeComponent();
            BindingContext = new Usuario();
        }

       

        public async void teste(object sender, EventArgs e)
        {
            try
            {
                var note = (Usuario)BindingContext;


                if (note.NOME_USUARIO != null && note.TELEFONE != null && note.NOME_COMPLETO != null && note.SENHA_USUARIO != null)
                {
                    try
                    {
                        var a = int.Parse(note.TELEFONE);

                        var usuario = await App.Database.GeUsuarioAsync(note);

                        if (usuario != null)
                        {
                            await DisplayAlert("Erro", "Nome de usuario ja cadastrado", "OK");
                            return;
                        }

                        await App.Database.SaveUsuarioAsync(note);

                        

                        await DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "OK");

                        await Navigation.PushAsync(new LoginPage());
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("FALHA", "O campo telefone deve ser preenchido com numeros", "OK");

                    }


                }
                else
                {
                    if (note.NOME_USUARIO == null)
                    {
                        usuario.Placeholder = "PREENCHA ESTE CAMPO";
                        usuario.Background = new SolidColorBrush(Color.Red);
                    }
                    else
                    {
                        usuario.Background = new SolidColorBrush(Color.Transparent);

                    }

                    if (note.TELEFONE == null)
                    {
                        TELEFONE.Placeholder = "PREENCHA ESTE CAMPO";
                        TELEFONE.Background = new SolidColorBrush(Color.Red);
                    }
                    else
                    {
                        TELEFONE.Background = new SolidColorBrush(Color.Transparent);

                    }

                    if (note.SENHA_USUARIO == null)
                    {
                        SENHA_USUARIO.Placeholder = "PREENCHA ESTE CAMPO";
                        SENHA_USUARIO.Background = new SolidColorBrush(Color.Red);
                    }
                    else
                    {
                        SENHA_USUARIO.Background = new SolidColorBrush(Color.Transparent);

                    }

                    if (note.NOME_COMPLETO == null)
                    {
                        NOME_COMPLETO.Placeholder = "PREENCHA ESTE CAMPO";
                        NOME_COMPLETO.Background = new SolidColorBrush(Color.Red);
                    }
                    else
                    {
                        NOME_COMPLETO.Background = new SolidColorBrush(Color.Transparent);

                    }

                }

            }
            catch (Exception EX)
            {
                await DisplayAlert("Alert", "Preencha os campos em vermelho", "OK");

            }
        }
    }
}