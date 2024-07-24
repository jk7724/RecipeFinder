using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RecipeFinder.Model
{
    [Table("ENERCKCAL")]
    public class ENERCKCAL : INutrient //Energy
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }
    [Table("FAT")]
    public class FAT :INutrient //Fat
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }
    [Table("FASAT")]
    public class FASAT :INutrient //Saturates
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }
    [Table("CHOCDF")]
    public class CHOCDF :INutrient//CARB
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }
    [Table("SUGAR")]
    public class SUGAR :INutrient//sugar
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }
    [Table("PROCNT")]
    public class PROCNT :INutrient //protein
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }
    [Table("FE")]
    public class FE :INutrient //fibre
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string label { get; set; }
        public double quantity { get; set; }
        public string unit { get; set; }
    }

    [Table("TotalNutrients")]
    public class TotalNutrients
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(ENERCKCAL))]
        public int ENERCKCALId { get; set; }
        [OneToOne]
        public ENERCKCAL ENERC_KCAL { get; set; }

        [ForeignKey(typeof(FAT))]
        public int FATId { get; set; }
        [OneToOne]
        public FAT FAT { get; set; }
        [ForeignKey(typeof(FASAT))]
        public int FASATId { get; set; }

        [OneToOne]
        public FASAT FASAT { get; set; }

        [ForeignKey(typeof(CHOCDF))]
        public int CHOCDFLId { get; set; }
        [OneToOne]
        public CHOCDF CHOCDF { get; set; }

        [ForeignKey(typeof(SUGAR))]
        public int SUGARLId { get; set; }
        [OneToOne]
        public SUGAR SUGAR { get; set; }

        [ForeignKey(typeof(PROCNT))]
        public int PROCNTLId { get; set; }
        [OneToOne]
        public PROCNT PROCNT { get; set; }
        [ForeignKey(typeof(FE))]
        public int FELId { get; set; }
        [OneToOne]
        public FE FE { get; set; }
        
    }
    
    [Table("Recipes")]
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id {get; set;}
        public string label { get; set; }
        public string image { get; set; }
        public string url { get; set; }
        [Ignore]
        public IList<string> ingredientLines { get; set; }
        public string allingredients { get; set; }
        [Ignore]
        public IList<string> cuisineType { get; set; }
        [Ignore]
        public IList<string> mealType { get; set; }
        [Ignore]
        public IList<string> dishType { get; set; }
        [ForeignKey(typeof(TotalNutrients))]
        public int TotalNutrientsId { get; set; }

        [OneToOne]
        public TotalNutrients totalNutrients { get; set; }
      
    }

    public class Hit
    {
        public Recipe recipe { get; set; }
    }

    //Root class
    public class Example
    {
        public int from { get; set; }
        public int to { get; set; }
        public int count { get; set; }
        public IList<Hit> hits { get; set; }
    }

}
