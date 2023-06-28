using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeApi.Web.Requests;

namespace RecipeApi.Web.Domain {
    public class Recipe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Recipe (int id, RecipeRequest request)
        {
            if(request == null)
            {
                return;
            }

            if(id == 0) { id = 1;  }
            Id = id;
            Name = request.Name;
            Ingredients = request.Ingredients;
            Description = request.Description;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}