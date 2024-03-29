﻿using AppCep.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCep.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCep.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuscaCepPorLogradouro : ContentPage
    {
        public BuscaCepPorLogradouro()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;

                List<Cep> arr_cep = await DataService.GetCepByLogradouro(txt_cep.Text);

                lst_ceps.ItemsSource = arr_cep;
            }
            catch (Exception ex)
            {
                await DisplayAlert("OPS", ex.Message, "OK");

            } finally
            {
                carregando.IsRunning = false;
            }
        }
    }
}