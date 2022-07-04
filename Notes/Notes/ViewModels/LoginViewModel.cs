using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Notes.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _userName;
        public string userName
        {
            get 
            { 
                return this._userName; 
            }
            set
            { 
                this._userName = value;
                OnPropertyChanged();
            }
        }

        private string _passWord;
        public string passWord
        {
            get 
            { 
                return this._passWord; 
            }
            set
            { 
                this._passWord = value;
                OnPropertyChanged();
            }
        }


        public Command LoginCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
        }

        private  async Task LoginCommandAsync()
        {
        }
    }
}
