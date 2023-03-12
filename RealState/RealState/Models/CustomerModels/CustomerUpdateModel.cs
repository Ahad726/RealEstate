using Autofac;
using RealState.Core.Entity;
using RealState.Core.Services;

namespace RealState.Models.CustomerModels
{
    public class CustomerUpdateModel
    {

        private ICustomerService _customerService;

        public CustomerUpdateModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }

        public void AddNewCustomer(CustomerModel customer)
        {
            _customerService.AddNewCustomer(new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.Phone,
                Address = customer.Adress
            });
        }
    }
}
