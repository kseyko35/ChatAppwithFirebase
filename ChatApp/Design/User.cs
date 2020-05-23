using System;
namespace ChatApp.Design
{
    public class User
    { // Use singleton pattern
        private static string uid;
        //private object myProperty;//Encapsulation

        //public object MyProperty { get => myProperty; set => myProperty = value; }



        public static string userName
        {
            get { return uid; }
            set { uid = value; }
        }

        public User()
        {
        }
    }
}
