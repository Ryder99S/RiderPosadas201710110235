using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExamenTercerParcial.Modelos;

namespace ExamenTercerParcial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listaPagos : ContentPage
    {
        public listaPagos()
        {
            InitializeComponent();
            llenarLista();
        }

        public async void llenarLista()
        {
            var pagos = await App.SQLiteDB.GetPagoAync();
            if (pagos != null)
            {
                lisPagos.ItemsSource = pagos;
            }
            else
            {

            }
        }

        private async void lisPagos_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            bool validacion = await DisplayAlert("Pregunta", "Esta seguro que desea modificar este registro?", "Yes", "No");
            if(validacion == true)
            {
                Pagos item = (Pagos)e.Item;

                if (item != null)
                {
                    Pagos p = new Pagos
                    {
                        Id_pago = item.Id_pago,
                        Descripcion = item.Descripcion,
                        Monto = item.Monto,
                        Fecha = item.Fecha,
                    };
                    await Navigation.PushAsync(new modificarPagos(p));
                }
                //var mod = new modificarPagos();
                //mod.BindingContext = item;
                //await Navigation.PushAsync(mod);
            }
        }
    }
}