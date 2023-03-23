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

        private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker disparador = (Picker)sender;

                string uf = disparador.SelectedItem as string;

                List<Endereco> lista_endereco = await GetEnderecoByE;

                lst_endereco.ItemsSource = lista_endereco;

            }
            catch (Exception ex)
            {
               await DisplayAlert("Erro", ex.Message, "Ok");
            }
        }
    }
}