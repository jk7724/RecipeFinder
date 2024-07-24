using RecipeFinder.Model;
using RecipeFinder.View;
using RecipeFinder.ViewModel.Commands;
using RecipeFinder.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace RecipeFinder.ViewModel
{
    public class RecipeVM : INotifyPropertyChanged
    {
        public SearchCommand SearchCommand { get; set; }
        public OpenRecipeCommand OpenRecipeCommand { get; set; }
        public SaveRecipeCommand SaveRecipeCommand { get; set; }
        public BackCommand BackCommand { get; set; }
        public OpenClosePanelCommand OpenClosePanelCommand { get; set; }
        public ObservableCollection<Recipe> SavedRecipes { get; set; }
        public ObservableCollection<Recipe> Recipes { get; set; }
        public ObservableCollection<INutrient> Nutrients { get; set; }

        private int nRecipesDisplay { get; set; }

        private string query;
        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged("Query");
            }
        }
        
        private Recipe selectedRecipe;

        public Recipe SelectedRecipe
        {
            get { return selectedRecipe; }
            set 
            {   selectedRecipe = value;
                OnPropertyChanged("SelectedRecipe");
                GetNutrient(selectedRecipe.totalNutrients);
                (Application.Current.MainWindow as RecipeFinderWindow).goToViewRecipeW();
                
            }
        }
        private Recipe selectedSavedRecipe;

        public Recipe SelectedSavedRecipe
        {
            get { return selectedSavedRecipe; }
            set 
            {   selectedSavedRecipe = value;
                OnPropertyChanged("SelectedSavedRecipe");
                value.totalNutrients = SQLiteHelper.ReadTotalNutrients(selectedSavedRecipe);
                SelectedRecipe = value;
                
            }
        }

        // Constructor for the RecipeVM class
        public RecipeVM()
        {
            // Initialize commands
            SearchCommand = new SearchCommand(this);
            OpenRecipeCommand = new OpenRecipeCommand(this);
            SaveRecipeCommand = new SaveRecipeCommand(this);
            BackCommand = new BackCommand(this);
            OpenClosePanelCommand = new OpenClosePanelCommand(this);

            // Initialize ObservableCollection properties
            Recipes = new ObservableCollection<Recipe>();
            Nutrients = new ObservableCollection<INutrient>();
            SavedRecipes = new ObservableCollection<Recipe>();

            // Initialize the number of recipes to display
            nRecipesDisplay = 20;


        }

        // Method to populate the Nutrients collection with specific nutrient values
        public void GetNutrient(TotalNutrients nutrients)
        {
            Nutrients.Clear();

            Nutrients.Add(nutrients.ENERC_KCAL);
            Nutrients.Add(nutrients.FAT);
            Nutrients.Add(nutrients.FASAT);
            Nutrients.Add(nutrients.PROCNT);
            Nutrients.Add(nutrients.CHOCDF);
            Nutrients.Add(nutrients.FE);
            Nutrients.Add(nutrients.SUGAR);
        }

        // method to make a query for recipes
        public async void MakeQuery()
        {
            // Get recipes from the RecipeFinderHelpers using the query
            var recipe = await RecipeFinderHelpers.GetRecipe(query);

            Recipes.Clear();


            foreach(var d in recipe.hits)
            {
                // Combine all ingredient lines into a single string to store in database
                foreach (var line in d.recipe.ingredientLines) 
                {
                    d.recipe.allingredients = d.recipe.allingredients + line + "\n";
                }
                // Add the recipe to the Recipes collection
                Recipes.Add(d.recipe);

                //display only fixed number of recipe
                if (Recipes.Count() == nRecipesDisplay) break;
                  
            }
           
        }

        // Method to control the side panel (open or close) based on its current state
        public void SidePanelControl()
        {
            // Variable to store the mode of operation (open or close)
            string mode = null;

            var mainWindow = (Application.Current.MainWindow as RecipeFinderWindow);

            var margin = mainWindow.SidePanel.Margin.Left;

            // Determine the mode based on the current margin
            if (margin == 0)
            {
                mode = "ClosePanel";
            }
            else if (margin == -250)
            {
                mode = "OpenPanel";
            }

            // Retrieve the storyboard from resources using the determined mode
            Storyboard storyboard = (Storyboard)mainWindow.Resources[mode];
            // Begin the storyboard animation
            storyboard.Begin();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
