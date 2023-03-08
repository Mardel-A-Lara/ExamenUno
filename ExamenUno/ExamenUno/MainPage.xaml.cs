using ExamenUno.Data;
using ExamenUno.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace ExamenUno
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

       

       
        private async void btnsalvarubicacion_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Class1 uno = new Class1
                {
                    latitud = txtlatitud.Text,
                    idlongitud= txtidlongitud.Text,
                    du=txtdu.Text,
                    descripcioncorta=txtdescripcioncorta.Text,

                };
                await App.SQLiteBD.SaveClass1Async(uno);
                txtlatitud.Text = "";
                txtidlongitud.Text = "";
                txtdu.Text = "";
                txtdescripcioncorta.Text = "";
                await DisplayAlert("Registro", "su ubicacion se guardo exitosamente", "ok");

                var unolist = await App.SQLiteBD.GetClass1Async();

                if(unolist!=null)
                {
                  lslatitud.ItemsSource=unolist;
                }
            }
            else
            {
                await DisplayAlert("Error", "Ingresar todos los datos", "ok");

            }
        }

        public bool validarDatos()
        {
            bool respuesta;
            if(string.IsNullOrEmpty(txtlatitud.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtidlongitud.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtdu.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtdescripcioncorta.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;   
        }

        private async void btnabrir_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(txtlatitud.Text, out double lat))
                return;
            if (!double.TryParse(txtidlongitud.Text, out double lng))
                return;
                await Map.OpenAsync(lat, lng, new MapLaunchOptions
                {
                    Name = txtdescripcioncorta.Text,
                    NavigationMode=NavigationMode.None


                });

        }
    }
}
