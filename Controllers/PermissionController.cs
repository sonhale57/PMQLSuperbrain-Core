using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMQLSuperbrain_Core.Models;

namespace PMQLSuperbrain_Core.Controllers
{
    public class PermissionController : Controller
    {
        SuperbrainDbContext db = new SuperbrainDbContext();
        public async Task<IActionResult> Index()
        {
            List<CustomPermission> model = new List<CustomPermission>();
            foreach (PermissionCategory cat in db.PermissionCategories.ToList())
            {
                model.Add(new CustomPermission
                {
                    Idcategory = cat.Id,
                    CategoryCode = cat.Ma,
                    CategoryName = cat.Name,
                    Permissions = db.Permissions.Where(x=>x.Idcategory == cat.Id).ToList()
                });
            }
            ViewBag.ProjectList = model;
            return View();

        }
    }
}
