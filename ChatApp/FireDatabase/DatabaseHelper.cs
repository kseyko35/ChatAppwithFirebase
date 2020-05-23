using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Model;
using Firebase.Database;
using Firebase.Database.Query;

namespace ChatApp.FireDatabase
{
    public class DatabaseHelper
    {
        FirebaseClient client;

        public DatabaseHelper()
        {
           client = new FirebaseClient("https://xamarinfirst-440bf.firebaseio.com/"); 
        }

        public async Task<List<Room>> getRoomListAsync()
        {
            return (await client.Child("ChatRoom").OnceAsync<Room>()).Select((item) => new Room
            {
                Key = item.Key,
                RoomName = item.Object.RoomName
            }).ToList();
          
        }

        public async Task saveNewRoom(Room room)
        {
          await  client.Child("ChatRoom").PostAsync(room);
        }

        public async Task saveMessage(Chat chat,string room)
        {
            await client.Child("ChatRoom/" + room + "/Message").PostAsync(chat);
        }

        public ObservableCollection<Chat> subChat(string roomKey)
        {
           
            return client.Child("ChatRoom/" + roomKey + "/Message")
                .AsObservable<Chat>()
                .AsObservableCollection<Chat>();
        }
      
    } 
}
