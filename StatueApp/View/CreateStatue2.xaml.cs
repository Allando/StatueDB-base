using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StatueApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateStatue2 : Page
    {
        public CreateStatue2()
        {
            this.InitializeComponent();
        }
        private void MatrialeKlik()
        {
            StackPanelMatrialer.Visibility = Visibility.Visible;
            StackPanelPlacering.Visibility = Visibility.Collapsed;
            StackPanelType.Visibility = Visibility.Collapsed;
            StackPanelCv.Visibility = Visibility.Collapsed;

        }
        private void PlaceringsKlik()
        {
            StackPanelMatrialer.Visibility = Visibility.Collapsed;
            StackPanelPlacering.Visibility = Visibility.Visible;
            StackPanelType.Visibility = Visibility.Collapsed;
            StackPanelCv.Visibility = Visibility.Collapsed;

        }

    }
}
