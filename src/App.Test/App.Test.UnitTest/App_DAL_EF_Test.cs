using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.DAL.EF;
using App.Domain.Model;

namespace App.Test.UnitTest
{
    class App_DAL_EF_Test
    {
        private string connectionString = @"Data Source=PSHYS0256\SQLEXPRESS;Initial Catalog=AppDB;User=sa;Password=Deadman@1990";
        private static App_DAL_EF_Test instance = null;
        private App_DAL_EF_Test()
        {
            Init();
        }
        public static App_DAL_EF_Test Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new App_DAL_EF_Test();
                }
                return instance;
            }
        }

        Random rnd = null;
        IRepository rep = null;
        private void Init()
        {
            rep = new EFRepository(connectionString);
            rnd = new Random();
        }

        #region Test_Read
        internal void Test_Read_CountryRegion()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                var v = rep.Read<CountryRegion>().ToList<CountryRegion>();
                if (v.Count > 0)
                {
                    Console.WriteLine("Test_Read_CountryRegion Pass : " + "Country Region Count = " + v.Count);
                }
                else
                {
                    Console.WriteLine("Test_Read_CountryRegion Fail : " + "No Country Region Found");
                }
            }
        }
        internal void Test_Read_StateProvince()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                var v = rep.Read<StateProvince>().ToList<StateProvince>();
                if (v.Count > 0)
                {
                    Console.WriteLine("Test_Read_StateProvince Pass : " + "State Province Count = " + v.Count);
                }
                else
                {
                    Console.WriteLine("Test_Read_StateProvince Fail : " + "No State Province Found");
                }
            }
        }
        internal void Test_Read_Address()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                var v = rep.Read<Address>().ToList<Address>();
                if (v.Count > 0)
                {
                    Console.WriteLine("Test_Read_Address Pass : " + "Address Count = " + v.Count);
                }
                else
                {
                    Console.WriteLine("Test_Read_Address Fail : " + "No Address Found");
                }
            }
        }
        internal void Test_Read_AddressType()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                var v = rep.Read<AddressType>().ToList<AddressType>();
                if (v.Count > 0)
                {
                    Console.WriteLine("Test_Read_AddressType Pass : " + "Address Type Count = " + v.Count);
                }
                else
                {
                    Console.WriteLine("Test_Read_AddressType Fail : " + "No Address Type Found");
                }
            }
        }
        internal void Test_Read_ContactType()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                var v = rep.Read<ContactType>().ToList<ContactType>();
                if (v.Count > 0)
                {
                    Console.WriteLine("Test_Read_ContactType Pass : " + "Contact Type Count = " + v.Count);
                }
                else
                {
                    Console.WriteLine("Test_Read_ContactType Fail : " + "No Contact Type Found");
                }
            }
        }
        internal void Test_Read_PhoneNumberType()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                var v = rep.Read<PhoneNumberType>().ToList<PhoneNumberType>();
                if (v.Count > 0)
                {
                    Console.WriteLine("Test_Read_PhoneNumberType Pass : " + "Phone Number Type Count = " + v.Count);
                }
                else
                {
                    Console.WriteLine("Test_Read_PhoneNumberType Fail : " + "No Phone Number Type Found");
                }
            }
        }
        internal void Test_Read_Person()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                var v = rep.Read<Person>().ToList<Person>();
                if (v.Count > 0)
                {
                    Console.WriteLine("Test_Read_Person Pass : " + "Person Count = " + v.Count);
                }
                else
                {
                    Console.WriteLine("Test_Read_Person Fail : " + "No Person Found");
                }
            }
        }
        internal void Test_Read_DomainAddress()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                string[] children = { "Address", "AddressType" };
                var v = rep.Read<DomainAddress>(children).ToList<DomainAddress>();
                if (v.Count > 0)
                {
                    Console.WriteLine("Test_Read_DomainAddress Pass : " + "Domain Address Count = " + v.Count);
                }
                else
                {
                    Console.WriteLine("Test_Read_DomainAddress Fail : " + "No Domain Address Found");
                }
            }
        }
        internal void Test_Read_ContactPerson()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                var v = rep.Read<ContactPerson>().ToList<ContactPerson>();
            }
        }
        internal void Test_Read_PersonEmail()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                var v = rep.Read<PersonEmail>().ToList<PersonEmail>();
                if (v.Count > 0)
                {
                    Console.WriteLine("Test_Read_PersonEmail Pass : " + "Person Email Count = " + v.Count);
                }
                else
                {
                    Console.WriteLine("Test_Read_PersonEmail Fail : " + "No Person Email Found");
                }
            }
        }
        internal void Test_Read_PersonPhone()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                var v = rep.Read<PersonPhone>().ToList<PersonPhone>();
                if (v.Count > 0)
                {
                    Console.WriteLine("Test_Read_PersonPhone Pass : " + "Person Phone Count = " + v.Count);
                }
                else
                {
                    Console.WriteLine("Test_Read_PersonPhone Fail : " + "No Person Phone Found");
                }
            }
        }
        #endregion

        #region Test_Create
        internal void Test_Create_Address()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                var state = rep.Read<StateProvince>(sp => sp.CountryRegion.CountryRegionCode == "US").LastOrDefault();
                var addr = new Address("Address_US" + rnd.Next(3, 10), "City_US", state, "700008");
                var addr2 = rep.Create<Address>(addr);

                
            }
        }
        internal void Test_Create_Person()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                var domainBase = rep.Create<DomainBase>(new DomainBase());
                rep.Commit();
                rep.Create<Person>(new Person(domainBase)
                {
                    PersonType_ENUM = PersonTypeENUM.IN,
                    NameStyle_ENUM = NameStyleENUM.Eastern,
                    Title = "Mr.",
                    FirstName = "Bijit",
                    MiddleName = "Kumar",
                    LastName = "Gupta",
                    EmailPromotion_ENUM = EmailPromotionENUM.Strict,
                });
            }
        }
        internal void Test_Create_DomainBase()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                var domainBase = rep.Create<DomainBase>(new DomainBase());
                
            }
        }
        internal void Test_Create_PersonEmail()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                Person p = rep.Read<Person>().LastOrDefault();
                var domainBase = rep.Create<PersonEmail>(new PersonEmail(p, "bijitkgupta"+ rnd.Next(0, 10) + "@gmail.com"));
                
            }
        }
        internal void Test_Create_PersonPhone()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                Person p = rep.Read<Person>().LastOrDefault();
                PhoneNumberType pnt = rep.Read<PhoneNumberType>(pt => pt.ID == (int)PhoneNumberTypeENUM.Home).LastOrDefault();
                var pp = rep.Create<PersonPhone>(new PersonPhone(p, "9" + rnd.Next(100000000, 999999999).ToString(), pnt));
                
            }
        }
        internal void Test_Create_DomainAddress()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                Person p = rep.Read<Person>().LastOrDefault();
                Address a = rep.Read<Address>().LastOrDefault();
                AddressType at = rep.Read<AddressType>(pt => pt.ID == (int)AddressTypeENUM.MainOffice).LastOrDefault();
                var pp = rep.Create<DomainAddress>(new DomainAddress(p.ID, a, at));
                
            }
        }
        internal void Test_Create_ContactPerson()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                Person p = rep.Read<Person>().LastOrDefault();
                PhoneNumberType pnt = rep.Read<PhoneNumberType>(pt => pt.ID == (int)PhoneNumberTypeENUM.Cell).LastOrDefault();
                //var pp = rep.Create<DomainAddress>(new DomainAddress(p, "8886113700", pnt));
                
            }
        }
        #endregion
        
        #region Test_Delete
        internal void Test_Delete_Address()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                rep.Delete<Address>();
                
            }
        }
        internal void Test_Delete_Person()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                rep.Delete<Person>();
                
            }
        }
        internal void Test_Delete_PersonEmail()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                rep.Delete<PersonEmail>();
                
            }
        }
        internal void Test_Delete_PersonPhone()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                rep.Delete<PersonPhone>();
                
            }
        }
        internal void Test_Delete_DomainAddress()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                rep.Delete<DomainAddress>();
                
            }
        }
        internal void Test_Delete_ContactPerson()
        {
            using (UnitOfWork uow = new UnitOfWork(rep))
            {
                rep.Delete<ContactPerson>();
                
            }
        }
        #endregion
    }
}