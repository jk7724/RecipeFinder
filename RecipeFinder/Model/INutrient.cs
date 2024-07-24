using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.Model
{
    // An interface for Nutient class (FAT, FASAT, SUGAR, PROTEIN etc.)
    public interface INutrient
    {
        string label { get; set; }
        double quantity { get; set; }
        public string unit { get; set; }
    }
}
