using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;
using MovilEmpleo.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SqlCliente))]
namespace MovilEmpleo.Droid
{
    public class SqlCliente : Database
    {
       

        public SQLiteAsyncConnection GetConnection()
        {
            var DocumentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(DocumentPath, "login.db");
            return new SQLiteAsyncConnection(path);
        }
    }
}