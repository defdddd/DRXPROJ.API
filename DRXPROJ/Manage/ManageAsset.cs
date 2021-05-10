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
    public class ManageAsset:IManage<Asset>
    {
        List<Asset> _myList;
        SQLRepository<Asset> _repository; 
        public ManageAsset(SQLRepository<Asset> repository)
        {
            _repository = repository;
            _myList = repository.GetAll();
        }

        public void Add(Asset obj)
        {
            if (obj != null)
            {
                _myList.Add(obj);
                _repository.Insert(obj);
            }
        }
        public bool Exists(Asset obj)
        {
            if (_myList.Exists(x => x.Equals(obj)))
            {
                return true;
            }
            return false;
        }

        public List<Asset> GetAll()
        {
            return _myList;
        }

        public Asset GetById(int id, [Optional] int id2)
        {
            return _myList.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }

        public int GetLastId()
        {
            return _myList.OrderBy(x => x.Id).Select(y => y.Id).LastOrDefault();

        }

        public void Remove(int id, [Optional] int id2)
        {
            _myList.Remove(_myList.Where(x=>x.Id.Equals(id)).FirstOrDefault());
            _repository.Delete(id);      
        }

        public void Update(Asset obj)
        {
            if (obj != null)
            {
                _repository.Update(obj);
                _myList.Remove(_myList.Where(x => x.Id.Equals(obj.Id)).FirstOrDefault());
                _myList.Add(obj);
            }
        }
    }
}
