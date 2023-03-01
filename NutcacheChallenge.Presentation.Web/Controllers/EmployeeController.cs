using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NutcacheChallenge.ClientConnection.Contract;
using NutcacheChallenge.Presentation.Web.Mapping;
using NutcacheChallenge.Presentation.Web.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NutcacheChallenge.Presentation.Web.Controllers
{
    public class EmployeeController : Controller
    {
        INutcacheServiceClient NutcacheServiceClient { get; }

        public EmployeeController(INutcacheServiceClient nutcacheServiceClient)
        {
            NutcacheServiceClient = nutcacheServiceClient;
        }

        public async Task<IActionResult> Index()
        {
            var data = await NutcacheServiceClient.GetAllEmployeesAsync();
            return View(data);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var data = await NutcacheServiceClient.GetEmployeeByIdAsync(id);
            ViewBag.Teams = GetTeams(data.Team);
            ViewBag.Genders = GetGenders(data.Gender);
            return View(data.Map());
        }

        [HttpPost]
        public async Task<IActionResult> Update(Employee employee)
        {
            var req = employee.Map();
            var data = await NutcacheServiceClient.UpdateEmployeeAsync(req);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewBag.Teams = GetTeams(null);
            ViewBag.Genders = GetGenders(null);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(Employee employee)
        {
            var req = employee.Map();
            var data = await NutcacheServiceClient.CreateEmployeeAsync(req);
            return RedirectToAction("Index");
        }

        public IActionResult ConfirmDelete(long id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            await NutcacheServiceClient.DeleteEmployeeAsync(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<SelectListItem> GetTeams(int? id)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem("Mobile", Convert.ToString((int)TeamEnum.Mobile)),
                new SelectListItem("Frontend", Convert.ToString((int)TeamEnum.Frontend)),
                new SelectListItem("Backend", Convert.ToString((int)TeamEnum.Backend)),
            };

            if (!id.HasValue) return items;

            var item = items.FirstOrDefault(i => i.Value == id.ToString());

            if (item != null) item.Selected = true;

            return items;
        }

        private List<SelectListItem> GetGenders(string? gender)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem("Gender 1", "Gender 1"),
                new SelectListItem("Gender 2", "Gender 2"),
                new SelectListItem("Gender 3", "Gender 3"),
                new SelectListItem("Gender 4", "Gender 4"),
            };

            if (gender == null) return items;

            var item = items.FirstOrDefault(i => i.Value == gender);

            if (item != null) item.Selected = true;

            return items;
        }
    }
}