using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Web.Domain
{
    public class Ingredient
    {
        public string? Name { get; set; }
        public int Amount { get; set; }
        public string? Unit { get; set; }
    }
}