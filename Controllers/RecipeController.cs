using Microsoft.AspNetCore.Mvc;
using RecipeApi.Web.Domain;
using RecipeApi.Web.Requests;
using JsonFlatFileDataStore;

namespace RecipeApi.Web.Controllers
{
    [ApiController]
    [Route("recipes")]
    public class RecipeController : ControllerBase
    {
        private readonly IDataStore _db;

        public RecipeController(IDataStore db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult GetAll ()
        {
            var recipes = GetCollection().AsQueryable();
            return Ok(recipes);
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult GetById (int id)
        {
            var recipe = GetCollection()
                .Find(r => r.Id == id)
                .FirstOrDefault();

            if (recipe == null)
            {
                return NotFound("Recipe not found");
            }
            return Ok(recipe);
        }

        [HttpPost]
        public ActionResult Create (RecipeRequest request)
        {
            IDocumentCollection<Recipe> collection = GetCollection();
            Recipe recipe = new Recipe(collection.GetNextIdValue(), request);
            GetCollection().InsertOne(recipe);

            return CreatedAtAction("GetById", new { id = recipe.Id }, recipe);
        }

        [HttpPut("{id}")]
        public ActionResult Update (int id, RecipeRequest request)
        {
            var didUpdate = GetCollection().UpdateOne(id, new
            {
                Name = request.Name,
                Ingredients = request.Ingredients,
                Description = request.Description,
                UpdatedAt = DateTime.Now
            });

            if (!didUpdate)
            {
                return NotFound($"Recipe {id} not found");
            }

            return Ok($"Recipe {id} updated");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete (int id)
        {
            var didDelete = GetCollection().DeleteOne(id);

            if (!didDelete)
            {
                return NotFound($"Recipe {id} not found");
            }

            return Ok($"Recipe {id} deleted");
        }

        private IDocumentCollection<Recipe> GetCollection()
        {
            return _db.GetCollection<Recipe>();
        }
    }
}