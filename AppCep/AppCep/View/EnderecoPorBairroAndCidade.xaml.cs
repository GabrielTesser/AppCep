﻿using AppCep.Model;
using AppCep.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCep.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnderecoPorBairroAndCidade : ContentPage
    {
        Cidade cidade_escolhida;
        ObservableCollection<Cidade> lista_cidades = new ObservableCollection<Cidade>();
        ObservableCollection<Bairro> lista_bairros = new ObservableCollection<Bairro>();

        public EnderecoPorBairroAndCidade()
        {
            InitializeComponent();
            pck_cidade.ItemsSource = lista_cidades;
            pck_bairro.ItemsSource = lista_bairros;
        }

        private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;
                lista_bairros.Clear();
                lista_cidades.Clear();

                Picker disparador = sender as Picker;

                string estado = disparador.SelectedItem as string;

                List<Cidade> arr_cidades = await DataService.GetCidadesByEstado(estado);

                lista_cidades.Clear();

                arr_cidades.ForEach(i => lista_cidades.Add(i));

            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                carregando.IsRunning = false;
            }
        }

        private async void pck_cidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;

                lst_endereco.ItemsSource = null;

                Picker disparador = sender as Picker;

                Bairro bairro_selecionado = disparador.SelectedItem as Bairro;

                if (bairro_selecionado != null)
                {
                    //List<Logradouro> arr_end = await DataService.GetLogradourosByBairrosAndIdCidade(bairro_selecionado.descricao_bairro, cidade_escolhida.id_cidade);

                    //lst_endereco.ItemsSource = arr_end;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                carregando.IsRunning = false;
            }
        }

        private async void pck_bairro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                carregando.IsRunning = true;
                lista_bairros.Clear();


                Picker disparador = sender as Picker;

                Cidade cidade_selecionada = disparador.SelectedItem as Cidade;

                lista_bairros.Clear();

                //List<Bairro> arr_bairros = await DataService.GetCidadesByEstado(cidade_selecionada.id_cidade);


                //arr_bairros.ForEach(item => lista_bairros.Add(item));
                //Console.WriteLine(arr_bairros);

                this.cidade_escolhida = cidade_selecionada;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Ok");
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                carregando.IsRunning = false;
            }
        }
    }
}