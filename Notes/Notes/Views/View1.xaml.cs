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
    public partial class View1 : ContentPage
    {
        public View1()
        {
            InitializeComponent();
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
           Navigation.PushAsync(new MoviesPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());

        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NotesPage());

        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            var note = new Note();
            Navigation.PushAsync(new NoteEntryPage(note));

        }
    }   
}