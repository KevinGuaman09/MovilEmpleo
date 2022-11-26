using Newtonsoft.Json;
using System;
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
    public partial class Postulante : ContentPage
    {
        private const string Url = "http://192.168.3.41:6060/movilempleopos/post.php";
        private readonly HttpClient postulante = new HttpClient();
        private ObservableCollection<MovilEmpleo.WebServices.Postulante> _post;
        public Postulante()
        {
            InitializeComponent();
            getAll();
        }
        public async void getAll()
        {
            var content = await postulante.GetStringAsync(Url);
            List<MovilEmpleo.WebServices.Postulante> posts = JsonConvert.DeserializeObject<List<MovilEmpleo.WebServices.Postulante>>(content);
            _post = new ObservableCollection<MovilEmpleo.WebServices.Postulante>(posts);
            MyList.ItemsSource = _post;
        }

        private async void btnIng_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IngresoPostulante());
        }
    }
}