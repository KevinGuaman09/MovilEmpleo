using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace MovilEmpleo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngresoPostulante : ContentPage
    {
        public IngresoPostulante()
        {
            InitializeComponent();
            var insAcademica = new List<string>();
            insAcademica.Add("Primaria");
            insAcademica.Add("Secundaria");
            insAcademica.Add("Bachiller");
            insAcademica.Add("Universidad");
            insAcademica.Add("Tercer Nivel");
            insAcademica.Add("Cuarto Nivel");
            pckInstruccion.ItemsSource = insAcademica;


        }
        public async void GetLocation()
        {
            Location location = await Geolocation.GetLastKnownLocationAsync();
            if (location==null)
            {
                location = await Geolocation.GetLocationAsync(new GeolocationRequest
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(30)
                }); ;
            }
            lblLocation.Text = "Lat: " + location.Latitude.ToString() + "Long: " + location.Longitude.ToString();
        }
 

        private async void btnInsert_Clicked(object sender, EventArgs e)
        {
            WebClient clientPos = new WebClient();
            try
            {
                var param = new System.Collections.Specialized.NameValueCollection();
                param.Add("id_postulante", "");
                param.Add("nombre", txtNombre.Text);
                param.Add("apellido", txtApellido.Text);
                param.Add("instruccion", pckInstruccion.SelectedItem.ToString());
                param.Add("email", txtEmail.Text);
                param.Add("edad", txtEdad.Text);
                param.Add("identificacion", txtIdenti.Text);
                param.Add("descripcion", txtTitulo.Text);
                param.Add("experiencia", txtExperiencia.Text);
                clientPos.UploadValues("http://192.168.3.41:6060/movilempleopos/post.php", "POST", param);
                //DisplayAlert("postulante creado",clientPos.ToString(),"cerrar");
                await Navigation.PushAsync(new TabbPage());
                var mensaje = "Postulante ingresado";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);
            }
            catch (Exception ex)
            {
                await DisplayAlert("error", ex.Message, "cerrar");
            }
        }
   
        private async  void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabbPage());
        }

        private void btnLocation_Clicked(object sender, EventArgs e)
        {
            GetLocation();
        }
    }
}