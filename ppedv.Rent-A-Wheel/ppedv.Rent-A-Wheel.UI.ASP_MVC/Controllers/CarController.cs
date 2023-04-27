using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.Rent_A_Wheel.Model.Contracts;
using ppedv.Rent_A_Wheel.Model.Domain;

namespace ppedv.Rent_A_Wheel.UI.ASP_MVC.Controllers
{
    public class CarController : Controller
    {
        private readonly IRepository repo;

        public CarController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: CarController
        public ActionResult Index()
        {
            return View(repo.GetAll<Car>());
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetById<Car>(id));
        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View(new Car() { Color = "gelb", KW = 300, Manufacturer = "NEW", Model = "NEW" });
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            try
            {
                repo.Add(car);
                repo.SaveAll();

                return RedirectToAction(nameof(Details),car);
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetById<Car>(id));
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car car)
        {
            try
            {
                repo.Update(car);
                repo.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetById<Car>(id));
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                repo.Delete<Car>(id);
                repo.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
