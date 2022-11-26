using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilEmpleo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngresoEmpresa : ContentPage
    {
        public IngresoEmpresa()
        {
            InitializeComponent();
        }

        private async void btnInsert_Clicked(object sender, EventArgs e)
        {
            WebClient clientPos = new WebClient();
            try
            {
                var param = new System.Collections.Specialized.NameValueCollection();
                param.Add("id_empresa", "");
                param.Add("nombre", txtNombre.Text);
                param.Add("descripcion", txtDesc.Text);

                clientPos.UploadValues("http://192.168.3.41:6060/movilempleoemp/post.php", "POST", param);
                //DisplayAlert("postulante creado",clientPos.ToString(),"cerrar");
                await Navigation.PushAsync(new TabbPage());
                var mensaje = "Empresa ingresada";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);
            }
            catch (Exception ex)
            {
                await DisplayAlert("error", ex.Message, "cerrar");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabbPage());
        }
    }
}