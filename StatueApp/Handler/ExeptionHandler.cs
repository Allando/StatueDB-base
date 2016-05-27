using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace StatueApp.Handler
{
    public class ExeptionHandler
    {
        public static async void ShowExeptonError(string message)
        {
            string msg = message;
            var messageBox = new MessageDialog(msg);
            await messageBox.ShowAsync();
        }
        public static async void ShowExeptonError(string message, string ExeptionMessage)
        {
            string msg = message + ": " + ExeptionMessage;
            var messageBox = new MessageDialog(msg);
            await messageBox.ShowAsync();
        }

    }
}
