using Microsoft.AspNetCore.Mvc;
using ProdManagment.Interfaces;
using ProdManagment.Models;

namespace ProdManagment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //[HttpGet("{id}")]
        //public ActionResult GetCategory([FromBody] int id)
        //{
        //    var category = _categoryService.GetCategory(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(category);
        //}

        [HttpPost("createCategory")]
        public CreateCategoryResponse CreateCategory(CategoryModel request) => _categoryService.CreateCategory(request);
        //public async Task<CreateCategoryResponse> CreateCategory(CategoryModel request)
        //{
        //    return await _categoryService.CreateCategory(request);
        //}
        //[HttpPost("getCategory")]
        //public GetCategoryResponse GetChannels(GetCategoryRequest request) => _categoryService.GetCategory(request);

        [HttpPost("getCategory")]
        public ActionResult GetCategory(GetCategoryRequest request)
        {
            var category = _categoryService.GetCategory(request);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
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

        [HttpDelete("deleteCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public DeleteCategoryResponse Delete(DeleteCategoryRequest request) => _categoryService.DeleteCategory(request);


        [HttpPost("updateCategory")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public UpdateCategoryResponse Update(UpdateCategoryRequest request) => _categoryService.UpdateCategory(request);


        //[HttpGet("{id}")]
        //[ProducesResponseType(typeof(CategoryEntity), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var issue = await _context.Categories.FindAsync(id);
        //    return issue == null ? NotFound() : Ok(issue);
        //}

        //public async Task Delete(int id)
        //{
        //    var bookToDelete = await _context.Books.FindAsync(id);
        //    _context.Books.Remove(bookToDelete);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task Update(Book book)
        //{
        //    _context.Entry(book).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //}
    }
}