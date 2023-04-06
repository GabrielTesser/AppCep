using AppCep.Service;
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
    public partial class BairroPorCidade : ContentPage
    {
        public BairroPorCidade()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
        
                

                carregando.IsRunning = true;

                List<Bairro> arr_bairros = await DataService.GetBairrosByCidade(int.Parse(txt_id_cidade.Text));

                lst_ceps.ItemsSource = arr_bairros;
            }
            catch (Exception ex)
            {
                await DisplayAlert("OPS", ex.Message, "OK");

            }
            finally
            {
                carregando.IsRunning = false;
            }
        }
    }
}