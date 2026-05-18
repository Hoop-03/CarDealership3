using CarService3.DL.Interfaces;
using CarService3.Models.Entities;
using Microsoft.Extensions.Logging;

namespace CarService3.DL.Repositories
{
    internal class CustomerStaticRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerStaticRepository> _logger;

        public CustomerStaticRepository(ILogger<CustomerStaticRepository> logger)
        {
            _logger = logger;
        }

        public async Task Add(Customer? customer)
        {
            if (customer == null) return;

            await Task.Run(() => MyStaticDb.StaticDb.Customers.Add(customer));
        }

        public async Task<List<Customer>> GetAll()
        {
            try
            {
                return await Task.FromResult(MyStaticDb.StaticDb.Customers);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in {nameof(GetAll)}:{e.Message}-{e.StackTrace}");
            }

            return new List<Customer>();
        }

        public async Task<Customer?> GetById(Guid id)
        {
            if (id == Guid.Empty) return null;

            return await Task.FromResult(MyStaticDb.StaticDb
                .Customers
                .FirstOrDefault(c => c.Id == id));
        }

        public async Task Delete(Guid id)
        {
            if (id == Guid.Empty) return;

            var customer = await Task.Run(() => GetById(id));

            if (customer != null)
            {
                await Task.Run(() => MyStaticDb.StaticDb.Customers.Remove(customer));
            }
        }
    }
}
