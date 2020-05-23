using System;
using System.Collections.Generic;
using ChatApp.Design;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace ChatApp.PopUp
{
    public partial class CustomPopup : PopupPage
    {
        public CustomPopup()
        {
            InitializeComponent();
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            User.userName = mUserName.Text;
            Navigation.PopPopupAsync();
        }
    }
}
