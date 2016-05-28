using System;
using Windows.UI.Popups;

namespace StatueApp.Handler
{
    public class ExceptionHandler
    {
        /// <summary>
        /// Denne metode viser en text box med en valgt fejl
        /// </summary>
        /// <param name="message"></param>
        public static async void ShowExceptionError(string message)
        {
            var messageBox = new MessageDialog(message);
            await messageBox.ShowAsync();
        }
    }
}
