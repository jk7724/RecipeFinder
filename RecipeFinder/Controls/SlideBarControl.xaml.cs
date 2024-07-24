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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeFinder.Controls
{
    /// <summary>
    /// Interaction logic for SlideBarControl.xaml
    /// </summary>
    public partial class SlideBarControl : UserControl
    {


        public Recipe Recipe
        {
            get { return (Recipe)GetValue(RecipeProperty); }
            set { SetValue(RecipeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for recipe.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RecipeProperty =
            DependencyProperty.Register("Recipe", typeof(Recipe), typeof(SlideBarControl), new PropertyMetadata(null, SetText));

        // This method updates the UI elements with the new values from the Recipe object.
        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SlideBarControl control = d as SlideBarControl;

            if (control != null)
            {
                // This method updates the UI elements with the new values from the Recipe object.
                control.Image.Source = new BitmapImage(new Uri((e.NewValue as Recipe).image));
                control.Label.Text = (e.NewValue as Recipe).label;

            }
        }
        public SlideBarControl()
        {
            InitializeComponent();
        }
    }
}
