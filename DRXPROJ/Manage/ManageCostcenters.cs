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

        public void Add(Costcenters obj)
        {
            if (obj != null)
            {
                _myList.Add(obj);
                _repository.Insert(obj);
            }
        }
        public bool Exists(Costcenters obj)
        {
            if (_myList.Exists(x => x.Equals(obj)))
            {
                return true;
            }
            return false;
        }

        public List<Costcenters> GetAll()
        {
            return _myList;
        }

        public Costcenters GetById(int nr, [Optional] int id2)
        {
            return _myList.Where(x => x.Nr.Equals(nr)).FirstOrDefault();
        }

        public int GetLastId()
        {
            throw new NotImplementedException();
        }

        public void Remove(int nr, [Optional] int id2)
        {
            _myList.Remove(_myList.Where(x => x.Nr.Equals(nr) ).FirstOrDefault());
            _repository.Delete(nr);
        }

        public void Update(Costcenters obj)
        {
            if (obj != null)
            {
                _repository.Update(obj);
                _myList.Remove(_myList.Where(x => x.Nr.Equals(obj.Nr)).FirstOrDefault());
                _myList.Add(obj);
            }
        }

    }
}
