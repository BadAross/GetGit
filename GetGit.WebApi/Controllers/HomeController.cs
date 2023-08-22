using Microsoft.AspNetCore.Mvc;

[Controller]
public class HomeController : Controller
{

    public async Task<IActionResult> Index(string searchString, CancellationToken cancellationToken)
    {
        var vm = new List<Project>();
        if (!string.IsNullOrEmpty(searchString))
        {
            ViewData["Search"] = searchString;
            var x = new GetProjectListQueryHandler(EFModel.dbContext);
            vm = x.Handle(searchString, cancellationToken);
        }
        return View(vm);
    }
}