using Microsoft.AspNetCore.Mvc;
using ProdManagment.Interfaces;
using ProdManagment.Models;

namespace ProdManagment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICategoryService _categoryService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            ProdManagementContext context, 
            ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var issueToDelete = await _context.Categories.FindAsync(id);
        //    if (issueToDelete == null) return NotFound();

        //    _context.Categories.Remove(issueToDelete);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //public async Task<IActionResult> Create(CategoryEntity category)
        //{
        //    await _context.Categories.AddAsync(category);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        //}

        ////[HttpGet("{id}")]
        ////public ActionResult GetCategory([FromBody] int id)
        ////{
        ////    var category = _categoryService.GetCategory(id);
        ////    if (category == null)
        ////    {
        ////         return NotFound();
        ////    }
        ////    return Ok(category);
        ////} 
        

                [HttpPost("createCategory")]
        public CreateCategoryResponse CreateCategory(CategoryModel request) => _categoryService.CreateCategory(request);
        //public async Task<CreateCategoryResponse> CreateCategory(CategoryModel request)
        //{
        //    return await _categoryService.CreateCategory(request);
        //}
        //[HttpPost("getCategory")]
        //public GetCategoryResponse GetChannels(GetCategoryRequest request) => _categoryService.GetCategory(request);



        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(CategoryEntity), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var issue = await _context.Categories.FindAsync(id);
        //    return issue == null ? NotFound() : Ok(issue);
        //}
    }
}