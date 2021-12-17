using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ExamenTercerParcial.Modelos;
using SQLite;

namespace ExamenTercerParcial
{
    public partial class MainPage : ContentPage
    {
        public DateTime fech;
        public MainPage()
        {
            InitializeComponent();
        }

        private void fecha_DateSelected(object sender, DateChangedEventArgs e)
        {
            fech = e.NewDate;
            var observar = e.NewDate.ToString();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (CamposVacios())
            {
                Pagos pago = new Pagos
                {
                    Descripcion = txtDescripcion.Text,
                    Monto = (double)Convert.ToDecimal(txtMonto.Text),
                    //Photo_recibo = pathBase64,
                    Fecha = Convert.ToString(fech),
                };
                await App.SQLiteDB.GuardarPago(pago);

                await DisplayAlert("Registro", "Datos guardados correctamente", "ok");
                txtDescripcion.Text = "";
                txtMonto.Text = "";
            }
            else
            {
                await DisplayAlert("Error", "No debe de dejar campos vacios", "ok");
            }
        }

        public bool CamposVacios()
        {
            bool data;

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                data = false;
            }

            else if (String.IsNullOrEmpty(txtMonto.Text))
            {
                data = false;
            }

            else
            {
                data = true;
            }
            return data;

        }
        private async void btnListaPagos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new listaPagos());
        }
    }
}
