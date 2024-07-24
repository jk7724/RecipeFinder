using Newtonsoft.Json;
using RecipeFinder.Model;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder.ViewModel.Helpers
{
    public class RecipeFinderHelpers
    {
        // Constants for the base URL and API keys for Edamam recipe API
        public const string BASE_URL = "https://api.edamam.com/api/recipes/v2";
        public const string APP_ID = "3898dffe";
        public const string APP_KEY = "be9bf6979a02827ef30e612ae93ea9e9";
        public const string RECIPE_SEARCH_ENDPOINT = "?type=public&q={0}&app_id={1}&app_key={2}";


        // Get list of recipe based on a search query
        public static async Task<Example> GetRecipe(string query)
        {
            Example recipe = new Example();

            string url = BASE_URL + string.Format(RECIPE_SEARCH_ENDPOINT, query, APP_ID, APP_KEY);

            using(HttpClient client = new HttpClient())
            {
                // Send the GET request to the API
                var response = await client.GetAsync(url);
                // Read the response content as a string
                string json = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON string into an Example object
                recipe = JsonConvert.DeserializeObject<Example>(json);

                return recipe;
            }
        }
    }
}
