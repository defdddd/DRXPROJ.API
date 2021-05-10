using DRXPROJ.DataBaseConnections.SQLRepository;
using DRXPROJ.DataBaseConnections.SQLRepository.Manage;
using DRXPROJ.Manage;
using DRXPROJ.Manage.Interface;
using DRXPROJ.Models;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRXPROJ.CustomInjections
{
    class CustomInjections : NinjectModule
    {
        public override void Load()
        {
            Bind<Asset>().To<Asset>();
            Bind<AssetEmployee>().To<AssetEmployee>();
            Bind<Costcenters>().To<Costcenters>();
            Bind<Employee>().To<Employee>();

            Bind<IManage<Asset>>().To<ManageAsset>();
            Bind<IManage<AssetEmployee>>().To<ManageAssetEmployee>();
            Bind<IManage<Costcenters>>().To<ManageCostcenters>();
            Bind<IManage<Employee>>().To<ManageEmployee>();

            Bind<SQLRepository<Asset>>().To<AssetRepository>();
            Bind<SQLRepository<AssetEmployee>>().To<AssetEmployeeRepository>();
            Bind<SQLRepository<Costcenters>>().To<CostcentersRepository>();
            Bind<SQLRepository<Employee>>().To<EmployeeRepository>();
        }
    }
}
