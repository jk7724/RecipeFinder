using RecipeFinder.Model;
using RecipeFinder.ViewModel.Commands;
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
    /// Interaction logic for RecipeControl.xaml
    /// </summary>
    public partial class RecipeControl : UserControl
    {
        
        public Recipe Recipe
        {
            get { return (Recipe)GetValue(RecipeProperty); }
            set { SetValue(RecipeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Recipe.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RecipeProperty =
            DependencyProperty.Register("Recipe", typeof(Recipe), typeof(RecipeControl), new PropertyMetadata(null, SetText));


        // This method updates the UI elements with the new values from the Recipe object.
        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RecipeControl control = d as RecipeControl;

            if(control != null)
            {
                // Update the UI elements with the new values from the Recipe object
                control.FoodLabel.Text = (e.NewValue as Recipe).label;
                control.FoodImage.Source = new BitmapImage(new Uri((e.NewValue as Recipe).image));
                control.FoodIngredients.ItemsSource = (e.NewValue as Recipe).ingredientLines;
                
                if((e.NewValue as Recipe).cuisineType != null)
                {
                    control.FoodCuisine.Text = (e.NewValue as Recipe).cuisineType[0];

                }
                if ((e.NewValue as Recipe).mealType != null)
                {
                    control.FoodType.Text = (e.NewValue as Recipe).mealType[0];

                }
            }
        }

        public RecipeControl()
        {
            InitializeComponent();
            
        }
    }
}
