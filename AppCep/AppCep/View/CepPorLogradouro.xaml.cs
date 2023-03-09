using AppCep.Model;
using AppCep.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCep.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CepPorLogradouro : ContentPage
    {
        public CepPorLogradouro()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning= true;
                List<Cep> arr_ceps = await DataService.GetCepsByLogradouro(txt_logradouro.Text);
            }catch(Exception ex) 
            {
                await DisplayAlert("Ops", ex.Message, "Ok");

            }finally
            {
                carregando.IsRunning = false;
            }



        }
    }
}