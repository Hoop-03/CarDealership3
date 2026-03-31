using CarService.Models.Dto;

namespace CarService.DL.Interfaces
{
    public interface ICustomerCrudService
    {
        void AddCustomer(Customer customer);

        void DeleteCustomer(Guid id);

        List<Customer> GetAllCustomers();

        Customer? GetById(Guid id);
    }
}
