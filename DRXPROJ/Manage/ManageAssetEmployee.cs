using DRXPROJ.DataBaseConnections.SQLRepository;
using DRXPROJ.Manage.Interface;
using DRXPROJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DRXPROJ.Manage
{
    public class ManageAssetEmployee : IManage<AssetEmployee>
    {
        List<AssetEmployee> _myList;
        SQLRepository<AssetEmployee> _repository;
        public ManageAssetEmployee(SQLRepository<AssetEmployee> repository)
        {
            _repository = repository;
            _myList = repository.GetAll();
        }

        public void Add(AssetEmployee obj)
        {
            if (obj != null)
            {
                _myList.Add(obj);
                _repository.Insert(obj);
            }
        }
        public bool Exists(AssetEmployee obj)
        {
            if (_myList.Exists(x => x.AssetId.Equals(obj.AssetId) && x.EmployeeId.Equals(obj.EmployeeId)))
            {
                return true;
            }
            return false;
        }

        public List<AssetEmployee> GetAll()
        {
            return _myList;
        }

        public AssetEmployee GetById(int assetid,[Optional] int employeeid)
        {
            return _myList.Where(x => x.AssetId.Equals(assetid) && x.EmployeeId.Equals(employeeid)).FirstOrDefault();
        }

        public int GetLastId()
        {
            throw new NotImplementedException();
        }

        public void Remove(int assetid, [Optional] int employeeid)
        {
            _myList.Remove(_myList.Where(x => x.EmployeeId.Equals(employeeid) && x.AssetId.Equals(assetid)).FirstOrDefault());
            _repository.Delete(assetid, employeeid);
        }

        public void Update(AssetEmployee obj)
        {
            if (obj != null)
            {
                _repository.Update(obj);
                _myList.Remove(_myList.Where(x => x.AssetId.Equals(obj.AssetId) && x.EmployeeId.Equals(obj.EmployeeId)).FirstOrDefault());
                _myList.Add(obj);
            }
        }

    }
}
