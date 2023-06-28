using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Web.Domain;

namespace RecipeApi.Web.Requests
{
    public class RecipeRequest
    {
        public string? Name { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
        public string? Description { get; set; }        
    }
}