using System;
using System.Collections.Generic;
using System.Threading;
using ChatApp.Design;
using ChatApp.FireDatabase;
using ChatApp.Model;
using ChatApp.PopUp;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace ChatApp.Views
{
    public partial class RoomPage : ContentPage
    {
        private DatabaseHelper database = new DatabaseHelper();

        public RoomPage()
        {
            InitializeComponent();
            Device.BeginInvokeOnMainThread(async() =>
            {
                 await Navigation.PushPopupAsync(new CustomPopup());
            });
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            mList.BindingContext =await database.getRoomListAsync();

        }

        void onAddRoom(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddRoomPage());
        }

        void onGetInfo(System.Object sender, System.EventArgs e)
        {
            DisplayAlert("Current user", User.userName, "Ok");
        }

        async void ListView_Refreshing(System.Object sender, System.EventArgs e)
        {
            mList.BindingContext = await database.getRoomListAsync();
            mList.IsRefreshing = false;
        }


        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () => {
                var result = await DisplayAlert("Uyarı!", "ChatAppdan'dan Çıkmak İstediğinize Emin Misiniz?", "Evet", "Hayır");
                if (result)
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    //Thread.CurrentThread.Abort();

                }
            });
            return true;
            //return base.OnBackButtonPressed();
        }

        void mList_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
          
            if(mList.SelectedItem != null)
            {
                var selectRoom = (Room)mList.SelectedItem;
                Navigation.PushAsync(new ChatPage());
                MessagingCenter.Send<RoomPage, Room>(this, "RoomObject", selectRoom);
           
             }
        }
    }
}
