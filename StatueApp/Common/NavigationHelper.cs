using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StatueApp.Common
{
    class NavigationHelper
    {
        private static Frame _frame;

        public static void navigate(Type page)
        {
            _frame = (Window.Current.Content as Frame);
            _frame.Navigate(page);
        }
    }
}
