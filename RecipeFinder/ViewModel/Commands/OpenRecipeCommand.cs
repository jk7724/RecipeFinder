using RecipeFinder.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeFinder.ViewModel.Commands
{
    public class OpenRecipeCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public RecipeVM VM { get; set; }
        public OpenRecipeCommand(RecipeVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var url = (parameter as Recipe).url;

            // Start a new process to open the URL of sellected Recipe.
            Process.Start(new ProcessStartInfo(url){ UseShellExecute = true });

        }
    }
}
