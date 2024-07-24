using RecipeFinder.Model;
using RecipeFinder.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeFinder.ViewModel.Commands
{
    public class OpenClosePanelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public RecipeVM VM { get; set; }

        public OpenClosePanelCommand(RecipeVM vm)
        {
            VM = vm; 
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            
            VM.SavedRecipes.Clear();
            var table = SQLiteHelper.ReadRecipeTableDB();
            if (table == null) { }
            else
            {
                foreach (var r in table)
                {
                    VM.SavedRecipes.Add(r);
                }
            }



            VM.SidePanelControl();
        }
    }
}
