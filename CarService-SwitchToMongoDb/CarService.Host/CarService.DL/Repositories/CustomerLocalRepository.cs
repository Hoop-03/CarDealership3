using CarService.DL.Interfaces;
using CarService.DL.LocalDb;
using CarService.Models.Dto;

namespace CarService.DL.Repositories
{
    internal class CustomerLocalRepository : ICustomerRepository
    {
        public void AddCustomer(Customer car)
        {
            StaticDb.Customers.Add(car);
        }

        public void DeleteCustomer(Guid id)
        {
            StaticDb.Customers.RemoveAll(c => c.Id == id);
        }

        public List<Customer> GetAllCustomers()
        {
            return StaticDb.Customers;
        }

        public Customer? GetById(Guid id)
        {
            return StaticDb.Customers
                .FirstOrDefault(c =>
                    c.Id == id);
        }
    }
}
