using RecipeFinder.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace RecipeFinder.ViewModel.Commands
{
    public class BackCommand : ICommand
    {
        public RecipeVM VM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public BackCommand(RecipeVM vm)
        {
            VM = vm;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            (Application.Current.MainWindow as RecipeFinderWindow).closeViewRecipeW();
        }
    }
}
