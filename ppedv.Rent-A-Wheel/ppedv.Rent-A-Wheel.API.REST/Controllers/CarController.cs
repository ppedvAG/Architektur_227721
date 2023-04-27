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
        private readonly IRepository repo;

        public CarController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return repo.GetAll<Car>();
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return repo.GetById<Car>(id) ;
        }

        // POST api/<CarController>
        [HttpPost]
        public void Post([FromBody] Car value)
        {
            repo.Add<Car>(value);
            repo.SaveAll();
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Car value)
        {
            repo.Update<Car>(value);
            repo.SaveAll();
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Delete<Car>(id);
            repo.SaveAll();
        }
    }
}
