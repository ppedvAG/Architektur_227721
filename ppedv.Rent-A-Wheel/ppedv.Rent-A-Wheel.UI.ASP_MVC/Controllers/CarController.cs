using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.Rent_A_Wheel.Model.Contracts;
using ppedv.Rent_A_Wheel.Model.Domain;

namespace ppedv.Rent_A_Wheel.UI.ASP_MVC.Controllers
{
    public class CarController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CarController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        // GET: CarController
        public ActionResult Index()
        {
            return View(unitOfWork.CarRepository.GetAll());
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View(unitOfWork.CarRepository.GetById(id));
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
                unitOfWork.CarRepository.Add(car);
                unitOfWork.SaveAll();

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
            return View(unitOfWork.CarRepository.GetById(id));
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car car)
        {
            try
            {
                unitOfWork.CarRepository.Update(car);
                unitOfWork.SaveAll();
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
            return View(unitOfWork.CarRepository.GetById(id));
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                unitOfWork.CarRepository.Delete(id);
                unitOfWork.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
