using System;
using System.Collections.Generic;
using ChatApp.FireDatabase;
using ChatApp.Model;
using Xamarin.Forms;

namespace ChatApp.Views
{
    public partial class AddRoomPage : ContentPage
    {
        public AddRoomPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            var databaseHelper = new DatabaseHelper();
            await databaseHelper.saveNewRoom(new Room
            {
                RoomName = rootName.Text
            });
            await Navigation.PopAsync();
        }
    }
}
