using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeFinder.ViewModel.Commands
{
    public class SearchCommand : ICommand
    {
        public RecipeVM VM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public SearchCommand(RecipeVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.MakeQuery();

        }
    }
}
