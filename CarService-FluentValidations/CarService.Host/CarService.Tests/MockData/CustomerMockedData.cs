using CarService.Models.Dto;

namespace CarService.Tests.MockData
{
    internal static class CustomerMockedData
    {
        public static List<Customer> Customers =
           new List<Customer>()
           {
                new Customer()
                {
                    Id = Guid.NewGuid(),
                    Name = "John Doe",
                    Email = "jd@xxx.com"
                },
                new Customer()
                {
                    Id = Guid.NewGuid(),
                    Name = "Stamat Genov",
                    Email = "sg@xxx.com"
                }
           };
    }
}
