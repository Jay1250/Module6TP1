using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetModule5TP2.Models.DAL
{
    interface IDal<T> : IDisposable
    {
        List<T> getAll();
        T getOne(int id);
        T create(T t);
        T update(T t);
        bool delete(int id);
    }
}
