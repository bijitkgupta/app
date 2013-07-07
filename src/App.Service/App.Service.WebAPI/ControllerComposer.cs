using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http.Dispatcher;
using App.Domain.Model;
using App.DAL.EF;

using App.Service.WebAPI.Controllers;

namespace App.Service.WebAPI
{
    internal class ControllerComposer : IHttpControllerActivator
    {
        private Logic logic;
        private IRepository repository;
        private string connectionString = @"Data Source=PSHYS0256\SQLEXPRESS;Initial Catalog=AdventureWorks2008R2;User=sa;Password=Deadman@1990";
        internal ControllerComposer()
        {
            repository = new EFRepository(connectionString);
            logic = new Logic(repository);
        }
        public System.Web.Http.Controllers.IHttpController Create(System.Net.Http.HttpRequestMessage request, System.Web.Http.Controllers.HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (controllerType == typeof(CountriesController))
            {
                return new CountriesController(logic);
            }
            else if (controllerType == typeof(StatesController))
            {
                return new StatesController(logic);
            }
            else if (controllerType == typeof(PhoneNumberTypesController))
            {
                return new PhoneNumberTypesController(logic);
            }
            else if (controllerType == typeof(ContactTypesController))
            {
                return new ContactTypesController(logic);
            }
            else if (controllerType == typeof(AddressTypesController))
            {
                return new AddressTypesController(logic);
            }
            else if (controllerType == typeof(NameStylesController))
            {
                return new NameStylesController(logic);
            }
            else if (controllerType == typeof(EmailPromotionsController))
            {
                return new EmailPromotionsController(logic);
            }
            else if (controllerType == typeof(PersonTypesController))
            {
                return new PersonTypesController(logic);
            }
            else if (controllerType == typeof(AddressesController))
            {
                return new AddressesController(logic);
            }
            else if (controllerType == typeof(EmailsController))
            {
                return new EmailsController(logic);
            }
            else if (controllerType == typeof(PhoneNumbersController))
            {
                return new PhoneNumbersController(logic);
            }
            else if (controllerType == typeof(PersonsController))
            {
                return new PersonsController(logic);
            }
            return null;
        }
    }
}
