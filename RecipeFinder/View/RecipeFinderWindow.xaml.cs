using RecipeFinder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RecipeFinder.View
{
    /// <summary>
    /// Interaction logic for RecipeFinderWindow.xaml
    /// </summary>
    /// 
    // Main window of the aplication
    public partial class RecipeFinderWindow : Window
    {

        private ViewRecipeWindow _child;
        public RecipeFinderWindow()
        {
            InitializeComponent();
        }

        // Method to open the ViewRecipeWindow as a dialog
        public void goToViewRecipeW()
        {
            ViewRecipeWindow window2 = new ViewRecipeWindow();
            window2.Owner = this;
            this._child = window2;
            window2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window2.ShowDialog();
        }

        // Method to close the ViewRecipeWindow
        public void closeViewRecipeW()
        {
            _child.Close();
        }

    }
}
