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
    public partial class EnderecoPorCep : ContentPage
    {
        public EnderecoPorCep()
        {
            InitializeComponent();
        }



        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                act_caregando.IsRunning = true;
                
                Endereco endereco = await DataService.GetEnderecoByCep(txt_cep.Text);

                BindingContext= endereco;             
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");

            } finally
            {
                act_caregando.IsRunning = false;
            }
        }
    }
}