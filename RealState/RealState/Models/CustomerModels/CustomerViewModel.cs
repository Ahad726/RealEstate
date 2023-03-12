using Autofac;
using RealState.Core.Services;

namespace RealState.Models.CustomerModels
{
    public class CustomerViewModel
    {
        private ICustomerService _customerService;

        public CustomerViewModel()
        {
            _customerService = Startup.AutofacContainer.Resolve<ICustomerService>();
        }


        public object GetCustomers(DataTablesAjaxRequestModel tableModel)
        {
            return null;
        }
    }
}
