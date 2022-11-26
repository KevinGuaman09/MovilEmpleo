using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using System.Collections;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovilEmpleo.Models;

namespace MovilEmpleo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }
        public static IEnumerable<Usuarios> SELECT_WHERE(SQLiteConnection db, string usuario, string password)
        {
            return db.Query<Usuarios>("SELECT * FROM USUARIOS WHERE USUARIO=? AND PASSWORD=?", usuario, password);
        }

        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "login.db");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<Usuarios>();
                IEnumerable<Usuarios> result = SELECT_WHERE(db, txtUsuario.Text, txtPassword.Text);
                if (result.Count() > 0)
                {
                  await Navigation.PushAsync(new TabbPage());
                    var mensaje = "Usuario autorizado";
                    DependencyService.Get<Mensaje>().LongAlert(mensaje);
                }
                else
                {
                    await DisplayAlert("Error", "User no existe", "cerrar");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }


    }
}