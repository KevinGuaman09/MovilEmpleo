using MovilEmpleo.WebServices;
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
    public partial class Empresa : ContentPage
    {
        private const string Url = "http://192.168.3.41:6060/movilempleoemp/post.php";
        private readonly HttpClient empresa = new HttpClient();
        private ObservableCollection<MovilEmpleo.WebServices.Empresa> _post;
        public Empresa()
        {
            InitializeComponent();
            getAll();
        }
        public async void getAll()
        {
            var content = await empresa.GetStringAsync(Url);
            List<MovilEmpleo.WebServices.Empresa> posts = JsonConvert.DeserializeObject<List<MovilEmpleo.WebServices.Empresa>>(content);
            _post = new ObservableCollection<MovilEmpleo.WebServices.Empresa>(posts);
            MyList.ItemsSource = _post;
        }

        private async void btnIng_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IngresoEmpresa());
        }
    }
}