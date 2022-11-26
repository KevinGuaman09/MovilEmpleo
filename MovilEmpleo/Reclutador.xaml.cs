using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovilEmpleo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Reclutador : ContentPage
    {
        private const string Url = "http://192.168.3.41:6060/movilempleorec/post.php";
        private readonly HttpClient reclutador = new HttpClient();
        private ObservableCollection<MovilEmpleo.WebServices.Reclutador> _post;
        public Reclutador()
        {
            InitializeComponent();
            getAll();
        }
        public async void getAll()
        {
            var content = await reclutador.GetStringAsync(Url);
            List<MovilEmpleo.WebServices.Reclutador> posts = JsonConvert.DeserializeObject<List<MovilEmpleo.WebServices.Reclutador>>(content);
            _post = new ObservableCollection<MovilEmpleo.WebServices.Reclutador>(posts);
            MyList.ItemsSource = _post;
        }

        private async void btnIng_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IngresoReclutador());
        }
    }
}