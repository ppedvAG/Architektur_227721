using Microsoft.AspNetCore.Mvc;
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



        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return unitOfWork.CarRepository.GetAll();
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return unitOfWork.CarRepository.GetById(id);
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            unitOfWork.CarRepository.Add(value);
            unitOfWork.SaveAll();
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car value)
        {
            unitOfWork.CarRepository.Update(value);
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
