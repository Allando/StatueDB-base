using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StatueApp.Model;

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

        private void ListBoxStoneMatrial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSingletonMaterials(e);
        }
        private void ListBoxOtherMatrial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSingletonMaterials(e);
        }
        private void ListBoxMetalMatrial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSingletonMaterials(e);
        }
        private void ListBoxPlacement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSingletonPlacements(e);
        }
        private void ListBoxStatueType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSingletonStatueTypes(e);
        }
        private void ComboBoxCv_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateSingletonCulturalValues(e);
        }

        /// <summary>
        /// Tilføjer/fjerner materialer til statue singleton listen
        /// </summary>
        /// <param name="e"></param>
        private void PopulateSingletonMaterials(SelectionChangedEventArgs e)
        {
            foreach (modelMaterial removedItem in e.RemovedItems)
            {
                ViewModel.ViewModelCreateStatue.NewStatue.Materials.Remove(removedItem);
            }
            foreach (modelMaterial addedItem in e.AddedItems)
            {
                ViewModel.ViewModelCreateStatue.NewStatue.Materials.Add(addedItem);
            }
        }

        /// <summary>
        /// Tilføjer/fjerner placering til statue singleton listen
        /// </summary>
        /// <param name="e"></param>
        private void PopulateSingletonPlacements(SelectionChangedEventArgs e)
        {
            foreach (modelPlacement removedItem in e.RemovedItems)
            {
                ViewModel.ViewModelCreateStatue.NewStatue.Placements.Remove(removedItem);
            }
            foreach (modelPlacement addedItem in e.AddedItems)
            {
                ViewModel.ViewModelCreateStatue.NewStatue.Placements.Add(addedItem);
            }
        }

        /// <summary>
        /// Tilføjer/fjerner statue type til statue singleton listen
        /// </summary>
        /// <param name="e"></param>
        private void PopulateSingletonStatueTypes(SelectionChangedEventArgs e)
        {
            foreach (modelStatueType removedItem in e.RemovedItems)
            {
                ViewModel.ViewModelCreateStatue.NewStatue.StatueTypes.Remove(removedItem);
            }
            foreach (modelStatueType addedItem in e.AddedItems)
            {
                ViewModel.ViewModelCreateStatue.NewStatue.StatueTypes.Add(addedItem);
            }
        }

        /// <summary>
        /// Tilføjer/fjerner kulturel værdi til statue singleton listen
        /// </summary>
        /// <param name="e"></param>
        private void PopulateSingletonCulturalValues(SelectionChangedEventArgs e)
        {
            foreach (modelCulturalValue removedItem in e.RemovedItems)
            {
                ViewModel.ViewModelCreateStatue.NewStatue.CulturalValues.Remove(removedItem);
            }
            foreach (modelCulturalValue addedItem in e.AddedItems)
            {
                ViewModel.ViewModelCreateStatue.NewStatue.CulturalValues.Add(addedItem);
            }
        }

        //private void MatrialeKlik()
        //{
        //    StackPanelMatrialer.Visibility = Visibility.Visible;
        //    StackPanelPlacering.Visibility = Visibility.Collapsed;
        //    StackPanelType.Visibility = Visibility.Collapsed;
        //    StackPanelCv.Visibility = Visibility.Collapsed;
        //}

        //private void PlaceringsKlik()
        //{
        //    StackPanelMatrialer.Visibility = Visibility.Collapsed;
        //    StackPanelPlacering.Visibility = Visibility.Visible;
        //    StackPanelType.Visibility = Visibility.Collapsed;
        //    StackPanelCv.Visibility = Visibility.Collapsed;
        //}

    }
}
