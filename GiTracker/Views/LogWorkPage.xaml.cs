using System;

namespace GiTracker.Views
{
    public partial class LogWorkPage : BasePage
    {
        public LogWorkPage()
        {
            InitializeComponent();
        }

        private void TimeSpentEntry_OnCompleted(object sender, EventArgs e)
        {
            LogButton.Command.Execute(LogButton.CommandParameter);
        }
    }
}