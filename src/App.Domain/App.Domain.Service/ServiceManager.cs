using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.Service
{
    public class ServiceManager
    {
        private static ServiceManager instance;
        private static object _lock = new object();
        private ServiceManager() { serviceList = new Dictionary<string, IService<IServiceContract, IServiceContract>>(); }
        public static ServiceManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                        instance = new ServiceManager();
                }
                return instance;
            }
        }

        private Dictionary<string, IService<IServiceContract, IServiceContract>> serviceList;
        public IService<IServiceContract, IServiceContract> this[string key]
        {
            get { return serviceList[key]; }
            set { serviceList[key] = value; }
        }

        public void StartServices()
        {
            foreach (string key in this.serviceList.Keys)
            {
                this.serviceList[key].Host.Start();
            }
        }

        public void StopServices()
        {
            foreach (string key in this.serviceList.Keys)
            {
                this.serviceList[key].Host.Stop();
            }
        }

    }
}
