using CarService.BL.Interfaces;
using CarService.DL.Interfaces;
using CarService.Models.Dto;

namespace CarService.BL.Services
{
    internal class CustomerCrudService : ICustomerCrudService
    {
        private readonly ICustomerRepository _carRepository;

        public CustomerCrudService(ICustomerRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void AddCustomer(Customer car)
        {
            if (car == null) return;

            if (car?.Id == null || car.Id == Guid.Empty)
            {
                car!.Id = Guid.NewGuid();
            }

            _carRepository.AddCustomer(car);
        }

        public void DeleteCustomer(Guid id)
        {
            _carRepository.DeleteCustomer(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _carRepository.GetAllCustomers();
        }

        public Customer? GetById(Guid id)
        {
            return _carRepository.GetById(id);
        }
    }
}
