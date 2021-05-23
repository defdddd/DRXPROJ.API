using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DRXPROJ.Manage.Interface
{
    public interface IManage<T>
    {
        T Add(T obj);
        void Remove(int id,[Optional]int id2);
        List<T> GetAll();
        T Update(T obj);
        bool Exists(T obj);
        int GetLastId();
        T GetById(int id, [Optional] int id2);

    }
}
