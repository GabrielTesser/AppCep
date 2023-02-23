using AppCep.Model;
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
    public partial class BairrosPorCidade : ContentPage
    {
        ObservableCollection<Cidade> Lista_cidade = new ObservableCollection<Cidade>();

        ObservableCollection<Bairro> Lista_bairro = new ObservableCollection<Bairro>();

        public BairrosPorCidade()
        {
            InitializeComponent();

            pck_estado.ItemsSource = Lista_cidade;

            lst_bairros.ItemsSource = Lista_bairro;
        }

        private async void pck_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Picker disparador = sender as Picker;

                string estado_selecionado = disparador.SelectedItem as string;

                List<Cidade> arr_cidades = await DataService.GetCidadesByEstado(estado_selecionado);

                Lista_cidade.Clear();

                arr_cidades.ForEach(i => Lista_cidade.Add(i));
            }
            catch (Exception ex) 
            {
                await DisplayAlert ("OPS", ex.Message, "ok");
            }
        }
    }
}