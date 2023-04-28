using Microsoft.AspNetCore.Mvc;
using ppedv.Rent_A_Wheel.API.REST.Model;
using ppedv.Rent_A_Wheel.Model.Contracts;
using ppedv.Rent_A_Wheel.Model.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.Rent_A_Wheel.API.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CarController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        private CarDTO MapCarToCarDTO(Car car)
        {
            var carDTO = new CarDTO
            {
                Id = car.Id,
                Manufacturer = car.Manufacturer,
                Model = car.Model,
                BuildYear = car.ManufacturingDate.Year, // Hier wird das Jahr des Herstellungsdatums verwendet
                PS = (int)(car.KW * 1.36) // Umrechnung von KW in PS
            };

            return carDTO;
        }

        private Car MapCarDTOToCar(CarDTO carDTO)
        {
            var car = new Car
            {
                Id= carDTO.Id,
                Manufacturer = carDTO.Manufacturer,
                Model = carDTO.Model,
                KW = (int)Math.Round(carDTO.PS / 1.36), // Umrechnung von PS in KW
                ManufacturingDate = new DateTime(carDTO.BuildYear, 1, 1) // Erstellt ein neues DateTime-Objekt mit dem angegebenen Jahr als Jahr
            };

            return car;
        }


        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<CarDTO> Get()
        {
            foreach (var car in unitOfWork.CarRepository.GetAll())
            {
                yield return MapCarToCarDTO(car);
            }
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public CarDTO Get(int id)
        {
            return MapCarToCarDTO(unitOfWork.CarRepository.GetById(id));
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] CarDTO value)
        {
            unitOfWork.CarRepository.Add(MapCarDTOToCar(value)); ;
            unitOfWork.SaveAll();
        }

        // PUT api/<CarController>/5
        [HttpPut()]
        public void Put( [FromBody] CarDTO value)
        {
            unitOfWork.CarRepository.Update(MapCarDTOToCar(value));
            unitOfWork.SaveAll();
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            unitOfWork.CarRepository.Delete(id);
            unitOfWork.SaveAll();
        }
    }
}
