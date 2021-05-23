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
    public class ManageCostcenters : IManage<Costcenters>
    {
        List<Costcenters> _myList;
        SQLRepository<Costcenters> _repository;
        public ManageCostcenters(SQLRepository<Costcenters> repository)
        {
            _repository = repository;
            _myList = repository.GetAll();
        }

        public Costcenters Add(Costcenters obj)
        {
            if (obj != null)
            {
                if (_myList.Exists(x => x.EmployeeId.Equals(obj.EmployeeId) || x.Name.Equals(obj.Name)))  return null;
                _myList.Add(obj);
                _repository.Insert(obj);
                return _repository.GetAll().OrderByDescending(x => x.Id).FirstOrDefault();
            }
            return obj;
        }
        public bool Exists(Costcenters obj)
        {
            if (_myList.Exists(x => x.EmployeeId.Equals(obj.EmployeeId)))
            {
                return true;
            }
            return false;
        }

        public List<Costcenters> GetAll()
        {
            return _myList;
        }

        public Costcenters GetById(int Id , [Optional] int id2)
        {
            return _myList.Where(x => x.Id .Equals(Id )).FirstOrDefault();
        }

        public int GetLastId()
        {
            throw new NotImplementedException();
        }

        public void Remove(int Id , [Optional] int id2)
        {
            _myList.Remove(_myList.Where(x => x.Id .Equals(Id ) ).FirstOrDefault());
            _repository.Delete(Id );
        }

        public Costcenters Update(Costcenters obj)
        {
            if (obj != null)
            {
                if (_myList.Exists(x => x.Name.Equals(obj.Name))) return null;
                if (_myList.Exists(x => x.Id.Equals(obj.Id) && x == obj)) return null;
                _repository.Update(obj);
                _myList.Remove(_myList.Where(x => x.Id .Equals(obj.Id)).FirstOrDefault());
                _myList.Add(obj);
              
            }
            return obj;
        }

    }
}
