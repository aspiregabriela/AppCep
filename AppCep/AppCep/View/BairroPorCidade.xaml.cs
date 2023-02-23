﻿using AppCep.Model;
using AppCep.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCep.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BairroPorCidade : ContentPage
    {
       ObservableCollection<Cidade> lista_cidades= new ObservableCollection<Cidade>();
        ObservableCollection<Bairro> lista_bairros = new ObservableCollection<Bairro>();
        public BairroPorCidade()
        {
            InitializeComponent();

           pck_cidade.ItemsSource= lista_cidades;
           lista_bairros.ItemsSource= lista_bairros;
        }

        private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker disparador= sender as Picker;
                string estado_selecionado = disparador.SelectedItem as string;
                List<Cidade> arr_cidades = await DataService.GetCidadesByEstado(estado_selecionado);
                lista_cidades.Clear();
                arr_cidades.ForEach( i => lista_cidades.Add(i));

            }
            catch(Exception ex)
            {
                await DisplayAlert("ops", ex.Message, "ok");

            }

        }

        private void pck_cidade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}