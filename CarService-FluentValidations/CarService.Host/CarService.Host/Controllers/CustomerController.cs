using CarService.BL.Interfaces;
using CarService.DL.Interfaces;
using CarService.Models.Dto;
using CarService.Models.Requests;
using FluentValidation;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerCrudService _carCrudService;
        private readonly IMapper _mapper;
        private IValidator<AddCustomerRequest> _validator;

        public CustomerController(
            ICustomerCrudService carCrudService,
            IMapper mapper,
            IValidator<AddCustomerRequest> validator)
        {
            _carCrudService = carCrudService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpDelete]
        public IActionResult DeleteCar(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("ID must be a valid Guid.");
            }
            var car = _carCrudService.GetById(id);
            if (car == null)
            {
                return NotFound($"Car with ID {id} not found.");
            }
            _carCrudService.DeleteCustomer(id);
            return Ok();
        }

        [HttpGet(nameof(GetById))]
        public IActionResult GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("ID must be a valid Guid.");
            }

            var car = _carCrudService.GetById(id);
            
            if (car == null)
            {
                return NotFound($"Car with ID {id} not found.");
            }

            return Ok(car);
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var cars = _carCrudService.GetAllCustomers();
            return Ok(cars);
        }

        [HttpPost]
        public IActionResult AddCar([FromBody] AddCustomerRequest? carRequest)
        {
            if (carRequest == null)
            {
                return BadRequest("Car data is null.");
            }

            var result = _validator.Validate(carRequest);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var car = _mapper.Map<Customer>(carRequest);

            _carCrudService.AddCustomer(car);

            return Ok();
        }
    }
}
