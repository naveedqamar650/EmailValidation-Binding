using Android.Widget;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using Behaviors.Models;


namespace Behaviors.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            var dpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dpath);

            var query = db.Table<Person>().Where(u => u.Username.Equals(txtName.Text) && u.Password.Equals(txtPass.Text)).FirstOrDefault();

            if (query != null)
            {
                txtName.Text = "";
                txtPass.Text = "";
                Toast.MakeText(Android.App.Application.Context, "Good to Go...!", ToastLength.Long).Show();
            }
            else
            {
                txtName.Text = "";
                txtPass.Text = "";
                Toast.MakeText(Android.App.Application.Context, "Ops...! Wrong Credentials", ToastLength.Long).Show();
            }
        }

        public async void Gesture_Tap(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registeration());
        }

    }
}