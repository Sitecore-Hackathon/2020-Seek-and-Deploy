using System.Diagnostics;
using System.Web.Mvc;
using Meetcore.Feature.Categories.Services;
using Sitecore.Mvc.Presentation;

namespace Meetcore.Feature.Categories.Controllers
{
    public class CategoriesController : Controller
    {
        protected readonly ICategoryRepository CategoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            Debug.Assert(categoryRepository != null);
            CategoryRepository = categoryRepository;
        }

        public ActionResult List()
        {
            var catRoot = RenderingContext.Current.ContextItem;
            var categories = CategoryRepository.GetCategories(catRoot);
            return View(categories);
        }
    }
}