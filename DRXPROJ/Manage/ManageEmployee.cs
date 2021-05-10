﻿using DRXPROJ.DataBaseConnections.SQLRepository;
using DRXPROJ.Manage.Interface;
using DRXPROJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DRXPROJ.Manage
{
    public class ManageEmployee : IManage<Employee>
    {
        List<Employee> _myList;
        SQLRepository<Employee> _repository;
        public ManageEmployee(SQLRepository<Employee> repository)
        {
            _repository = repository;
            _myList = repository.GetAll();
        }

        public void Add(Employee obj)
        {
            if (obj != null)
            {
                _myList.Add(obj);
                _repository.Insert(obj);
            }
        }
        public bool Exists(Employee obj)
        {
            if (_myList.Exists(x => x.Equals(obj)))
            {
                return true;
            }
            return false;
        }

        public List<Employee> GetAll()
        {
            return _myList;
        }

        public Employee GetById(int Id, [Optional] int id2)
        {
            return _myList.Where(x => x.Id.Equals(Id)).FirstOrDefault();
        }

        public int GetLastId()
        {
            throw new NotImplementedException();
        }

        public void Remove(int Id, [Optional] int id2)
        {
            _myList.Remove(_myList.Where(x => x.Id.Equals(Id)).FirstOrDefault());
            _repository.Delete(Id);
        }

        public void Update(Employee obj)
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