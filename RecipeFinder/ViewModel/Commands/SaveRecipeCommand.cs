using RecipeFinder.Model;
using RecipeFinder.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeFinder.ViewModel.Commands
{
    public class SaveRecipeCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public RecipeVM VM { get; set; }
        public SaveRecipeCommand(RecipeVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var test = VM.SelectedRecipe;

            SQLiteHelper.CreateUpdateDB(test);

            
        }
    }
}
