using KihoonShopes.Entities;
using KihoonShopApp.Models;
using Microsoft.AspNetCore.Mvc;
using KihoonShopes.Services;
using System.Numerics;

namespace KihoonShopApp.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController(ICustomerService iCustomerService, IInvoiceService iIInvoiceService)
        {
            _iCustomerService = iCustomerService;
            _iIInvoiceService = iIInvoiceService;
        }


        [HttpGet("/customers/{nameFrom}-{nameTo}")]
        public IActionResult List(string nameFrom, string nameTo)
        {
            List<Customer> customers = _iCustomerService.ListCustomerByInitial(nameFrom, nameTo);

            CustomersViewModel customersViewModel = new CustomersViewModel()
            {
                Customers = customers,
                ActivePage = $"{nameFrom}-{nameTo}"
            };

            return View(customersViewModel);
        }
        [HttpGet("/customers/add")]
        public IActionResult Add()
        {
            Customer customer = new Customer();

            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                Customer = customer
            };

            return View(customerViewModel);
        }
        [HttpPost("/customers/add")]
        public IActionResult Add(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(customerViewModel);
            }
            else
            {

                Customer customer = customerViewModel.Customer;
                _iCustomerService.AddNewCustomer(customer);

                TempData["notify"] = $"The customer {customerViewModel?.Customer?.Name} was added";
                return RedirectToAction("List", new { nameFrom = "A", nameTo = "E" });
            }
            
        }

        [HttpGet("/customers/{customerId:int}/edit")]
        public IActionResult Edit(int customerId)
        {
            Customer customer = _iCustomerService.GetCustomerById(customerId);

            if (customer == null)
            {
                return NotFound();
            }

            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                Customer = customer
            };

            return View(customerViewModel);
        }
        [HttpPost("/customers/{customerId:int}/edit")]
        public IActionResult Edit(int customerId, CustomerViewModel customerViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(customerViewModel);
            }
            else
            {

                Customer customer = customerViewModel.Customer;
                _iCustomerService.EditCustomer(customer);

                TempData["notify"] = $"The customer {customerViewModel?.Customer?.Name} was edited";
                TempData["ClassName"] = "success";

                return RedirectToAction("List", new { nameFrom = "A", nameTo = "E" });
            }
            
        }

        [HttpGet("/customers/{customerId:int}/delete")]
        public IActionResult Delete(int customerId)
        {
            Customer customer = _iCustomerService.GetCustomerById(customerId);
            _iCustomerService.UpdateCustomerStatus(customer);

            TempData["Content"] = $"The customer {customer.Name} was deleted";
            TempData["ClassName"] = "danger";
            TempData["CustomerId"] = customer.CustomerId;

            return RedirectToAction("List", new { nameFrom = "A", nameTo = "E" });
        }
        [HttpGet("/customers/{customerId:int}/undo")]
        public IActionResult UndoDelete(int customerId)
        {
            Customer customer = _iCustomerService.GetCustomerById(customerId);


            _iCustomerService.UpdateCustomerStatus(customer);

            TempData["Content"] = $"The {customer.Name} was not deleted";
            TempData["ClassName"] = "success";

            return RedirectToAction("List", new { nameFrom = "A", nameTo = "E" });
        }
       
        [HttpGet("/customers/{customerId}/invoices")]
        public IActionResult GetInvoicesByCustomerId(int customerId)
        {
            InvoiceViewModel invoiceViewModel = new InvoiceViewModel()
            {
                Customer = _iCustomerService.GetCustomerById(customerId),
                NewInvoice = new Invoice(),
                SelectedInvoice = new Invoice(),
                PaymentTerms = _iIInvoiceService.GetPaymentTerms()
            };

            invoiceViewModel.SelectedInvoice = (_iCustomerService?.GetCustomerById(customerId))?.Invoices[0];

            invoiceViewModel.Customer.Invoices = _iIInvoiceService.GetInvoicesByCustomerId(customerId).ToList();

            return View("Invoices", invoiceViewModel);
        }

        [HttpGet("/customers/{customerId}/invoices/{invoiceId}")]
        public IActionResult GetInvoiceLineItems(int customerId, int invoiceId)
        {
            InvoiceViewModel invoiceViewModel = new InvoiceViewModel()
            {
                Customer = _iCustomerService.GetCustomerById(customerId),
                PaymentTerms = _iIInvoiceService.GetPaymentTerms(),
                SelectedInvoice = _iIInvoiceService.GetInvoiceByInvoiceId(invoiceId),
                NewInvoice = new Invoice()
            };

            return View("Invoices", invoiceViewModel);
        }

        [HttpPost("/customers/{customerId}/invoices/{invoiceId}/addInvoice")]
        public IActionResult AddInvoiceInCustomerById(int customerId, InvoiceViewModel invoiceViewModel)
        {
            invoiceViewModel.NewInvoice.CustomerId = customerId;

            _iIInvoiceService.AddNewInvoice(invoiceViewModel.NewInvoice);


            TempData["notify"] = $"The invoice was added";
            TempData["ClassName"] = "success";

            return RedirectToAction("GetInvoicesByCustomerId", new { customerId = customerId });
        }

        [HttpPost("/customers/{customerId}/invoices/{invoiceId}/addLineItem")]
        public IActionResult AddInvoiceLineItemInInvoiceById(int customerId, int invoiceId, InvoiceViewModel InvoiceViewModel)
        {
            if (InvoiceViewModel.NewInvoiceLineItem.Amount == null)
            {

                InvoiceViewModel.NewInvoiceLineItem.Amount = 0;
            
            }

            InvoiceViewModel.NewInvoiceLineItem.InvoiceId = invoiceId;
            _iIInvoiceService.AddNewInvoiceLineItem(InvoiceViewModel.NewInvoiceLineItem);

            TempData["notify"] = $"The invoice was added";
            TempData["ClassName"] = "success";

            return RedirectToAction("GetInvoicesByCustomerId", new { customerId = customerId });
        }

        private readonly ICustomerService _iCustomerService;
        private readonly IInvoiceService _iIInvoiceService;
    }



}
