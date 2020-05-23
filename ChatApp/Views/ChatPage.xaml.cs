using System;
using System.Collections.Generic;
using ChatApp.Design;
using ChatApp.FireDatabase;
using ChatApp.Model;
using Xamarin.Forms;

namespace ChatApp.Views
{
    public partial class ChatPage : ContentPage
    {
        DatabaseHelper helper = new DatabaseHelper();
        Room room = new Room();
        public ChatPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<RoomPage,Room>(this, "RoomObject", (page, data) => {
                room = data;
                mChatList.BindingContext = helper.subChat(data.Key);
                MessagingCenter.Unsubscribe<RoomPage, Room>(this, "RoomObject");
            });

        }

        async void onSendMessage(System.Object sender, System.EventArgs e)
        {
         
            var chatObject = new Chat { UserMessage=mEntryMessage.Text , UserName= User.userName};
            await helper.saveMessage(chatObject, room.Key);
            mEntryMessage.Text = "";
            //helper.saveMessage(mEntryMessage.Text);
            
        }
    }
}
