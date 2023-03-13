using RealState.Core.Entity;
using RealState.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealState.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerUnitOfWork _customerUnitOfWork;

        public CustomerService(ICustomerUnitOfWork customerUnitOfWork)
        {
            _customerUnitOfWork = customerUnitOfWork;
        }

        public void AddNewCustomer(Customer customer)
        {
            if (customer == null) throw new InvalidOperationException("Customer Cannot ber null");

            _customerUnitOfWork.CustomerRepository.Add(customer);
            _customerUnitOfWork.Save();
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _customerUnitOfWork.CustomerRepository.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerUnitOfWork.CustomerRepository.GetById(id);
        }

        public void EditCustomer(Customer customer)
        {
            var oldCustomer = _customerUnitOfWork.CustomerRepository.GetById(customer.Id);

            if (oldCustomer != null)
            {
                oldCustomer.Name = customer.Name;
                oldCustomer.Email = customer.Email;
                oldCustomer.Address = customer.Address;
                oldCustomer.PhoneNumber = customer.PhoneNumber;

                _customerUnitOfWork.Save();
            }
        }

        public void Remove(int id)
        {
            _customerUnitOfWork.CustomerRepository.Remove(id);
            _customerUnitOfWork.Save();
        }

        public IEnumerable<Customer> GetCustomers(int pageIndex, int pageSize, string searchText, out int total, out int totalFiltered)
        {
            return _customerUnitOfWork.CustomerRepository.Get(

                out total,
                out totalFiltered,
                 x => x.Name.Contains(searchText) || x.Email.Contains(searchText)
                 || x.Address.Contains(searchText) || x.PhoneNumber.Contains(searchText),
                null,
                "",
                pageIndex,
                pageSize,
                true);  
                
        }
    }
}
