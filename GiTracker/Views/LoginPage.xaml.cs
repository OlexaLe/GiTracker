using System;

namespace GiTracker.Views
{
    public partial class LoginPage : BasePage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginEntry_OnCompleted(object sender, EventArgs e)
        {
            PasswordEntry.Focus();
        }

        private void PasswordEntry_OnCompleted(object sender, EventArgs e)
        {
            LoginButton.Command.Execute(LoginButton.CommandParameter);
        }

        private void OnSwitchLabelTapped(object sender, EventArgs e)
        {
            ShowPasswordSwitch.IsToggled = !ShowPasswordSwitch.IsToggled;
        }
    }
}