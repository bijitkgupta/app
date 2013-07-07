using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Test.UnitTest
{
    public class Test
    {
        private delegate void TestDelegate();
        static TestDelegate td;
        static void Main(String[] args)
        {
            td = new TestDelegate(InitTest);
            //Do_App_DAL_EF_Test();
            Do_App_Service_WebAPI_Test();

            td.Invoke();
        }
        static void Do_App_Service_WebAPI_Test()
        {
            td += new TestDelegate(App_Service_WebAPI_Test.Instance.Test_Read_CountryRegion);
        }
        static void Do_App_DAL_EF_Test()
        {
            //td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Delete_Address);
            //td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Delete_DomainBase);
            //td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Delete_Person);
            //td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Delete_PersonEmail);
            //td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Delete_PersonPhone);
            //td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Delete_DomainAddress);
            //td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Delete_ContactPerson);


            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Read_CountryRegion);
            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Read_StateProvince);
            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Read_Address);
            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Read_AddressType);
            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Read_ContactType);
            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Read_PhoneNumberType);
            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Read_Person);
            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Read_PersonEmail);
            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Read_PersonPhone);
            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Read_DomainAddress);
            //td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Read_ContactPerson);


            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Create_Address);
            //td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Create_DomainBase);
            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Create_Person);
            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Create_PersonEmail);
            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Create_PersonPhone);
            td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Create_DomainAddress);
            //td += new TestDelegate(App_DAL_EF_Test.Instance.Test_Create_ContactPerson);
            
            Console.Read();
        }
        static void InitTest() { }
    }
}