using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;
using System;
using Behaviors.Models;

namespace Behaviors.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registeration : ContentPage
    {
        public Registeration()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            var dpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "UserDatabase.db");
            var db = new SQLiteConnection(dpath);
            db.CreateTable<Person>();

            var item = new Person()
            {
                Name = txtName.Text,
                Username = txtUName.Text,
                Password = txtPass.Text
            };
            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Congratulations", "User Registration Successful", "Yes", "Cancel");

                if (result)
                {
                    await Navigation.PushAsync(new Login());
                }
            });

        }
    }
}