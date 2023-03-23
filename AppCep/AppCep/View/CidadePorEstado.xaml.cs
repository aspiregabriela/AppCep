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
    public partial class CidadePorEstado : ContentPage
    {
        public CidadePorEstado()
        {
            InitializeComponent();
        }
        private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker disparador = (Picker)sender;

                string uf = disparador.SelectedItem as string;

                List<Cidade> lista_cidade = await DataService.GetCidadeByEstado(uf);

                lst_cidade.ItemsSource = lista_cidade;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

    }
}