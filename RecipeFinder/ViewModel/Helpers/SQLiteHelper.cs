using RecipeFinder.Model;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace RecipeFinder.ViewModel.Helpers
{
    public class SQLiteHelper
    {
        // Database file name and path
        static string databaseName = "RecipeFinder.db";
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);


        // Method to create or update the database with a Recipe object
        public static void CreateUpdateDB(Recipe recipe)
        {
            using(SQLiteConnection connection = new SQLiteConnection(databasePath))
            {

                // Create tables if they do not exist
                connection.CreateTable<Recipe>();
                connection.CreateTable<TotalNutrients>();
                connection.CreateTable<ENERCKCAL>();
                connection.CreateTable<FAT>();
                connection.CreateTable<FASAT>();
                connection.CreateTable<CHOCDF>();
                connection.CreateTable<SUGAR>();
                connection.CreateTable<PROCNT>();
                connection.CreateTable<FE>();

                // Insert the Recipe and related TotalNutrients data into the tables
                connection.Insert(recipe);
                connection.Insert(recipe.totalNutrients);
                connection.Insert(recipe.totalNutrients.FAT);
                connection.Insert(recipe.totalNutrients.ENERC_KCAL);
                connection.Insert(recipe.totalNutrients.FASAT);
                connection.Insert(recipe.totalNutrients.CHOCDF);
                connection.Insert(recipe.totalNutrients.SUGAR);
                connection.Insert(recipe.totalNutrients.PROCNT);
                connection.Insert(recipe.totalNutrients.FE);

                // Update the Recipe and TotalNutrients data with children
                connection.UpdateWithChildren(recipe);
                connection.UpdateWithChildren(recipe.totalNutrients);

            }

             

        }

        // Method to read all record from the Recipe table
        public static List<Recipe> ReadRecipeTableDB()
        {

            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                var table = new List<Recipe>();
                try
                {
                    table = connection.GetAllWithChildren<Recipe>();
                    return table;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }

            }
        }

        // Method to read TotalNutrients of a specific recipe
        public static TotalNutrients ReadTotalNutrients(Recipe recipe)
        {
            using (SQLiteConnection connection = new SQLiteConnection(databasePath))
            {
                try
                {
                    return connection.GetWithChildren<TotalNutrients>(recipe.TotalNutrientsId);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }

                
        }

    

        //Delete all tables
        public static void DestroyDB()
        {
            
            try
            {
                // Check if the file exists
                if (File.Exists(databasePath))
                {
                    // Delete the database file
                    File.Delete(databasePath);
                    Console.WriteLine("Database file deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Database file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to delete the database file: " + ex.Message);
            }

            



        }
    }
}
