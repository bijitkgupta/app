using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Domain.Model;
using App.DAL.EF;
using System.Net.Http;

namespace App.Test.UnitTest
{
    class App_Service_WebAPI_Test
    {
        private static App_Service_WebAPI_Test instance = null;
        private App_Service_WebAPI_Test()
        {
            Init();
        }
        public static App_Service_WebAPI_Test Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new App_Service_WebAPI_Test();
                }
                return instance;
            }
        }

        HttpClient client;
        private void Init()
        {
            client = new HttpClient() { BaseAddress = new Uri("http://PSHYS0256:1234") };
        }

        internal void Test_Read_CountryRegion()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync("/api/countries").Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
