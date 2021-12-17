using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExamenTercerParcial.Modelos;
using SQLite;

namespace ExamenTercerParcial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class modificarPagos : ContentPage
    {
        public DateTime fech;
        public modificarPagos(Pagos p)
        {
            InitializeComponent();
            BindingContext = p;
        }


        public Pagos P { get; }

        private async void btnModificar_Clicked(object sender, EventArgs e)
        {
            Pagos pago = new Pagos
            {
                Id_pago = Convert.ToInt32(txtId.Text),
                Descripcion = txtDescripcion.Text,
                Monto = (double)Convert.ToDecimal(txtMonto.Text),
                //Photo_recibo = pathBase64,
                Fecha = Convert.ToString(fech),
            };
            if (await App.SQLiteDB.GrabarPago(pago) != 0)
            {
                await DisplayAlert("Registro", "Datos Modificados de manera correcta", "ok");
                await Navigation.PushAsync(new listaPagos());

            }
            else
            {
                await DisplayAlert("Registro", "Ha ocurrido un problema", "ok");
            }
        }
        private void fecha_DateSelected(object sender, DateChangedEventArgs e)
        {
            fech = e.NewDate;
            var observar = e.NewDate.ToString();
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool validacion = await DisplayAlert("Pregunta", "Esta seguro que desea eliminar este registro?", "Yes", "No");
            if (validacion == true) 
            {
                Pagos pago = new Pagos
                {
                    Id_pago = Convert.ToInt32(txtId.Text),
                    Descripcion = txtDescripcion.Text,
                    Monto = (double)Convert.ToDecimal(txtMonto.Text),
                    //Photo_recibo = pathBase64,
                    Fecha = Convert.ToString(fech),
                };
                if (await App.SQLiteDB.DropPagosAsync(pago) != 0)
                {
                    await DisplayAlert("Registro", "Datos Eliminados de manera correcta", "Ok");
                    await Navigation.PushAsync(new listaPagos());
                }
                else
                {
                    await DisplayAlert("Registro", "Ha ocurrido un problema", "ok");
                }
            }
        }
    }
}